using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeAndPatrol : EnemyHealth
{
    [Header("Layer Mask")]
    public LayerMask collisionLayer;
    [Header("Patrol Parameters")]
    public float speed;
    public float minPatrolTime;
    public float maxpatrolTime;
    public float minWaitTime;
    public float maxWaitTime;

    Animator animator;
    Vector2 direction;

    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        StartCoroutine(Patrol());
    }
    IEnumerator Patrol()
    {
        direction = RandomDirection();
        Animations();
        yield return new WaitForSeconds(Random.Range(minPatrolTime, maxpatrolTime));
        direction = Vector2.zero;
        Animations();
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        StartCoroutine(Patrol());
    }

    private Vector2 RandomDirection()
    {
        int x = Random.Range(0, 8);
        return x switch
        {
            0 => Vector2.up,
            1 => Vector2.down,
            2 => Vector2.left,
            3 => Vector2.right,
            4 => new Vector2(1, 1),
            5 => new Vector2(1, -1),
            6 => new Vector2(-1, 1),
            _ => new Vector2(-1, -1),
        };
    }
    private void Animations()
    {
        if (direction.magnitude != 0)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.Play("Run");
        }
        else animator.Play("Idle");
        RigidBody.velocity = speed * direction.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("un enemigo choco con el jugador");
            StopBehaviour();
            Flee();
        }
    }

    private void Flee()
    {
        Vector2 fleeDirection = FindSafeDirection();
        if (fleeDirection != Vector2.zero)
        {
            direction = fleeDirection;
            Animations();
        }
        StartCoroutine(ResumePatrolAfterDelay());
    }

    private Vector2 FindSafeDirection()
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right, new Vector2(1, 1), new Vector2(1, -1), new Vector2(-1, 1), new Vector2(-1, -1) };
        float rayDistance = 1.0f;
        foreach (Vector2 dir in directions) 
        { 
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, rayDistance, collisionLayer); 
            Debug.DrawRay(transform.position, dir * rayDistance, hit.collider == null ? Color.green : Color.red); 
            if (hit.collider == null) { Debug.Log("Se encontró una dirección segura: " + dir); return dir; } 
        }
        Debug.Log("No se encontró ninguna dirección segura"); return Vector2.zero;
    }

    private IEnumerator ResumePatrolAfterDelay()//corrutina que reinicia el comportamiento de patruya del enemigo
    {
        yield return new WaitForSeconds(1.0f);
        ContinueBehaviour();
    }

    public override void StopBehaviour()
    {
        StopAllCoroutines();
        direction = Vector2.zero;
        Animations();
    }
    public override void ContinueBehaviour()
    {
        StartCoroutine(Patrol());
    }
}

