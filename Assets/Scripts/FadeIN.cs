using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIN : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        StartCoroutine(DelayedAction());

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex == 4)
        {
            StartCoroutine(DelayedAction());
        }

        if (currentScene.buildIndex == 8)
        {
            StartCoroutine(DelayedAction());
        }

        if (currentScene.buildIndex == 12)
        {
            StartCoroutine(DelayedAction());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (Input.GetMouseButtonDown(0))
        {
            if (currentScene.buildIndex != 12)
            {
                StartCoroutine(DelayedAction());
            }
        }
    }

    public IEnumerator DelayedAction()
    {
        canvasGroup.alpha = Mathf.Clamp01(canvasGroup.alpha);
        canvasGroup.alpha = 0;
        for (int i = 0; i < 10; i++)
        {
            canvasGroup.alpha += 0.1f;
            yield return new WaitForSeconds(0.07f);
        }

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 9)
        {
            if (gameObject.name == "Night")
            {
                yield return new WaitForSeconds(3f);
                for (int i = 0; i < 10; i++)
                {
                    canvasGroup.alpha -= 0.1f;
                    yield return new WaitForSeconds(0.07f);
                }
            }
        }
    }
}
