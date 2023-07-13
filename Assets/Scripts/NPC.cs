using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public DialougeTrigger trigger;
    public GameObject Choices;
    public GameObject Vill;
    public bool CF = true;
    private bool CanLeave;
    public GameObject Panel;

    int clickCount = 0;
    public int repeatCount = 20;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == true)
        {
            if (CF == true)
            {
                trigger.StartDialouge();
                Debug.Log("StartedDialouge");
                if (gameObject.name == "ConcernedFish")
                {
                    CF = false;
                    CanLeave = true;
                }
            }
            
            if (gameObject.name == "Door")
            {
                Choices.SetActive(true);
            }
            else
            {
                Choices.SetActive(false);
            }

            if (gameObject.name == "Railroad9")
            {
                Vill.SetActive(true);
            }
        }
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (CanLeave == true)
        {
            if (!DialougeManager.isActive)
            {
                if (currentScene.buildIndex == 5)
                {
                    Panel.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        SceneManager.LoadScene(6);
                    }
                }
            }

        }

        if (currentScene.buildIndex == 8)
        {
            if (DialougeManager.isActive)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickCount++;
                }
            }
            
            if (clickCount == 7)
            {
                StartCoroutine(Glide());
            }
        }
    }

    private IEnumerator Glide()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            transform.Translate(Vector3.right * 0.1f * 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
