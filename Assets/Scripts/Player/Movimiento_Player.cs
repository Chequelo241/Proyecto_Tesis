using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Player : MonoBehaviour
{
    public float speed = 3f;
    Vector2 moveInput;

    private Rigidbody2D playerRB;
    private Animator animator;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()//manejo de fisicas
    {
        playerRB.velocity = moveInput * speed;
    }

    private void Update()//manejo de entradas
    {
        if (Time.timeScale!=0) {
            Movemen();
            Animations();
        }
    }

    private void Movemen()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;//.normalized es para normalizar el vector y que no se sumen las componentes del mismo (evitar movimiento mas rapido en diagonal)
    }
    private void Animations()
    {
        if (moveInput.magnitude != 0) 
        { 
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
            animator.Play("Run"); 
        }
        else animator.Play("Idle");
        
    }
}
