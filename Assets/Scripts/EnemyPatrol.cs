using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public GameObject pA;
    public GameObject pB;

    public float speed = 5f;

    private void Start()
    {
        transform.LookAt(pA.transform);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed* Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pA) { 
        
        transform.LookAt(pB.transform);
        
        }if (other.gameObject == pB) {

            transform.LookAt(pA.transform);
        
        }
    }
}

