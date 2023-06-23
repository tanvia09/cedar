using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CedarController : MonoBehaviour
{
    public int NewPacificana;

    public float UPspeed = 5f;
    public GameObject Panel;
    public float moveSpeed = 5f;
    private bool Crashed = false;
    public GameObject GameOver;
    public float thresholdY = 54.4f;
    public GameObject BlackScreen;
    public AudioSource RiversideTheme;

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
        RiversideTheme.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > thresholdY)
        {
            RiversideTheme.Stop();
            BlackScreen.SetActive(true);
            StartCoroutine(WaitForSeconds());
        }

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
    private IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(3);
    }

}
