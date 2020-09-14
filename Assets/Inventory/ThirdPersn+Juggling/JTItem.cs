using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTItem : MonoBehaviour
{
    public Transform _model;
    private void Start()
    {
        _model = transform.Find("Model");
    }
    public void MoveModelUp()
    {
        var x = _model.position.x;
        var y = _model.position.y + 0.2f;
        var z = _model.position.z;
        _model.position = new Vector3(x, y, z);
    }
    public void MoveModelDown()
    {
        var x = _model.position.x;
        var y = _model.position.y - 0.2f;
        var z = _model.position.z;
        _model.position = new Vector3(x, y, z);
    }
}
