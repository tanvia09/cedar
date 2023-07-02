using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialougeTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    private AudioSource RiversideTheme;
    public GameObject Diabox;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex != 5)
        {
            StartDialouge();
        }
        RiversideTheme = GetComponent<AudioSource>();
        RiversideTheme.Play();
    }

    public void StartDialouge()
    {
        Diabox.SetActive(true);
        DialougeManager dialougeManager = FindObjectOfType<DialougeManager>(); 
        dialougeManager.OpenDialouge(messages, actors);
    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}