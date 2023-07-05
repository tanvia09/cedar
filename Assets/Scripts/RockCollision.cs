using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{
    public GameObject GameOver;
    // Start is called before the first frame update

    public void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Cedarswims"))
        {
            CedarCollided();
        }
    }

    public void CedarCollided()
    {
        Debug.Log("GameOver");
        GameOver.SetActive(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
