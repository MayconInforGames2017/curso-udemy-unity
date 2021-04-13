using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D  playerRb;

    public float         speed; // Velocidade
    public float         jumoForce; // Força do pulo    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
