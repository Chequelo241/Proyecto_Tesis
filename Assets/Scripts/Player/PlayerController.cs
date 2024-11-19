using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    Vector2 moveInput;
    bool isAttackin;

    bool isInvincible;
    float invincibilityTime = 0.7f;
    float blinkTime = 0.1f;

    bool unControllable;
    public float knockBackStrength = 10f;
    float knockBackTime = 0.5f;

    private Rigidbody2D playerRB;
    private Animator animator;
    SpriteRenderer spriteRenderer;

    BasicInteraction interaction;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()//manejo de fisicas
    {
        if (!unControllable) playerRB.velocity = moveInput * speed;
    }

    private void Update()
    {
        Inputs();
        Animations();
    }

    private void Inputs()
    {
        if (isAttackin ) return;

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.PageUp))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.PageDown) )
        {
            if (interaction!=null)
            {
                interaction.Interact();
            }else
            {
                Debug.Log("La interaccion esta vacia");
            }
        }
    }
    private void Animations()
    {
        if (isAttackin || Time.timeScale==0) return;
        if (moveInput.magnitude != 0) 
        { 
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
            animator.Play("Run"); 
        }
        else animator.Play("Idle");
    }
    private void Attack() 
    {
        animator.Play("Attack");
        isAttackin = true;
        AttackDirection();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BateriaG"))
        {
            GameManager.instance.SetPlayerXPToMax();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Bateria"))
        {
            GameManager.instance.SetPlayerXPToHalfMax();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("BateriaS"))
        {
            GameManager.instance.SetPlayerXPToQuarterMax();
            Destroy(collision.gameObject);
        } else if (collision.CompareTag("Interaction")) 
        {
            interaction = collision.GetComponent<BasicInteraction>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interaction"))
        {
            interaction =null;
        }
    }
    //mecanicas de nockback
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Enemy") && !isInvincible)
        {
            StartCoroutine(Invincibility());
            StartCoroutine(KnockBack(collision.transform.position));
        }
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        float auxtime = invincibilityTime;

        while (auxtime > 0)
        {
            yield return new WaitForSeconds(blinkTime);
            auxtime -= blinkTime;
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }

        spriteRenderer.enabled = true;
        isInvincible = false;
    }

    IEnumerator KnockBack(Vector3 hitPosition)
    {
        unControllable = true;
        moveInput = Vector2.zero;
        playerRB.velocity = (transform.position - hitPosition).normalized * knockBackStrength;
        yield return new WaitForSeconds(knockBackTime);
        playerRB.velocity = Vector3.zero;
        unControllable = false;

    }

}
