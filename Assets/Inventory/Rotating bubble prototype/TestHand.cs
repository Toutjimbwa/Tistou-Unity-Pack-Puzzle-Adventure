using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHand : MonoBehaviour
{
    public TestItem _item;
    public TestItem GetItem()
    {
        return _item;
    }

    public void ClearHand()
    {
        _item = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponentInChildren<TestItem>();
        if (item)
        {
            _item = item;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var item = other.GetComponentInChildren<TestItem>();
        if (item)
        {
            if (item.Equals(_item))
            {
                _item = null;
            }
        }
    }
}