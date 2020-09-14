using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTPickUpAbility : MonoBehaviour
{
    public JTItem FocusItem;
    public KeyCode PickUpKey = KeyCode.F;
    public JTHand RightHand;
    private void Update()
    {
        if (Input.GetKeyDown(PickUpKey))
        {
            if (FocusItem)
            {
                PickUp(FocusItem);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<JTItem>();
        if (item)
        {
            if (!item.Equals(FocusItem))
            {
                UnFocus(FocusItem);
                Focus(item);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var item = other.GetComponent<JTItem>();
        if (item)
        {
            if (item.Equals(FocusItem))
            {
                UnFocus(FocusItem);
            }
        }
    }

    public void Focus(JTItem item)
    {
        if (item)
        {
            FocusItem = item;
            FocusItem.MoveModelUp();
        }
    }

    public void UnFocus(JTItem item)
    {
        if (item)
        {
            FocusItem.MoveModelDown();
            FocusItem = null;
        }
    }
    public void PickUp(JTItem item)
    {
        Drop();
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Collider>().isTrigger = true;
        RightHand.PickUp(item);
    }

    public void Drop()
    {
        var Ritem = RightHand.GetItem();
        if (Ritem)
        {
            RightHand.Drop(Ritem);
            Ritem.GetComponent<Collider>().isTrigger = false;
            Ritem.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
