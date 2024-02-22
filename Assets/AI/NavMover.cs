using UnityEngine;
using UnityEngine.AI;

//Nav Mover: A script used to send commands to, and receive information from a Nav Mesh Agent
[RequireComponent(typeof(NavMeshAgent))]
public class NavMover : MonoBehaviour
{
    
    NavMeshAgent agent;
    private Vector3 destination;

    void Awake() => agent = GetComponent<NavMeshAgent>();
    // Start/Stop the movement of an agent
    public void StartMove()
    {
        if (agent.isOnNavMesh) agent.isStopped = false;
    }
    public void StopMove()
    {
        if (agent.isOnNavMesh) agent.isStopped = true;
    }
    //Give the agent a new destination
    public Vector3 Destination
    {
        get => destination;
        set
        {
            destination = value;
            if (agent.isOnNavMesh) agent.destination = value;
            StartMove();
        }
    }
    //the ratio of how fast the agent is moving compared to its maximum speed
    public float Speed
    {
        get => agent.velocity.magnitude / agent.speed;
    }
    //whether the agent has reached a specific destination
    public bool DestinationReached(Vector3 position, float stopRange = 1f)
    {
        if(position == destination)
        {
            if (agent.remainingDistance <= stopRange) return true;
        }
        return false;
    }
}
