using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Kill")
        {
            Reload();
        }
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
