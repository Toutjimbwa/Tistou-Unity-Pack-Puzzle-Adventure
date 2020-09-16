using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RJPickUpAbility : MonoBehaviour
{
    public RJItem FocusItem;
    public KeyCode PickUpKey = KeyCode.F;
    public RJHand RightHand;
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
        var item = other.GetComponent<RJItem>();
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
        var item = other.GetComponent<RJItem>();
        if (item)
        {
            if (item.ModelIsUp)
            {
                UnFocus(FocusItem);
            }
        }
    }

    public void Focus(RJItem item)
    {
        if (item)
        {
            FocusItem = item;
            FocusItem.MoveModelUp();
        }
    }

    public void UnFocus(RJItem item)
    {
        if (item)
        {
            FocusItem.MoveModelDown();
            FocusItem = null;
        }
    }
    public void PickUp(RJItem item)
    {
        Drop();
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Collider>().isTrigger = true;
        RightHand.PickUp(item);
        if (FocusItem && FocusItem.Equals(item)) FocusItem = null;
    }

    public void Drop()
    {
        var Ritem = RightHand.GetItem();
        if (Ritem)
        {
            RightHand.Drop();
            Ritem.GetComponent<Collider>().isTrigger = false;
            Ritem.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
