using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    public static string previousScene;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void LoadScene(string sceneName)
    {
        previousScene = SceneManager.GetActiveScene().name; // Almacenar la escena actual
        SceneManager.LoadScene(sceneName);
    }
}
