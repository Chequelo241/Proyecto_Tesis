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

    public void ReceiveDamage(int damage)
    {
        if (playerStatus != null)
        {
            GameManager.instance.ChangePlayerHealth(-damage);
            if (playerStatus.Hp.currentValue <= 0)
            {
                SceneManager.LoadScene("Fin"); // Cambiado a SceneManager para cargar la escena correctamente
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
