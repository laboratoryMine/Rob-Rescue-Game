using UnityEngine;

public class LockLogic : MonoBehaviour
{

    public Material green;

    MeshRenderer mat;

    bool isUnlocked;



    //check
    public GameObject[] alllocks;
    public GameObject jail;
    public Dialog finalLine;
    public UILogic uiLogic;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>();
    }
    public void Unlocked()
    {
        if (isUnlocked) return;
        mat.material = green;


        isUnlocked = true;

        //sound here

    }

    public bool CheckAllLocks()
    {
        foreach (GameObject lockObj in alllocks)
        {


            LockLogic lockLogic = lockObj.GetComponent<LockLogic>();
            if (!lockLogic || !lockLogic.isUnlocked)
                return false;
        }
        OpenJail();
        return true;
       
     

    }

    void OpenJail()
    {
      

            SFXManager.Instance.jailOpend.Play();
        jail.gameObject.SetActive(false);



        uiLogic.winPage.gameObject.SetActive(true);
      //  finalLine.PlayNow();

        SFXManager.Instance.finalLine.Play();

    }

}
