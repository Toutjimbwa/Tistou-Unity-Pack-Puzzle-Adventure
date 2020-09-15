using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RJFly : MonoBehaviour
{
    public Vector3 _moveToHere;
    private void Start()
    {
        _moveToHere = transform.position;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, _moveToHere) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, _moveToHere, 0.1f);
        }
    }
    public void MoveTo(Vector3 position)
    {
        _moveToHere = position;
    }
}