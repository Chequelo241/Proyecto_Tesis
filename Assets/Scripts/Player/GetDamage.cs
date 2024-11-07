using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    private PlayerStatus playerStatus;

    void Start()
    {
        playerStatus = GameManager.instance.playerStatus;
        if (playerStatus != null)
        {
            playerStatus.Hp.currentValue = playerStatus.Hp.maxvalue;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.transform.GetComponent<EnemyHealth>(); 
            if (enemyHealth != null) 
            { 
                ReceiveDamage(enemyHealth.damage); 
            }
        }
    }

    public void ReceiveDamage(int damage)
    {
        if (playerStatus != null)
        {
            GameManager.instance.ChangePlayerHealth(-damage);
            if (playerStatus.Hp.currentValue <= 0)
            {
                SceneManager.LoadScene("Fin"); 
            }
        }
    }

    public void Healing(int heal)
    {
        if (playerStatus != null)
        {
            GameManager.instance.ChangePlayerHealth(heal);
        }
    }
}
