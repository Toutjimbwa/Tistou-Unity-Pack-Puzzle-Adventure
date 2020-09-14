using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOnTriggerEnter : MonoBehaviour
{
    public string food = "none";
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        TestType otherType = other.GetComponent<TestType>();
        if (otherType.type.Equals(food))
        {
            Debug.Log("Eat" + food);
            Destroy(other);
        }
    }
}
