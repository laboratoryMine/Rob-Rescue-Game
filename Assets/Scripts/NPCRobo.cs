using UnityEngine;

public class NPCRobo : MonoBehaviour
{


    public GameObject playerPos;


    private void Update()
    {
        transform.LookAt(playerPos.transform.position);
    }
}
