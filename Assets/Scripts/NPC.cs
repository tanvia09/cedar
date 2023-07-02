using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public DialougeTrigger trigger;
    public GameObject Choices;
    public bool CF = true;
    private bool CanLeave;
    public GameObject Panel;

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
        }
    }

    void Update()
    {
        if (CanLeave == true)
        {
            if (!DialougeManager.isActive)
            {
                Panel.SetActive(true);

                if (Input.GetKeyDown(KeyCode.X))
                {
                    SceneManager.LoadScene(6);
                }
            }

        }
    }
}
