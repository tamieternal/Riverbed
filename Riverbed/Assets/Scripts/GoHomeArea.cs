using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHomeArea : MonoBehaviour
{
    public bool canGoHome = false;


    public bool isPrologue = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            canGoHome = true;
            other.GetComponent<PlayerMove>().canWalk = false;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPrologue = false;

        if (other.CompareTag("Player") && !other.isTrigger)
        {
            canGoHome = false;
            

        }
    }
}
