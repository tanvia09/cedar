using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlideScript : MonoBehaviour
{
    public float glideSpeed = 1f;
    public int repeatCount = 20;
    private bool OneTime = false;
    public GameObject Train;
    int clickCount = 0;

    void Start()
    {
        if (gameObject.name == "CedarSwimming")
        {
            StartCoroutine(GlideUp());
        }

        if (gameObject.name == "Grace Side")
        {
            gameObject.transform.localScale = new Vector3(-10, 10, 1);
            StartCoroutine(GlideLeft());
        }
    }

    void Update()
    {
        if (DialougeManager.isActive)
        {
            if (Input.GetMouseButtonDown(0) && PauseScript.Paused == false)
            {
                clickCount++;
            }
        }

        if (clickCount > 6)
        {
            if (gameObject.name == "JuneFriend")
            {
                gameObject.transform.localScale = new Vector3(-14, 14, 1);
                StartCoroutine(GlideRight());
            }
            if (gameObject.name == "June")
            {
                gameObject.transform.localScale = new Vector3(-14, 14, 1);
                StartCoroutine(GlideRight());
            }
        }

        if (clickCount > 8)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.buildIndex == 10)
            {
                if (gameObject.name == "CedarSwimming")
                {
                    Train.SetActive(true);
                    gameObject.transform.localScale = new Vector3(10, -10, 1);
                    StartCoroutine(GlideDown());
                }
            }
        }

        if (clickCount > 8)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.buildIndex == 11)
            {
                if (gameObject.name == "CedarSwimming" && OneTime == false)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                    StartCoroutine(GlideUp());
                    OneTime = true;
                }
            }
        }


        if (clickCount > 14)
        {
            if (gameObject.name == "Nina")
            {
                gameObject.transform.localScale = new Vector3(-14, 14, 1);
                StartCoroutine(GlideRight());
            }
        }
    }

    IEnumerator GlideUp()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            transform.Translate(Vector3.up * 0.1f * glideSpeed);
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator GlideRight()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            transform.Translate(Vector3.right * 0.1f * glideSpeed);
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator GlideLeft()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            transform.Translate(Vector3.left * 0.1f * glideSpeed);
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator GlideDown()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            transform.Translate(Vector3.down * 0.1f * glideSpeed);
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(11);
    }
}
