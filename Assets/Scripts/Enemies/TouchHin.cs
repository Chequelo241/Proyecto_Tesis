using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHin : MonoBehaviour
{
    public int damage = 5;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetDamage tomarDaño = other.GetComponent<GetDamage>(); 
           
            tomarDaño.ReceiveDamage(damage);
        }

    }
}
