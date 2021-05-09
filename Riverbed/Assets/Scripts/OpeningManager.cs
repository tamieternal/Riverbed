using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class OpeningManager : MonoBehaviour
{


    private PlayableDirector director;

    public bool IsTitleFaded = false;

    public AudioSource seAudioSource;
    public AudioClip seAudioClip;

    // Start is called before the first frame update
    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        director.stopped += DirectorStopped;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && IsTitleFaded)
        {
            seAudioSource.PlayOneShot(seAudioClip);
            director.Play();
            IsTitleFaded = false;
            
        }
        if (director.time == director.duration )
        {
            director.Stop();
        }

        
    }

    private void DirectorStopped(PlayableDirector obj)
    {
        
        SceneManager.LoadScene("MainScene");

    }

   
    
    
}
