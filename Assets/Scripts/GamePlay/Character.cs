using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Animator playerAnimator;

    public Transform groundCheck;
    private bool isGrounded;
    private int speedX;
    private float speedY;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
    
    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            speedX = 1;
        }
        else
        {
            speedX = 0;
        }

        speedY = playerRB.velocity.y;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
    }

    private void LateUpdate()
    {
        playerAnimator.SetInteger("speedX", speedX);
        playerAnimator.SetBool("isGrounded", isGrounded);
        playerAnimator.SetFloat("speedY", speedY);
        
    }
}
