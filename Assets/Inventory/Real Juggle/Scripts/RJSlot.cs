using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RJSlot : MonoBehaviour
{
    public RJItem _item;
    private void OnEnable()
    {
        _item = GetComponentInChildren<RJItem>();
    }
    public RJItem GetItem()
    {
        return _item;
    }
    public void CatchInInventory(RJItem item)
    {
        if (item)
        {
            _item = item;
            item.transform.parent = transform;
            item.flyTo(transform.position);
        }
    }
    public void ReleaseInInventory()
    {
        if (_item)
        {
            _item.transform.parent = null;
            _item = null;
        }
    }
}
