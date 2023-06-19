using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public string[] dialogueSentences;
    private string currentSentence = "";
    private int currentIndex = 0;
    public float delay = 0.1f;
    private Text dialogueTextComponent;

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
        }

    }

    // Start is called before the first frame update
    void Start() 
    { 
    
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }

    private IEnumerator TypeDialogue()
    {
        foreach (string sentence in dialogueSentences)
        {
            currentSentence = "";
            currentIndex = 0;

            while (currentIndex < sentence.Length)
            {
                currentSentence += sentence[currentIndex];
                dialogueTextComponent.text = currentSentence;
                currentIndex++;

                yield return new WaitForSeconds(delay);
            }

            // Wait for a brief pause at the end of each sentence if desired
            yield return new WaitForSeconds(0.5f);
        }
    }
}
