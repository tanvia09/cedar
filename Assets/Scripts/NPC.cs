using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialougeTrigger trigger;
    public GameObject Choices;
    public bool CF = true;

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
}
