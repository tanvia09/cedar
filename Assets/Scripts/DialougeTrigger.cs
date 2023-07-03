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
        RiversideTheme = GetComponent<AudioSource>();
        RiversideTheme.Play();

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex != 5)
        {
            if (currentScene.buildIndex != 6)
            {
                StartDialouge();
            }
        }

        if (currentScene.buildIndex == 6)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        StartDialouge();
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