using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField]
   float moveSpeed;
   [SerializeField]
   float jumpForce;
   Rigidbody2D rb2D;

   GameInputs gameInputs;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        gameInputs = new GameInputs();
    }

    void Start() 
    {
        gameInputs.Land.Jump.performed += _=> Jump();    
    }

    void OnEnable()
    {
        gameInputs.Enable();    
    }

    void OnDisable() 
    {
        gameInputs.Disable();    
    }

    void FixedUpdate() 
    {
        Movement();
    }

    void Movement()
    {
        rb2D.position += DirectionX * Time.deltaTime;
    }

    void Jump()
    {
        rb2D.AddForce(JumpDir, ForceMode2D.Impulse);
    }

    Vector2 DirectionX => Vector2.right * Axis.x * moveSpeed;

    Vector2 JumpDir => Vector2.up * jumpForce;

    Vector2 Axis => gameInputs.Land.Move.ReadValue<Vector2>();

}