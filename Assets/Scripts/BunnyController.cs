using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunnyController : MonoBehaviour
{

    private Rigidbody2D playerRBody;
    private GameController _gameController;

    [Header( "Bunny Settings")]
    public float jump;
    private bool isNotJumping;
    public Transform groundCheck;    
    public float playerSpeedMovement;

    void Start()
    {
        playerRBody=GetComponent<Rigidbody2D>();
        _gameController = FindObjectOfType<GameController>() as GameController;

    }

    
    void Update()
    {
        playerJump();
        //playerMovement();
    }
    void FixedUpdate()
    {
        isNotJumping = Physics2D.OverlapCircle(groundCheck.position,0.02f);
    }

    void playerJump()
    {
       
        if(Input.GetButtonDown("Jump") && isNotJumping == true)
        {
            playerRBody.AddForce(new Vector2 (0,jump));            
        }
    }
    void playerMovement()
    {
        float posX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Horizontal"))
        {
            playerRBody.velocity = new Vector2(posX * playerSpeedMovement, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       switch(collision.gameObject.tag)
        {
            case "Collectible":
                _gameController.scoring(2);
                Destroy(collision.gameObject);
            break;

            case "Obstacle":
                _gameController.changeScene("map_gameover");
            break;
        }
        

    }
}
