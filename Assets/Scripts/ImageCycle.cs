using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCycle : MonoBehaviour
{
    public GameObject Image1;
    public GameObject Image2;
    public GameObject PressEsc;
    private int Escape = 0;

    void Start()
    {
        StartCoroutine(CycleImages());
    }

    void Update()
    {
        if (Escape == 3)
        {
            PressEsc.SetActive(true);
        }
    }

    IEnumerator CycleImages()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            Image1.SetActive(false);
            yield return new WaitForSeconds(4f);
            Image2.SetActive(false);
            yield return new WaitForSeconds(4f);
            Image1.SetActive(true);
            Image2.SetActive(true);
            Escape++;
        }
    }
}
