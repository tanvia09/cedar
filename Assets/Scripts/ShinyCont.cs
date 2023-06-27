using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinyCont : MonoBehaviour
{
    public float glideSpeed = 1f;
    public bool isGlide = true;
    public int repeatCount = 20;
    public bool CedarMayor = false;

    IEnumerator Glide()
    {
        isGlide = false;
        for (int i = 0; i < repeatCount; i++)
        {
            // Move the character to the left by 0.1 units
            transform.Translate(Vector3.left * 0.1f * glideSpeed);

            // Wait for a short duration before the next movement
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void CedarIsMayor()
    {
        CedarMayor = true;
        Debug.Log("CedarMayor!");
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isGlide)
            {
                StartCoroutine(Glide());
                Debug.Log("Glide");
            }
        }
    }
}
