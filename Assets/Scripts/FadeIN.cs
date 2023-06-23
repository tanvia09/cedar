using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIN : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        StartCoroutine(DelayedAction());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(DelayedAction());
        }
    }

    private IEnumerator DelayedAction()
    {
        canvasGroup.alpha = Mathf.Clamp01(canvasGroup.alpha);
        canvasGroup.alpha = 0;
        for (int i = 0; i < 10; i++)
        {
            canvasGroup.alpha += 0.1f;
            yield return new WaitForSeconds(0.07f);
        }
    }
}
