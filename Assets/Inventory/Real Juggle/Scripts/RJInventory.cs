using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RJInventory : MonoBehaviour
{
    public GameObject Slots;

    private List<GameObject> _slots = new List<GameObject>();

    public RJHand LeftHand;
    public RJHand RightHand;
    private void Start()
    {
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
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Combine();
        }
    }

    void RotateLeft()
    {
        RJItem item;
        RJItem nextItem = _slots[0].GetComponent<RJSlot>().GetItem();
        RJSlot nextSlot;
        //Move all items except last, to new slots
        int i = 0;
        while(i < _slots.Count - 1)
        {
            item = nextItem;
            nextSlot = _slots[i + 1].GetComponent<RJSlot>();
            nextItem = nextSlot.GetItem();
            if (nextItem)
            {
                nextSlot.ReleaseInInventory();
            }
            if (item)
            {
                nextSlot.CatchInInventory(item);
            }
            i++;
        }
        if(i < _slots.Count)
        {
            //Move last slot-item to left hand
            item = nextItem;
            nextItem = LeftHand.GetItem();
            if (nextItem)
            {
                LeftHand.ReleaseInInventory();
            }
            if (item)
            {
                LeftHand.CatchInInventory(item);
            }

            //Move left hand-item to first slot
            item = nextItem;
            nextSlot = _slots[0].GetComponent<RJSlot>();
            if (nextItem)
            {
                nextSlot.ReleaseInInventory();
            }
            if (item)
            {
                nextSlot.CatchInInventory(item);
            }
        }
    }

    void RotateRight()
    {
        RJItem item;
        RJItem nextItem = _slots[0].GetComponent<RJSlot>().GetItem();
        RJSlot nextSlot;
        //Move all items except last, to new slots
        int i = _slots.Count - 2;
        while (i > 0)
        {
            item = nextItem;
            nextSlot = _slots[i + 1].GetComponent<RJSlot>();
            nextItem = nextSlot.GetItem();
            if (nextItem)
            {
                nextSlot.ReleaseInInventory();
            }
            if (item)
            {
                nextSlot.CatchInInventory(item);
            }
            i--;
        }
        if (i < _slots.Count)
        {
            //Move last slot-item to right hand
            item = nextItem;
            nextItem = RightHand.GetItem();
            if (nextItem)
            {
                RightHand.ReleaseInInventory();
            }
            if (item)
            {
                RightHand.CatchInInventory(item);
            }

            //Move right hand-item to first slot
            item = nextItem;
            nextSlot = _slots[_slots.Count - 1].GetComponent<RJSlot>();
            if (nextItem)
            {
                nextSlot.ReleaseInInventory();
            }
            if (item)
            {
                nextSlot.CatchInInventory(item);
            }
        }
    }

    void Combine()
    {

    }
}
