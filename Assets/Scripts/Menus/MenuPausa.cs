using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject panel;  // Referencia al Canvas
    public static bool isPaused = false;//variable publica que indica si el juego esta pausado
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel();
        }
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu Inicial");
    }

    void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
        if (panel.activeSelf == true)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            isPaused = false;
        }
    }
}
