using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody2D = default;
    private Vector3 change = default;
    private Animator animator = default;
    public float MaxYPos;
    public float MinYPos;
    public float MaxXPos;
    public float MinXpos;

    public GameObject lookingNPC;

    public bool canWalk = false;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", -1);

    }

    private void Update()
    {
        change = Vector3.zero;

        if (canWalk)
        { 
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        }

        if ((transform.position.y >= MaxYPos && change.y >=0) ||
            (transform.position.y <= MinYPos && change.y <= 0))
        {
            change.y = 0;
        }
        if((transform.position.x >= MaxXPos && change.x >= 0) ||
            (transform.position.x <= MinXpos && change.x <= 0))
        {
            change.x = 0;
        }

        AnimationAndMove();
    }


    private void AnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            Move();
            animator.SetFloat("moveX", change.x);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    private void Move()
    {
        myRigidbody2D.MovePosition(transform.position + change * speed * Time.deltaTime);

        
    }

    public void ChangeCanWalk()
    {
        canWalk = !canWalk;
    }

    
}
