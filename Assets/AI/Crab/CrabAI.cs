using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabAI : MonoBehaviour
{
    public void EnableAgentControl()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.useGravity = false;
        _dontMoveAgent = false;
    }
    public void DisableAgentControl()
    {
        _dontMoveAgent = true;
        if (_destination) Destroy(_destination);
        _navMeshAgent.ResetPath();
        _rigidbody.useGravity = true;
    }
    void SetRandomDestination()
    {
        if (_dontMoveAgent) return;
        Vector3 randomDirection = Random.insideUnitSphere * WalkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, WalkRadius, 1);
        Vector3 finalPosition = hit.position + Vector3.up * 4;

        if (ShowDestination)
        {
            _destination = Instantiate(positionPrefab);
            _destination.transform.position = finalPosition;
            _destination.name = "Destination";
        }

        _navMeshAgent.SetDestination(finalPosition);
    }
    private void Update()
    {
        if (_groundCheck.IsGrounded)
        {
            if (_dontMoveAgent)
            {
                EnableAgentControl();
            }
            if (NewDestinationTimer < 0f)
            {
                if (_destination) Destroy(_destination);
                SetRandomDestination();
                NewDestinationTimer = Random.Range(1f, NewDestinationTimerLimit);
            }
            NewDestinationTimer -= Time.deltaTime;
        }
    }
    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();
        _groundCheck = GetComponent<GroundCheck>();
    }

    public bool ShowDestination = false;
    public float WalkRadius = 20;
    GameObject _destination;
    public GameObject positionPrefab;
    public float NewDestinationTimerLimit = 1f;
    public float NewDestinationTimer = -1f;

    NavMeshAgent _navMeshAgent;
    Rigidbody _rigidbody;
    bool _dontMoveAgent = false;
    GroundCheck _groundCheck;
}
