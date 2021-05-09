using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    public Animator titleAnimator;

    public GameObject goWalkText;

    public OpeningManager openingManager;


    

    public void GoWalkTextActive()
    {
        goWalkText.SetActive(true);
    }

    public void FadeOutEnd()
    {
        openingManager.IsTitleFaded = true;
    }
}
