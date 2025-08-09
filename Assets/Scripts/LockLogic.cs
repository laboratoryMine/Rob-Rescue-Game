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

    public void CheckAllLocks()
    {
        foreach (GameObject lockObj in alllocks)
        {


            LockLogic lockLogic = lockObj.GetComponent<LockLogic>();
            if (!lockLogic || !lockLogic.isUnlocked)
                return;
        }
        OpenJail();
        //SFX Here
    }

    void OpenJail()
    {
        if (jail != null)

            SFXManager.Instance.jailOpend.PlayDelayed(1f);
        jail.SetActive(false);
        if (finalLine != null)
        {
           
            GetComponent<UILogic>().Invoke("WinPage", 2f);
            finalLine.PlayNow();
        }

    }

}
