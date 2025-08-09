using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    public UILogic uiLogic;
    public int damaged = 1;

    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Kill")
        {
            Reload();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hurt")
        {
            GetDamaged(damaged);

        }
    }

    public void GetDamaged(int damageamount)
    {
        uiLogic.TakeDamage(damageamount);
        SFXManager.Instance.playerDamage.Play();
      

        
    }
  public  void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
