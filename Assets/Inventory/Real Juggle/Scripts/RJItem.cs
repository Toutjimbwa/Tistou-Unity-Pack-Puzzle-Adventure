using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RJItem : MonoBehaviour
{
    private RJFly FlyAbility;
    private void Start()
    {
        FlyAbility = (RJFly)gameObject.AddComponent(typeof(RJFly));
    }
    public void PutIntoWorld()
    {
        GetComponent<Collider>().isTrigger = false;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void PutIntoInventory()
    {
        GetComponent<Collider>().isTrigger = true;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void flyTo(Vector3 position)
    {
        FlyAbility.MoveTo(position);
    }
}
