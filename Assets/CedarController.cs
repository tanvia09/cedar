using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CedarController : MonoBehaviour
{
    public float UPspeed = 5f;
    public GameObject Panel;
    public float moveSpeed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().fixedAngle = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        if (!Panel.activeSelf)
        {
            transform.Translate(Vector3.up * UPspeed * Time.deltaTime);
        }
    }
}
