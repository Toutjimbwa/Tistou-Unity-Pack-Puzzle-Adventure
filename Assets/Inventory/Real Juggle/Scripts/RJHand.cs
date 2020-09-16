using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RJHand : RJSlot
{
    public void PickUp(RJItem item)
    {
        if (item)
        {
            _item = item;
            _item.PutIntoInventory();
            item.transform.parent = transform;
            item.transform.localPosition = new Vector3(0, 0, 0);
            item.MoveModelDown();
        }
    }
    public void Drop()
    {
        if (_item)
        {
            _item.transform.parent = null;
            _item.PutIntoWorld();
            _item = null;
        }
    }
}