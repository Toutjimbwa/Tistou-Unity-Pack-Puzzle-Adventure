using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    void RunCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, DistanceToGround))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
    private void Update()
    {
        RunCheck();
    }

    public float DistanceToGround = 1f;
    public bool IsGrounded = false;
}