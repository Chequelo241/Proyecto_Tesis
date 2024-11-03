using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHin : MonoBehaviour
{
    public int xpReward = 5; // La cantidad de XP a otorgar
    public int damage = 50;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();//se llama al componente del playerStatus.
            Tomar_Daño tomarDaño = other.GetComponent<Tomar_Daño>(); // se llama al componente del Tomar_Daño.
            if (playerStatus != null)
            {
                playerStatus.incrementXP(xpReward);
                tomarDaño.GetDamage(damage);
                Debug.Log("XP incrementada: " + playerStatus.XP);
            }
        }

    }
}
