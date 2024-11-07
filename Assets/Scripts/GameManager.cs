using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerStatus playerStatus; // Referencia al estado del jugador
    public GameObject player; // Referencia al objeto del jugador
    public KeyCode key1 = KeyCode.LeftShift; // Primera tecla
    public KeyCode key2 = KeyCode.Space; // Segunda tecla
    public float scaleMultiplier = 2f; // Factor de escala
    public Vector2 colliderSize = new Vector2(2f, 2f); // Tamaño del BoxCollider

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerStatus = FindObjectOfType<PlayerStatus>(); // Asigna el PlayerStatus del jugador en la escena
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        boxCollider = player.GetComponent<BoxCollider2D>();
        Time.timeScale = 1;
    }

    void Update()
    {
        // Cambio de tamaño del jugador
        if (Input.GetKey(key1) && Input.GetKey(key2))
        {
            ModifyPlayer(true);
        }
        else
        {
            ModifyPlayer(false);
        }
    }

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

    // Métodos para manejar el estado del jugador
    public void ChangePlayerHealth(int value)
    {
        playerStatus.ChangeHealth(value);
    }

    public void IncrementPlayerXP(int xp)
    {
        playerStatus.IncrementXP(xp);
    }
}
