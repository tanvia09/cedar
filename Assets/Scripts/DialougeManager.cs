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
    public GameObject CedarSwims;
    public GameObject JumpingCedar;
    public GameObject Camera;
    public GameObject Directions;
    public GameObject Railroad;
    AudioSource ChooChoo;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public CanvasGroup DialougeBox;


    public IEnumerator DelayedAction()
    {
        DialougeBox.alpha = Mathf.Clamp01(DialougeBox.alpha);
        for (int i = 0; i < 10; i++)
        {
            DialougeBox.alpha -= 0.1f;
            yield return new WaitForSeconds(0.07f);
        }
    }


    public void OpenDialouge(Message[] messages, Actor[] actors)
    {
        DialougeBox.alpha = 1;
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
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
            Scene currentScene = SceneManager.GetActiveScene();
            isActive = false;
            if (currentScene.buildIndex == 1)
            {
                SceneManager.LoadScene(2);
            }
            if (currentScene.buildIndex == 6)
            {
                SceneManager.LoadScene(7);
            }
            if (currentScene.buildIndex == 7 || currentScene.buildIndex == 12)
            {
                Camera.SetActive(false);
                CedarSwims.SetActive(false);
                JumpingCedar.SetActive(true);
                Directions.SetActive(true);
            }
            if (currentScene.buildIndex == 9)
            {
                if (Railroad.activeSelf)
                {
                    ChooChoo = GetComponent<AudioSource>();
                    ChooChoo.Play(0);
                    StartCoroutine(DelayedAction());
                    StartCoroutine(LoadSceneTen());
                }
            }
            StartCoroutine(DelayedAction()); //fades out box
        }

    }

    // Start is called before the first frame update
    void Start() 
    {
        DialougeBox = GetComponent<CanvasGroup>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            NextMessage();
        }

    }

    IEnumerator LoadSceneTen()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(10);
    }
}

