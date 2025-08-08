using UnityEngine;
using UnityEngine.AI;

public class BossPatrol : MonoBehaviour
{

    public NavMeshAgent agent;

    public Transform[] patrolPos;

    public Transform player;

    int currentPosindex;

 
    public enum BossState
    {

        Patrol, Chase

    }


    public float chaseRange = 10f;

    BossState currentState;


    Animator anim;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        currentState = BossState.Patrol;
        anim.SetBool("Walk", true);

    }

    private void Update()
    {
        switch (currentState) { 
        
            case BossState.Patrol:
                PatrolUpdate();
                break;
                case BossState.Chase:
                ChaseStart();
                break;
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
    void PatrolUpdate()
    {
        anim.SetBool("Walk", true);
        if (!agent.pathPending && agent.remainingDistance < 0.8f)
        {

            SetDistance() ;

        }

        if(Vector3.Distance(transform.position,player.position) <= chaseRange)
        {
            currentState = BossState.Chase;
            ChaseStart();
        }

        if(agent.velocity.magnitude < 0.1f)
        {
            anim.SetBool("Walk",true);
        }
    }

  
    void ChaseStart()
    {
        anim.SetBool("Walk", true);
        agent.SetDestination(player.position);

        if(Vector3.Distance(transform.position,player.position)> chaseRange* 1.5f)
        {
            currentState = BossState.Patrol;
            SetRandomDistination();


        }
    }

    void SetRandomDistination()
    {
        if(patrolPos.Length ==0) return;
        int newpos;

        do
        {
            newpos = Random.Range(0, patrolPos.Length);

        }while(newpos == currentPosindex && patrolPos.Length >1);

        currentPosindex = newpos;
        agent.SetDestination(patrolPos[currentPosindex].position);


    }
}
