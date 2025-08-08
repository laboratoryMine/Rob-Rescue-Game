using UnityEngine;

public class SFXManager : MonoBehaviour
{
  public static SFXManager Instance;


    public AudioSource playerWalk;
    public AudioSource playerDamage;


    public AudioSource opendKey;
    public AudioSource specialKey;
    public AudioSource jailOpend;


    public AudioSource traps;



   
    private void Awake()
    {
        Instance = this;
    }
}
