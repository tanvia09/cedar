using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(14);
    }

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 14)
        {
            StartCoroutine(SceneOne());
        }
    }

    private IEnumerator SceneOne()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        yield return new WaitForSeconds(7.8f);
        SceneManager.LoadScene(1);
    }
}
