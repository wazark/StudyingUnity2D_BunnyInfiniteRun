using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Animator playerAnimator;
    private SpriteRenderer playerRenderer;

    public Transform groundCheck;
    private bool isGrounded;
    private int speedX;
    private float speedY;
    public float speedMove;
    public float jumpForce;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        Locomotion();
        
    }

    private void FixedUpdate()
    {
        // faz com que a variavel bool ao ter contato com box collider do chão se torne verdadeira. Para isto ela cria um raio de 0.02f para verificar o contato do chão com o transform criado no player.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f); 
    }

    private void LateUpdate()
    {
        // Define os valores do Animator conforme os valores das variaveis criadas aqui.
        playerAnimator.SetInteger("speedX", speedX);
        playerAnimator.SetBool("isGrounded", isGrounded);      
        playerAnimator.SetFloat("speedY", speedY);        
    }

    void Locomotion()
    {
        
        // define o valor da variavél speedX conforme a movimentação, esta variavel passará os valores para o Animator
        // vira o sprite render do personagem conforme o lado que esta se movendo e ao parar, permanece virado para o lado da ultima movimentação.
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal < 0)
        {
            speedX = -1;
            playerRenderer.flipX = true;
        }
        else if(horizontal > 0)
        {
            speedX = 1;
            playerRenderer.flipX = false;
        }
        else if (horizontal == 0) 
        {
            speedX = 0;
        }

        // a variável speedY receberá os valores da movimentação do rigidbody2D no eixo Y.
        speedY = playerRB.velocity.y;

        // faz a movimentação do personagem no eixo X.
        playerRB.velocity = new Vector2(horizontal * speedMove, speedY);
        
        
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            playerRB.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse );
        }
        
    }
}
