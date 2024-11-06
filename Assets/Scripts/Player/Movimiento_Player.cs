using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Player : MonoBehaviour
{
    public float speed = 3f;
    Vector2 moveInput;

    private Rigidbody2D playerRB;
    private Animator animator;
    bool isAttackin;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()//manejo de fisicas
    {
        playerRB.velocity = moveInput * speed;
    }

    private void Update()
    {
        if (Time.timeScale!=0) {
            Movemen();
            Animations();
        }
    }

    private void Movemen()
    {
        if (isAttackin) return;

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;//normalized evita que se sumen las componentes del vector
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.PageUp))
        {
            animator.Play("Attack");
            isAttackin = true;
            AttackDirection();
        }
    }
    private void Animations()
    {
        if (isAttackin) return;
        if (moveInput.magnitude != 0) 
        { 
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
            animator.Play("Run"); 
        }
        else animator.Play("Idle");
    }
    private void AttackDirection()
    {
        moveInput.x=animator.GetFloat("Horizontal");
        moveInput.y=animator.GetFloat("Vertical");
        if (Mathf.Abs(moveInput.y) > Mathf.Abs(moveInput.x))
        {
            moveInput.x = 0;
        }else
        {
            moveInput.y = 0;
        }
        moveInput = moveInput.normalized;
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        moveInput = Vector2.zero;
    }
    private void EndAttack()
    {
        isAttackin = false;
    }
}
