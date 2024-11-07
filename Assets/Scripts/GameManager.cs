using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerStatus playerStatus; // Referencia al estado del jugador
    public GameObject player; // Referencia al objeto del jugador
    public KeyCode key1 = KeyCode.LeftShift; // Primera tecla
    public KeyCode key2 = KeyCode.Space; // Segunda tecla
    public float scaleMultiplier = 2f; // Factor de escala
    public Vector2 colliderSize = new Vector2(2f, 2f); // Tama�o del BoxCollider

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Suscribirse al evento de carga de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InitializeGameManager();
    }

    void Update()
    {
        // Cambio de tama�o del jugador
        if (Input.GetKey(key1) && Input.GetKey(key2))
        {
            ModifyPlayer(true);
        }
        else
        {
            ModifyPlayer(false);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeGameManager(); // Re-inicializar el GameManager al cargar una nueva escena
    }

    void InitializeGameManager()
    {
        playerStatus = FindObjectOfType<PlayerStatus>(); // Asigna el PlayerStatus del jugador en la escena
        if (playerStatus != null)
        {
            player = playerStatus.gameObject;
            spriteRenderer = player.GetComponent<SpriteRenderer>();
            boxCollider = player.GetComponent<BoxCollider2D>();
        }
        Time.timeScale = 1;
    }

    void ModifyPlayer(bool isActive)
    {
        if (spriteRenderer != null && boxCollider != null)
        {
            if (isActive)
            {
                spriteRenderer.transform.localScale = Vector3.one * scaleMultiplier;
                boxCollider.size = colliderSize;
            }
            else
            {
                spriteRenderer.transform.localScale = Vector3.one;
                boxCollider.size = new Vector2(0.25f, 0.55f); // Tama�o original del BoxCollider
            }
        }
    }

    // M�todos para manejar el estado del jugador
    public void ChangePlayerHealth(int value)
    {
        if (playerStatus != null)
        {
            playerStatus.ChangeHealth(value);
        }
    }

    public void IncrementPlayerXP(int xp)
    {
        if (playerStatus != null)
        {
            playerStatus.IncrementXP(xp);
        }
    }

    public void SetPlayerXPToMax()
    {
        if (playerStatus != null)
        {
            playerStatus.IncrementXP(PlayerStatus.MaxXp - playerStatus.XP);
        }
    }

    public void SetPlayerXPToHalfMax()
    {
        if (playerStatus != null)
        {
            playerStatus.IncrementXP((PlayerStatus.MaxXp / 2) - playerStatus.XP);
        }
    }

    public void SetPlayerXPToQuarterMax()
    {
        if (playerStatus != null)
        {
            playerStatus.IncrementXP((PlayerStatus.MaxXp / 4) - playerStatus.XP);
        }
    }
}
