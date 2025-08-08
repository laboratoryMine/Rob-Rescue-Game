using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMAinScene : MonoBehaviour
{



   
    private void Awake()
    {
    }
    public string nextScene;


    public void Play()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
