using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CedarController : MonoBehaviour
{
    public float UPspeed = 5f;
    public GameObject Panel;
    public float moveSpeed = 5f;
    private bool Crashed = false;
    public GameObject GameOver;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Rock"))
        {
            Debug.Log("CedarCollisionEntered");
            Crashed = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!Crashed)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

            if (!Panel.activeSelf)
            {
                transform.Translate(Vector3.up * UPspeed * Time.deltaTime);
            }
        }
        
        if (Crashed)
        {
            Vector3 newPosition = new Vector3(0f, 0f, 1f);
            transform.position = newPosition;

            if (!GameOver.activeSelf)
            {
                Crashed = false;
            }
        }
        
    }
}
