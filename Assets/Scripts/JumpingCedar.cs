using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingCedar : MonoBehaviour
{
    public GameObject GameOver;
    private bool Crashed;
    public float DownSpeed = 5f;
    public float moveSpeed = 5f;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Water"))
        {
            Crashed = true;
            Debug.Log("Water");
        }

        if (collider.gameObject.CompareTag("Rock"))
        {
            Crashed = false;
            Debug.Log("Rock");
        }
    }
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();

        if (Crashed == true)
        {
            transform.Translate(Vector3.down * DownSpeed * Time.deltaTime);
        }
    }
}
