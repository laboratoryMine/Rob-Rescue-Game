using UnityEngine;

public class StaticDamage : MonoBehaviour
{

    int damage = 1;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            PlayerInteract player = FindFirstObjectByType<PlayerInteract>();
            player.GetDamaged(damage);
        }
    }
}
