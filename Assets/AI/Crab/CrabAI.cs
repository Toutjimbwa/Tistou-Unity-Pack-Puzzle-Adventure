using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabAI : MonoBehaviour
{
    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * WalkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, WalkRadius, 1);
        Vector3 finalPosition = hit.position + Vector3.up * 4;

        Destination = Instantiate(positionPrefab);
        Destination.transform.position = finalPosition;
        Destination.name = "Destination";

        _navMeshAgent.SetDestination(finalPosition);
        
        _walking = true;
    }
    private void Update()
    {
        if (Random.value < 0.01)
        {
            Destroy(Destination);
            _walking = false;
        }
        if (_walking) return;
        SetRandomDestination();
        
    }
    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public MonoBehaviour _food;
    public float WalkRadius = 20;
    public GameObject Danger;
    public GameObject Destination;
    public GameObject positionPrefab;

    NavMeshAgent _navMeshAgent;
    public bool _walking = false;
}
