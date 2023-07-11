using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIsappearSprite : MonoBehaviour
{
    public GameObject Sprite;
    public GameObject Night;
    public GameObject Railroad;

    void Update()
    {
        if (Night.activeSelf)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        Sprite.SetActive(false);
        Railroad.SetActive(true);
    }
}
