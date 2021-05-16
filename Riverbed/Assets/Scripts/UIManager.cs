using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject goHomeAreaGO;
    public GameObject GoHomeUI;

    public PlayerMove playerMove;


    private GoHomeArea goHomeArea;

    public Animator blackPlaneAnim;
    public AudioFadeOut audioFadeOut;



    private void Start()
    {
        goHomeArea = goHomeAreaGO.GetComponent<GoHomeArea>();
    }

    private void Update()
    {
        if (goHomeArea.canGoHome && !goHomeArea.isPrologue)
        {
            GoHomeUI.SetActive(true);
        }
        else
        {
            GoHomeUI.SetActive(false);
        }
        
    }


    public void InactiveGoHome()
    {
        goHomeArea.canGoHome = false;
        playerMove.canWalk = true;

    }

    public void GoHome()
    {
        playerMove.GoingHome = true;
        StartCoroutine(WaitFadeOutCo());
    }

    IEnumerator WaitFadeOutCo()
    {
        blackPlaneAnim.SetBool("IsFadeOut", true);
        audioFadeOut.IsFadeOut = true;
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("TitleScene");

    }

}
