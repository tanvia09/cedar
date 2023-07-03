using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    int clickCount = 0;
    public GameObject GraceLetter;
    private bool SecondsPassed = false;

    void Start()
    {
        StartCoroutine(Wait());
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SecondsPassed = true;
    }

    void Update()
    {
        if (SecondsPassed == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickCount++;
            }

            if (clickCount == 3)
            {
                GraceLetter.SetActive(true);
            }

            if (clickCount >= 15)
            {
                GraceLetter.SetActive(false);
            }
        }
    }
}
