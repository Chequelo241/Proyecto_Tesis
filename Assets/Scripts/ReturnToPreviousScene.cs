using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToPreviousScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Cambia "R" por la tecla que desees usar
        {
            SceneManager.LoadScene(SceneTracker.previousScene);
        }
    }
}