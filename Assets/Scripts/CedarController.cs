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
    private bool CrossY = false;
    public GameObject GameOver;
    public float thresholdY = 54.4f;
    public GameObject BlackScreen;
    public static GameObject AudioSource;

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

        if (transform.position.y > thresholdY)
        {
            CrossY = true;
            BlackScreen.SetActive(true);
            StartCoroutine(WaitForSeconds());
            GameObject AudioSource = CedarController.AudioSource;
            if (AudioSource != null)
            {
                AudioSource.SetActive(false);
            }
        }

        if (!Crashed)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

            if (!Panel.activeSelf)
            {
                if (CrossY == false)
                {
                    transform.Translate(Vector3.up * UPspeed * Time.deltaTime);
                }
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
        Scene currentScene = SceneManager.GetActiveScene();
        
        if (currentScene.buildIndex == 2)
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(3);
        }

        if (currentScene.buildIndex == 4)
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(5);
        }
    }

}
