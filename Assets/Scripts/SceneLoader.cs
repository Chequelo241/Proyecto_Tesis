using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class SceneLoader
{
    public static string NextLevelName;

    public static void LoadLevel(string levelName)
    {
        NextLevelName = levelName;
        SceneManager.LoadScene("Loading");
    }
}
