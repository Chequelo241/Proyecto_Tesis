using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp = 10;
    public int Hp = 10;
    public int xpReward = 50;

    bool isInvincible;
    float invincibilityTime = 0.5f;
    float blinkTime = 0.1f;

    public float knockBackStrength = 1f;
    float knockBackTime = 0.5f;

    Rigidbody2D RigidBody;
    SpriteRenderer spriteRenderer;
    EnemyHit enemyHit;
    private PlayerStatus playerStatus; private void Start() 
    { 
        RigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyHit = GetComponentInChildren<EnemyHit>();

        Hp = maxHp; 
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        if (player != null) 
        { playerStatus = player.GetComponent<PlayerStatus>(); } 
        else { Debug.LogError("Player object not found"); } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma") && !isInvincible)
        {
            Hp--; 
            if (Hp <= 0)
            {
                if (playerStatus != null) { playerStatus.IncrementXP(xpReward); }
                enemyHit.Defead();
            }
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
        if (knockBackStrength <= 0) yield break;

        RigidBody.velocity = (transform.position - hitPosition).normalized * knockBackStrength;
        yield return new WaitForSeconds(knockBackTime);
        RigidBody.velocity = Vector3.zero;
    }

    public void HideEnemiy()
    {
        StopAllCoroutines();
        RigidBody.velocity = Vector3.zero;
        spriteRenderer.enabled = false;
    }
}
