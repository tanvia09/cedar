using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialougeTrigger trigger;
    public GameObject Choices;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == true)
        {
            trigger.StartDialouge();
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
