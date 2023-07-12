using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideScript : MonoBehaviour
{
    public float glideSpeed = 1f;
    public int repeatCount = 20;

    int clickCount = 0;

    void Start()
    {
        if (gameObject.name == "CedarSwimming")
        {
            StartCoroutine(GlideUp());
        }
    }

    void Update()
    {
        if (DialougeManager.isActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickCount++;
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
            transform.Translate(Vector3.up * 0.1f * glideSpeed);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
