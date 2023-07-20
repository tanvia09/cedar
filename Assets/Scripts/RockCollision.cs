using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{
    public GameObject GameOver;

    public void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Cedarswims"))
        {
            CedarCollided();
        }
    }

    public void CedarCollided()
    {
        GameOver.SetActive(true);
    }
}
