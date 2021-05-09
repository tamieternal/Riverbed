using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeOut : MonoBehaviour
{
    AudioSource audioSource;
    
    public double FadeOutSecounds = 1.0;

    public bool IsFadeOut = false;
    double FadeDeltaTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFadeOut)
        {
            FadeDeltaTime += Time.deltaTime;
            if (FadeDeltaTime == FadeOutSecounds)
            {
                FadeDeltaTime = FadeOutSecounds;
                IsFadeOut = false;
            }

            audioSource.volume = (float)(1.0 - FadeDeltaTime / FadeOutSecounds);
        }
    }

    public void ChangeIsFadeOut()
    {
        IsFadeOut = !IsFadeOut;
    }
}
