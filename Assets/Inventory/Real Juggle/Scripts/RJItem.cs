using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RJItem : MonoBehaviour
{
    private RJFly FlyAbility;
    public Transform _model;
    public bool ModelIsUp = false;

    private void OnEnable()
    {
        if (!_model) _model = transform.Find("Model");
        if (!FlyAbility) FlyAbility = (RJFly)gameObject.AddComponent(typeof(RJFly));
        var slot = transform.parent.GetComponent<RJSlot>();
        if (slot)
        {
            flyTo(slot.transform.position);
            transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            FlyAbility.enabled = false;
        }
    }
    public void MoveModelUp()
    {
        if (!ModelIsUp)
        {
            var x = _model.position.x;
            var y = _model.position.y + 0.2f;
            var z = _model.position.z;
            _model.position = new Vector3(x, y, z);
            ModelIsUp = true;
        }
    }
    public void MoveModelDown()
    {
        if (ModelIsUp)
        {
            var x = _model.position.x;
            var y = _model.position.y - 0.2f;
            var z = _model.position.z;
            _model.position = new Vector3(x, y, z);
            ModelIsUp = false;
        }
    }
    public void PutIntoWorld()
    {
        GetComponent<Collider>().isTrigger = false;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        FlyAbility.enabled = false;
    }

    public void PutIntoInventory()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Collider>().isTrigger = true;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void flyTo(Vector3 position)
    {
        FlyAbility.MoveTo(position);
    }

    public void OpenInInventory()
    {
        FlyAbility.enabled = true;
    }

    public void CloseInInventory()
    {
        FlyAbility.enabled = false;
    }
}
