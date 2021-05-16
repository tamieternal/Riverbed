using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public float speed;
    public bool walkToRight;
    
    private Vector3 directionVector;
    private Transform myTransform;
    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;

    private PlayerMove playerMove;

    public float tempSpeed;

    public int maxPosX;
    public int minPosX;

    //Todo Animationの動作仕組み解析する
    //===================================================================================================
    private void Awake()
    {
        NPCGenerator.get();
        playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        myAnimator = GetComponent<Animator>();
        UpdateAnimation();

    }

    private void OnEnable()
    {
        
        JudgeDirection();
        Debug.Log("JudgeDirection: directionVector = " + directionVector);
        myAnimator.SetBool("moving", true);
        UpdateAnimation();
    }

    private void Update()
    {
        
        Move();
        Deactive();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger && playerMove.lookingNPC == this.gameObject)
        {
            myAnimator.SetBool("moving", false);
            directionVector = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger && !(speed == 0) && playerMove.lookingNPC == null)
        {
            playerMove.lookingNPC = this.gameObject;
            tempSpeed = speed;
            speed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger && playerMove.lookingNPC == this.gameObject)
        {
            playerMove.lookingNPC = null;
            myAnimator.SetBool("moving", true);
            speed = tempSpeed;
            JudgeDirection();
            UpdateAnimation();
        }
    }

    //===================================================================================================

    private void Move()
    {
        
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        myRigidbody2D.MovePosition(temp);
    }

    private void UpdateAnimation()
    {

        myAnimator.SetFloat("moveX",directionVector.x);
    }

    private void JudgeDirection()
    {
        if (walkToRight)
            directionVector = Vector3.right;
        else
            directionVector = Vector3.left;
    }

    private void Deactive()
    {
        if (transform.position.x < -34 || 34 < transform.position.x)
        {
            this.gameObject.SetActive(false);
            NPCGenerator.instance.GetInactiveNPC(this.gameObject);
        }
    }


}