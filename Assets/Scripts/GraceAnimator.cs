using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GraceAnimator : MonoBehaviour
{
    int clickCount = 0;
    private bool Once = false;
    public GameObject Cedar;
    public GameObject GraceSide;
    public GameObject Hug;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && PauseScript.Paused == false)
        {
            clickCount++;
        }

        if (clickCount == 17 && Once == false)
        {
            StartCoroutine(Wait());
            Once = true;
        }

        if (clickCount > 24)
        {
            Debug.Log("25clicks");
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.buildIndex == 11)
            {
                StartCoroutine(ToSceneTwelve());
            }
        }
    }

    private IEnumerator Wait()
    {
        Cedar.SetActive(false);
        GraceSide.SetActive(false);
        Hug.SetActive(true);
        yield return new WaitForSeconds(5f);
        Hug.SetActive(false);
        Cedar.SetActive(true);
        GraceSide.SetActive(true);
    }

    IEnumerator ToSceneTwelve()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(12);
    }
}
