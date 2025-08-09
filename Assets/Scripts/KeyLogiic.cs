using UnityEngine;

public class KeyLogiic : MonoBehaviour
{
   
    public Material lockMat;

    public Material unlockedMat;

    MeshRenderer currentMat;
    public LockLogic lockToOpen;
    public LockLogic lockManager;

    bool isOpenned;

    public UILogic uiLogic;

    public Dialog finalLine;
    private void Start()
    {
   
        currentMat = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(isOpenned) return;

        if (other.CompareTag("Player"))
        {
            //unlcok
            lockToOpen.Unlocked();
            currentMat.material = unlockedMat;
            isOpenned = true;

            SFXManager.Instance.opendKey.Play();

           lockManager.CheckAllLocks();

           // finalLine.gameObject.SetActive(false);
          //  SFXManager.Instance.jailOpend.PlayDelayed(1f);
         
            //SFX here 
        }

        
    }


}
