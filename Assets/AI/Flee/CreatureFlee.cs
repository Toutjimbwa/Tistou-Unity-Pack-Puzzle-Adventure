using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureFlee : MonoBehaviour
{

    private NavMeshAgent _agent;
    public GameObject Player;
    public float EnemyDistanceRun = 2f;
    public float distanceToPlayer;

    public enum State
    {
        Idle,
        Flee
    }
    public State state = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if(distanceToPlayer < EnemyDistanceRun)
        {
            state = State.Flee;
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            _agent.SetDestination(newPos);
        }
        else
        {
            state = State.Idle;
            _agent.SetDestination(transform.position);
        }
    }
}
