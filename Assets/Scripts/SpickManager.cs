using UnityEngine;

public class SpickManager : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float topSpeed = 1f;

    public float pause = 1f;

    Vector3 startPos;
    Vector3 endPos;

    bool isUp = true;

    float timer;

    private void Start()
    {
        startPos = transform.position;

        endPos = startPos + Vector3.up * topSpeed;
        timer = pause;

    }

    private void Update()
    {
        if (timer >  0) {
        timer -= Time.deltaTime;
            return;
        }
        Vector3 distance = isUp ? endPos : startPos;

        transform.position = Vector3.MoveTowards(transform.position ,distance,moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, distance) < 0.01f){
            isUp = !isUp;
            timer = pause;
        }

    }
}
