using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTHand : MonoBehaviour
{
    public JTItem _item;
    public JTSlot _slot;
    public JTItem GetItem()
    {
        return _item;
    }

    public void PickUp(JTItem item)
    {
        _item = item;
        item.transform.parent = transform;
        item.transform.localPosition = new Vector3(0, 1.55f, 0);
    }

    public void Drop(JTItem item)
    {
        if (item)
        {
            if (item.Equals(_item))
            {
                item.transform.parent = null;
                _item = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var slot = other.GetComponent<JTSlot>();
        if (slot)
        {
            _slot = slot;
        }
    }
}