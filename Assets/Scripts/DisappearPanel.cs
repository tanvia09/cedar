using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPanel : MonoBehaviour
{
    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
