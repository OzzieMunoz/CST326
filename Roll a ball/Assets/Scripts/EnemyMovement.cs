using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    
    private NavMeshAgent  navMeshAgent;
    private bool isAwake = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (!isAwake && distance < 10f)
        {
            Aggro();
        }

        if (isAwake)
        {
            navMeshAgent.SetDestination(player.position);
        }
        
    }
    
    void Aggro()
    {
        isAwake = true;
        navMeshAgent.isStopped = false;
    }
}
