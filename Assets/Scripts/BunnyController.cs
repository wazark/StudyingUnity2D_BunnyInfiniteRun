using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{

    private Rigidbody2D playerRbody;
    public float jump;
    void Start()
    {
        playerRbody=GetComponent<Rigidbody2D>();

    }

    
    void Update()
    {
        playerJump(); 
    }

    void playerJump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            playerRbody.AddForce(new Vector2 (0,jump));
        }
    }
}
