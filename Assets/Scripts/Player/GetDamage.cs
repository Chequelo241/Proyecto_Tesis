using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    private PlayerStatus playerStatus;

    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        if (playerStatus != null)
        {
            playerStatus.Hp.currentValue = playerStatus.Hp.maxvalue;
        }
    }

    public void ReceiveDamage(int Damage)
    {
        if (playerStatus != null)
        {
            playerStatus.Hp.currentValue -= Damage;
            if (playerStatus.Hp.currentValue <= 0)
            {
                SceneTracker.LoadScene("Fin");
            }
        }
    }

    public void Healing(int Heal)
    {
        if (playerStatus != null)
        {
            if ((playerStatus.Hp.currentValue + Heal) < playerStatus.Hp.maxvalue)
            {
                playerStatus.Hp.currentValue += Heal;
            }
            else
            {
                playerStatus.Hp.currentValue = playerStatus.Hp.maxvalue;
            }
        }
    }
}