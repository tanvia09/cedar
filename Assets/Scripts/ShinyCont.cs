using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShinyCont : MonoBehaviour
{
    public float glideSpeed = 1f;
    public bool isGlide = true;
    public int repeatCount = 20;
    public bool CedarMayor = false;
    public DialougeTrigger trigger;
    public Vector3 targetPosition = new Vector3(36.59f, -1.08f, 0f);
    public GameObject Choices;
    public GameObject Panel;
    public bool CanLeave;

    int clickCount = 0;

    IEnumerator Glide()
    {
        isGlide = false;
        for (int i = 0; i < repeatCount; i++)
        {
            transform.Translate(Vector3.left * 0.1f * glideSpeed);
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void CedarIsMayor()
    {
        CedarMayor = true;
        Debug.Log("CedarMayor!");
        transform.position = targetPosition;
    }
    
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isGlide)
                {
                    StartCoroutine(Glide());
                }
            }
        }

        if (currentScene.buildIndex == 9)
        {
            CedarMayor = true;

            if (DialougeManager.isActive)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickCount++;
                }
            }

            if (clickCount == 14)
            {
                StartCoroutine(Glide());
            }
        }

        if (CanLeave == true)
        {
            if (!DialougeManager.isActive)
            {
                Panel.SetActive(true);

                if (currentScene.buildIndex == 3)
                {
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        SceneManager.LoadScene(4);
                    }
                } 
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == true)
        {
            if (CedarMayor == true)
            {
                trigger.StartDialouge();
                Choices.SetActive(false);
                CanLeave = true;
                CedarMayor = false;
            }
        }
    }
}
