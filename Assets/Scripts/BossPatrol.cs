using UnityEngine;
using UnityEngine.AI;

public class BossPatrol : MonoBehaviour
{
  
    public NavMeshAgent agent;

    public Transform[] patrolPos;


    int currentPosindex;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetDistance();
        }
        
       
    }

    void SetDistance()
    {
        if (patrolPos.Length == 0) return;

        int newpos;
        do
        {
            newpos = Random.Range(0,patrolPos.Length);

        }while (newpos == currentPosindex && patrolPos.Length > 1);

        currentPosindex = newpos;

        agent.SetDestination(patrolPos[currentPosindex].position);
    }
}
