using System.Runtime.CompilerServices;
using UnityEngine;

public class Rubble : MonoBehaviour
{


    public Material unlockedMat;

    MeshRenderer currentMat;

    public GameObject rubble;
    private void Awake()
    {

        currentMat = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //unlcok
          rubble.gameObject.SetActive(false);

            currentMat.material = unlockedMat;

            SFXManager.Instance.specialKey.Play();
            //SFX here 
        }
    }
}
