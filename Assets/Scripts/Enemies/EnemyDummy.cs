using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDummy : MonoBehaviour
{
    public int Hp=5;

    private void OnTriggerEnter2D(Collider2D collision)//verificar que el tipo de Collider2D usado, tengo el Trigger activo
    {
        if (collision.tag == "Arma") 
        {
            Hp--;
            if (Hp<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
