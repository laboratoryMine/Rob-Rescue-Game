using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
  
    public Slider[] Hp;

    public Image damageEffect;


    public GameObject pauseMenue;
    public GameObject textFlicker;
    int currentHp;


    public string sceneName;

    Coroutine flicker;
    private void Awake()
    {
        currentHp = Hp.Length;

        UpdateSliders();
          damageEffect.color = damageEffect.color.WithAlpha(0f);

        pauseMenue.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, Hp.Length);
        UpdateSliders();
        Debug.Log("TakeDamage called with damage: " + damage);

        StartCoroutine(DamageEffect());

        if (currentHp <= 0) { 
        //i couild have taken the the one in the playerInteract but yeah :D
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void UpdateSliders()
    {

        for (int i = 0; i < Hp.Length; i++) {
            Hp[i].value = i< currentHp ? 1f : 0f;
        
        
        }
    }
    IEnumerator DamageEffect()
    {
        float fadeInTime = 0.1f;
        float timer = 0f;


        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 0.6f, timer / fadeInTime);
            damageEffect.color = damageEffect.color.WithAlpha(alpha);
            yield return null;
        }

        damageEffect.color = damageEffect.color.WithAlpha(0.6f);

        float fadeOutTime = 0.5f;
        timer = 0f;

       
        while (timer < fadeOutTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0.6f, 0f, timer / fadeOutTime);
            damageEffect.color = damageEffect.color.WithAlpha(alpha);
            yield return null;
        }

        damageEffect.color = damageEffect.color.WithAlpha(0f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (pauseMenue.activeSelf) { 
            
            ClosePage();
            }
            else
            {
                Pause();
            }
        
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenue.SetActive(true);

        if(flicker == null)
        {
            flicker = StartCoroutine(Flickring());
        }


    }

    IEnumerator Flickring()
    {
        while (true)
        {

            textFlicker.SetActive(false);
            yield return new WaitForSecondsRealtime(0.2f);

            textFlicker.SetActive(true);
            yield return new WaitForSecondsRealtime(0.5f);


            textFlicker.SetActive(false);
            yield return new WaitForSecondsRealtime(0.5f);

            textFlicker.SetActive(true);
            yield return new WaitForSecondsRealtime(0.5f);

        }

    }

    public void ClosePage()
    {
        pauseMenue.SetActive(false);
        Time.timeScale = 1f;

        if(flicker != null)
        {
            StopCoroutine(flicker);
            flicker = null;
        }
        textFlicker.SetActive(true) ;
    }
    public void ExitToMenu()
    {

        SceneManager.LoadScene(sceneName);
    }
}
