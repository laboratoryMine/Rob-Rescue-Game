using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public AudioClip line;

    public float coolDown = 3f;

    AudioSource audioS;

    public bool playOnlyOnce = false;
    bool canTrigger = true;
    bool hasPlayed = false;


    static bool isAnyLinePlaying = false;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        if(audioS == null)
        {

            audioS = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canTrigger)
        {
            if (playOnlyOnce && hasPlayed)
            {
              return;


            }
            TryToPlay();

        }
    }

    void TryToPlay()
    {
        if (playOnlyOnce && hasPlayed) return;
        if (isAnyLinePlaying) return; 
        StartCoroutine(PlayLine());
    }
    IEnumerator PlayLine()
    {
        canTrigger = false;
        hasPlayed = true;

        audioS.clip = line;
        isAnyLinePlaying = true;

        audioS.Play();
        yield return new WaitForSeconds(line.length);
        isAnyLinePlaying = false ;
        yield return new WaitForSeconds(coolDown);
   canTrigger = true;
    }

    public void PlayNow()
    {
        TryToPlay();
       
    }
}
