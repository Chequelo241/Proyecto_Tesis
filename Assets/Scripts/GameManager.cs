using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;  // Referencia al objeto del jugador
    public KeyCode key1 = KeyCode.LeftShift; // Primera tecla
    public KeyCode key2 = KeyCode.Space; // Segunda tecla
    public float scaleMultiplier = 2f; // Factor de escala
    public Vector2 colliderSize = new Vector2(2f, 2f); // Tamaño del BoxCollider

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        // Inicializar las referencias
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        boxCollider = player.GetComponent<BoxCollider2D>();
        Time.timeScale = 1;
    }

    void Update()
    {

        //cambio de tamanno.
        if (Input.GetKey(key1) && Input.GetKey(key2))
        {
            ModifyPlayer(true);
        }
        else
        {
            ModifyPlayer(false);
        }
    }

    //modificar tamaño del jugador
    void ModifyPlayer(bool isActive)
    {
        if (isActive)
        {
            spriteRenderer.transform.localScale = Vector3.one * scaleMultiplier;
            boxCollider.size = colliderSize;
        }
        else
        {
            spriteRenderer.transform.localScale = Vector3.one;
            boxCollider.size = new Vector2(0.25f, 0.55f); // Tamaño original del BoxCollider
        }
    }
    
}
