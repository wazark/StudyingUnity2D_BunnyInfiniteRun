using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BunnyController : MonoBehaviour
{
    private Rigidbody2D playerRBody;
    private GameController _gameController;
    private SpriteRenderer playerRenderer;
    private bool isNotJumping;
    public Transform groundCheck;
    public float gravityTime;
    public float gravityScaleToDown;
    

    void Start()
    {
        playerRBody=GetComponent<Rigidbody2D>();
        _gameController = FindObjectOfType<GameController>() as GameController;
        playerRenderer = GetComponent<SpriteRenderer>();

    }

    
    void Update()
    {
        playerJump();
        playerMovement();
        
        if(isNotJumping == true)
        {
            playerRBody.gravityScale = 1;
        }

    }
    void FixedUpdate()
    {
        isNotJumping = Physics2D.OverlapCircle(groundCheck.position,0.02f);
    }
    
    void setGravity()
    {
        playerRBody.gravityScale = gravityScaleToDown;
    }
    
    void playerJump()
    {
       
        if(Input.GetButtonDown("Jump") && isNotJumping == true)
        {
            Invoke(nameof(setGravity), gravityTime);
            playerRBody.AddForce(new Vector2 (0, _gameController.jump), ForceMode2D.Impulse);
            
        }
    }
    void playerMovement()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * _gameController.runSpeed;
        
        //flip player.
        if(movement < 0)
        {
            playerRenderer.flipX= true;
            
        }
        else if(movement > 0) 
        {
            playerRenderer.flipX= false;
            
        }

        float posX = transform.position.x;
        float posY = transform.position.y;
       
        //limit where the player can go.
        if (transform.position.x > _gameController.limitMaxX)
        {
            posX = _gameController.limitMaxX;
        }
        else if (transform.position.x < _gameController.limitMinX)
        {
            posX = _gameController.limitMinX;
        }

        transform.position = new Vector3(posX,posY,0);

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
