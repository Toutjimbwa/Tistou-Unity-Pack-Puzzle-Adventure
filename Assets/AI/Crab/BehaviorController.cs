using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var testType = other.GetComponent<TestType>();
        if (testType)
        {
            Debug.Log(testType.type);
            //If type is fish, eat fish.


        }
    }
}
