using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Hp Paramenters")]
    public int maxHp = 10;
    public int Hp = 10;
    public int damage=0;
    public int xpReward = 50;

    protected bool isInvincible;
    protected float invincibilityTime = 0.5f;
    protected float blinkTime = 0.1f;

    public float knockBackStrength = 1f;
    protected float knockBackTime = 0.3f;

    protected Rigidbody2D RigidBody;
    protected SpriteRenderer spriteRenderer;
    protected EnemyHit enemyHit;

    public virtual void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyHit = GetComponentInChildren<EnemyHit>();

        Hp = maxHp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma") && !isInvincible)
        {
            Hp--; 
            if (Hp <= 0)
            {
                GameManager.instance.IncrementPlayerXP(xpReward);

                enemyHit.Defead();
            }
            StopBehaviour();
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
        if (knockBackStrength <= 0)
        {
            if (Hp>0)  ContinueBehaviour();
            yield break;
        }

        RigidBody.velocity = (transform.position - hitPosition).normalized * knockBackStrength;
        yield return new WaitForSeconds(knockBackTime);
        RigidBody.velocity = Vector3.zero;
        yield return new WaitForSeconds(knockBackTime);
        if (Hp > 0) ContinueBehaviour();

    }

    public void HideEnemiy()
    {
        StopAllCoroutines();
        RigidBody.velocity = Vector3.zero;
        spriteRenderer.enabled = false;
    }

    public virtual void StopBehaviour() 
    { }
    public virtual void ContinueBehaviour() 
    { }
}
