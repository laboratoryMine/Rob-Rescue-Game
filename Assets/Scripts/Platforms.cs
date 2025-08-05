using UnityEngine;

public class Platforms : MonoBehaviour
{

    public Transform pA;
    public Transform pB;

    public float speed = 5f;

    Vector3 startPos;
    private void Start()
    {
        startPos = pA.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position , startPos,speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, startPos) < 0.1f)
        {
            startPos = (startPos == pA.position)? pB.position : pA.position;
        }
    }
}
