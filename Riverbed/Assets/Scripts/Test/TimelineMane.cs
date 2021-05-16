using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineMane : MonoBehaviour
{
    public PlayableDirector director;

    public PlayableAsset pa1;
    public PlayableAsset pa2;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        director.playableAsset = pa1;
        director.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            director.playableAsset = pa2;
            director.Play();
        }
    }
}
