using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialougeManager : MonoBehaviour
{
    public int WaterfallRiver;

    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public void NextScene()
    {
        SceneManager.LoadScene(WaterfallRiver);
        Debug.Log("NextScene function called");
    }


    public void OpenDialouge(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Started conversation, loaded messages");
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else 
        {
            Debug.Log("ConvoEnded");
            isActive = false;
            NextScene();
        }

    }

    // Start is called before the first frame update
    void Start() 
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            NextMessage();
        }

    }
}

