using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCheck : MonoBehaviour
{
    private bool BeenLeft = false;
    private bool BeenRight = false;

    private bool Dialouge = false;
    public GameObject SideCheckPanel;
    public GameObject Left;
    public GameObject Right;

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Cedarswims"))
        {
            if (Dialouge == true)
            {
                if (gameObject.name == "Left")
                {
                    if (BeenRight == false)
                    {
                        BeenLeft = true;
                        Debug.Log("BeenLeft");
                    }
                }

                if (gameObject.name == "Right")
                {
                    if (BeenLeft == false)
                    {
                        BeenRight = true;
                        Debug.Log("BeenRight");
                    }
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Cedarswims"))
        {
            if (gameObject.name == "Left")
            {
                if (BeenLeft == true)
                {
                    SideCheckPanel.SetActive(true);
                    Dialouge = false;
                    Right.SetActive(false);
                }
            }

            if (gameObject.name == "Right")
            {
                if (BeenRight == true)
                {
                    SideCheckPanel.SetActive(true);
                    Dialouge = false;
                    Left.SetActive(false);
                }
            }
        }
    }

    void Update()
    {
        if (DialougeManager.isActive)
        {
            Debug.Log("DialougeTrue");
            Dialouge = true;
        }

        if (BeenLeft == true)
        {
            Right.SetActive(false);
        }

        if (BeenRight == true)
        {
            Left.SetActive(false);
        }
    }
}
