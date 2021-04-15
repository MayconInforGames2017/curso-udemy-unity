using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D  playerRb;
    private Animator     playerAnimator;

    public float         speed; // Velocidade
    public float         jumoForce; // Força do pulo  

    public bool          isLookLeft; // Virar player a esquerda

    public Transform     groundCheck;
    private bool         isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); 
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0 && isLookLeft == true)
        {
            Flip();
        }
        else if (h < 0 && isLookLeft == false)
        {
            Flip();
        }

        float speedY = playerRb.velocity.y;

        if (Input.GetButtonDown("Jump") && isGrounded == true) // Pular
        {
            playerRb.AddForce(new Vector2(0, jumoForce));
        }

        playerRb.velocity = new Vector2(h * speed, speedY); // Movimentacao do player

        playerAnimator.SetInteger("h", (int) h);

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
    }

    void Flip()
    {
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1; // Inverte o sinal do X do Scale X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

}
