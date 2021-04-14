using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D  playerRb;

    public float         speed; // Velocidade
    public float         jumoForce; // Força do pulo  

    public bool          isLookLeft; // Virar player a esquerda

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();     
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

        if (Input.GetButtonDown("Jump")) // Pular
        {
            playerRb.AddForce(new Vector2(0, jumoForce));
        }

        playerRb.velocity = new Vector2(h * speed, speedY); // Movimentacao do player

    }

    void Flip()
    {
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1; // Inverte o sinal do X do Scale X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

}
