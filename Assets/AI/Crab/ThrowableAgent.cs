using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThrowableAgent : MonoBehaviour
{
    private void OnEnable()
    {
        _groundCheck = GetComponent<GroundCheck>();
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _navMeshAgent.isStopped = true;
            _navMeshAgent.ResetPath();
            float x = transform.position.x;
            float y = transform.position.y + 3f;
            float z = transform.position.z;
            transform.position = new Vector3(x, y, z);
        }
        if (!_groundCheck.IsGrounded)
        {
            _rigidbody.useGravity = true;
        }
        else
        {
            Debug.Log($"Velocity: {_rigidbody.velocity}");
            if (_rigidbody.velocity.magnitude > 0f)
            {
                if (Random.value < 0.5f)
                {
                    _rigidbody.velocity = Vector3.zero;
                }
            }
            _rigidbody.useGravity = false;
        }
    }

    GroundCheck _groundCheck;
    Rigidbody _rigidbody;
    NavMeshAgent _navMeshAgent;
}
