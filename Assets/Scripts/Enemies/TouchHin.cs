using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHin : MonoBehaviour
{
    public int damage;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetDamage tomarDa�o = other.GetComponent<GetDamage>(); 
           
            tomarDa�o.ReceiveDamage(damage);
        }

    }
}
