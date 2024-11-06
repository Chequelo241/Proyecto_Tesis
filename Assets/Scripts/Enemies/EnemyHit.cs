using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    EnemyHealth enemy;
    Animator animator;

    private void Start()
    {
        enemy = GetComponentInParent<EnemyHealth>();
        animator = GetComponent<Animator>();
    }
    public void Defead() 
    {
        animator.Play("Dead");
    }
    private void Hide()
    {
        enemy.HideEnemiy();
    }

    private void Destroy()
    {
        Destroy(enemy.gameObject);
    }
}
