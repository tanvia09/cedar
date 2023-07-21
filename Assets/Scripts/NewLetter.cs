using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLetter : MonoBehaviour
{
    int clickCount = 0;
    public GameObject GraceLetter;
    public GameObject Watermelon;
    public GameObject Train;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickCount++;
        }

        if (clickCount >= 10)
        {
            GraceLetter.SetActive(true);
        }

        if (clickCount >= 17)
        {
            GraceLetter.SetActive(false);
        }

        if (clickCount >= 25)
        {
            Watermelon.SetActive(true);
            Train.SetActive(true);
        }
    }
}

