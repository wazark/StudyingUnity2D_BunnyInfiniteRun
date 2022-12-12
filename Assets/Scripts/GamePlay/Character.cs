using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Animator playerAnimator;
    private SpriteRenderer playerRenderer;
    private GameController _gameController;
    
    
    private bool isGrounded;
    private int speedX;
    private float speedY;
    private int extraJump;
    private bool isShooting;

    [Header("Objects with Interaction")]
    public Transform groundCheck;
    public Transform carrotLaunchPosition;
    public LayerMask whatIsGround;
    public GameObject carrotsBullet;


    [Header("Character Settings")]
    public float speedMove;
    public float jumpForce;
    public bool isFaceLeft;
    public int jumpPlus;
    public float strenght;
    
    

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;

        extraJump = jumpPlus;
    }
    
    void Update()
    {
        Locomotion();        
    }

    private void FixedUpdate()
    {
        // faz com que a variavel bool ao ter contato com box collider do chão se torne verdadeira. Para isto ela cria um raio de 0.02f para verificar o contato do chão com o transform criado no player.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround); 
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
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal !=0)        
        {
            speedX = 1;            
        }
        else 
        {
            speedX = 0;            
        }
        if(isFaceLeft == true && horizontal > 0)
        {
            flipCharacter();
        }
        if(isFaceLeft == false && horizontal < 0)
        {
            flipCharacter();
        }
        

        // a variável speedY receberá os valores da movimentação do rigidbody2D no eixo Y.
        speedY = playerRB.velocity.y;

        // faz a movimentação do personagem no eixo X.
        playerRB.velocity = new Vector2(horizontal * speedMove, speedY);

        doubleJump();

        // Atira cenouras
        if (Input.GetButtonDown("Fire1") && _gameController.carrotBullet > 0 && isShooting == false)
        {
            fireCarrot();
        }


    }

    // Função responsável por virar o personagem
    void flipCharacter()
    {
        isFaceLeft = !isFaceLeft;
        float x = transform.localScale.x;
        x *= -1; //inverte o sinal do scale;
        strenght *= -1; // inverte a força do tiro para ir do lado oposto.

        transform.localScale= new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
    //Função responsável pelo pulo do personagem.
    public void jump()
    {
        playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
        playerRB.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
       
    }
    //Função responsável pelo pulo duplo do jogador (caso a variável extra jump seja maior que 1).
    void doubleJump()
    {

        if (isGrounded == true)
        {
            extraJump = jumpPlus;
        }
        if (Input.GetButtonDown("Jump") && extraJump > 0) // caso tenha o double jump, diminui o pulo extra a cada ação de jump no ar.
        {
            jump();
            extraJump--;
            _gameController.sfxSource.PlayOneShot(_gameController.sfxJump);
        }
        else if (Input.GetButtonDown("Jump") && extraJump == 0 && isGrounded == true) // caso não tenha double jump.
        {
            jump();
            _gameController.sfxSource.PlayOneShot(_gameController.sfxJump);
        }
    }
    //função resposável por instanciar o objeto e move-lo.
    void fireCarrot()
    {
        _gameController.sfxSource.PlayOneShot(_gameController.sfxFireCarrot);
        isShooting = true;
        _gameController.currentAmmo(-1);
        GameObject temp = Instantiate(carrotsBullet);
        temp.transform.position = carrotLaunchPosition.position;
        temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(strenght, 0));
        StartCoroutine("shootDelay");

        Destroy(temp, 1f);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag) 
        {
            case "Collectible":
                
                IDCollectible iDC = collision.gameObject.GetComponent<IDCollectible>();                

                switch (iDC.itemName)
                {
                    case "carrot":                        
                        _gameController.currentAmmo(iDC.amountAmmo);
                        _gameController.scoring(iDC.amountScore);

                        break;

                    case "egg":

                        _gameController.currentAmmo(iDC.amountAmmo);
                        _gameController.scoring(iDC.amountScore);

                        break;

                }

                Destroy(collision.gameObject);

                break;


            case "Obstacle":

                SceneManager.LoadScene("map_gameover");
                break;
        }
    }
    IEnumerator shootDelay()
    {
        yield return new WaitForSeconds(_gameController.shootDelay);
        isShooting= false;
    }
}
