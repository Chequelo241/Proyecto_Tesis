using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Loading : MonoBehaviour
{
    private void Start()
    {
        string levelToLoad = SceneLoader.NextLevelName;
        StartCoroutine(this.MakeTheLoad(levelToLoad));
    }
    IEnumerator MakeTheLoad(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
