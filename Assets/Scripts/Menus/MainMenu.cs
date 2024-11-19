using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play() 
    {
        SceneLoader.LoadLevel("Mazmorra");
    }

    public void Exit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
