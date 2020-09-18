using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RJInventory : MonoBehaviour
{
    public GameObject Slots;
    private List<GameObject> _slots = new List<GameObject>();

    public RJHand LeftHand;
    public RJHand RightHand;

    //Combine
    public RJCombine combine;
    public RJPickUpAbility pickUpAbility;

    private void OnEnable()
    {
        _slots.Clear();
        foreach (Transform t in Slots.transform)
        {
            _slots.Add(t.gameObject);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RotateRight();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (Combine())
            {
                //play sound
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchItems();
        }
    }

    void RotateLeft()
    {
        List<GameObject> places = new List<GameObject>();
        places.AddRange(_slots);
        places.Add(LeftHand.gameObject);

        if (places.Count > 0)
        {
            
            RJItem item;
            RJSlot nextSlot = places[0].GetComponent<RJSlot>();
            RJItem nextItem = nextSlot.GetItem();
            nextSlot.ReleaseInInventory();
            int i = 1;
            while (i < places.Count)
            {
                item = nextItem;
                nextSlot = places[i].GetComponent<RJSlot>();

                nextItem = nextSlot.GetItem();
                nextSlot.ReleaseInInventory();
                nextSlot.CatchInInventory(item);
                
                i++;
            }
            item = nextItem;
            nextSlot = places[0].GetComponent<RJSlot>();
            nextSlot.CatchInInventory(item);
        }
    }

    void RotateRight()
    {
        List<GameObject> places = new List<GameObject>();
        places.AddRange(_slots);
        Queue<GameObject> que = new Queue<GameObject>(places.ToArray());
        que.Enqueue(que.Dequeue());
        places.Clear();
        places.AddRange(que);
        places.Reverse();
        places.Add(RightHand.gameObject);

        if (places.Count > 0)
        {

            RJItem item;
            RJSlot nextSlot = places[0].GetComponent<RJSlot>();
            RJItem nextItem = nextSlot.GetItem();
            nextSlot.ReleaseInInventory();
            int i = 1;
            while (i < places.Count)
            {
                item = nextItem;
                nextSlot = places[i].GetComponent<RJSlot>();

                nextItem = nextSlot.GetItem();
                nextSlot.ReleaseInInventory();
                nextSlot.CatchInInventory(item);

                i++;
            }
            item = nextItem;
            nextSlot = places[0].GetComponent<RJSlot>();

            nextSlot.CatchInInventory(item);
        }
    }
    public void Open()
    {
        foreach (GameObject slot in _slots)
        {
            RJItem item = slot.GetComponent<RJSlot>().GetItem();
            item?.OpenInInventory();
        }
        LeftHand.GetItem()?.OpenInInventory();
        RightHand.GetItem()?.OpenInInventory();
    }
    public void Close()
    {
        foreach (GameObject slot in _slots)
        {
            RJItem item = slot.GetComponent<RJSlot>().GetItem();
            item?.CloseInInventory();
        }
        LeftHand.GetItem()?.CloseInInventory();
        RightHand.GetItem()?.CloseInInventory();
    }
    bool Combine()
    {
        var Litem = LeftHand.GetItem();
        var Ritem = RightHand.GetItem();
        if(Litem && Ritem)
        {
            var newItem = combine.Combine(Litem, Ritem);
            if (newItem)
            {
                LeftHand.Drop();
                Destroy(Litem.gameObject);
                RightHand.Drop();
                Destroy(Ritem.gameObject);

                var GO = Instantiate(newItem);
                pickUpAbility.PickUp(GO.GetComponent<RJItem>());

                return true;
            }
        }
        return false;
    }

    void SwitchItems()
    {
        var Litem = LeftHand.GetItem();
        LeftHand.ReleaseInInventory();
        var Ritem = RightHand.GetItem();
        RightHand.ReleaseInInventory();

        if (Litem)
        {
            RightHand.CatchInInventory(Litem);
        }

        if (Ritem)
        {
            LeftHand.CatchInInventory(Ritem);
        }
    }
}
