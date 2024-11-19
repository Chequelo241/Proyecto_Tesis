using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerStatus playerStatus; // Referencia al estado del jugador
    public GameObject player; // Referencia al objeto del jugador
    public StatusHUD statusHUD;
    public GameObject dialogBox; // Referencia al cartel
    public TextMeshProUGUI dialogtext; // Referencia al texto del cartel

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
            DontDestroyOnLoad(dialogBox); // Asegúrate de que no se destruya al cargar una nueva escena
            SceneManager.sceneLoaded += OnSceneLoaded; // Suscribirse al evento de carga de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InitializeDialog();
        InitializeGameManager();
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
        if (SceneManager.GetActiveScene().name == "Fin")
        {
            if (Input.GetKeyDown(KeyCode.R)) { SceneLoader.LoadLevel("Mazmorra"); }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeDialog();
        InitializeGameManager(); // Re-inicializar el GameManager al cargar una nueva escena
    }

    void InitializeDialog()
    {
        if (dialogBox == null) // Asegurarse de que se mantiene la referencia si no se destruye el objeto
        {
            dialogBox = GameObject.FindWithTag("DialogBox"); // Encontrar el DialogBox en la nueva escena si es necesario
        }
        if (dialogBox != null)
        {
            dialogtext = dialogBox.GetComponentInChildren<TextMeshProUGUI>();
            dialogBox.SetActive(false);
        }
    }

    void InitializeGameManager()
    {
        playerStatus = FindObjectOfType<PlayerStatus>(); // Asigna el PlayerStatus del jugador en la escena
        statusHUD = FindObjectOfType<StatusHUD>();
        if (playerStatus != null)
        {
            player = playerStatus.gameObject;
            spriteRenderer = player.GetComponent<SpriteRenderer>();
            boxCollider = player.GetComponent<BoxCollider2D>();
        }
        Time.timeScale = 1;
    }
    //tamaño del jugador
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
                boxCollider.size = new Vector2(0.25f, 0.55f); // Tamaño original del BoxCollider
            }
        }
    }

    // Métodos para manejar el estado del jugador
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
    public void UpdateXpBarMaxValue(int newMaxXp) 
    { 
        if (statusHUD != null) 
        { 
            statusHUD.UpdateXpBarMaxValue(newMaxXp); 
        } 
    }
    //funciones del texto
    public void ShowText(string text)
    {
            dialogBox.SetActive(true);
            dialogtext.text = text;
            Time.timeScale = 0;
    }

    public void HideText()
    {
            dialogBox.SetActive(false);
            dialogtext.text = "";
            Time.timeScale = 1;
    }
}
