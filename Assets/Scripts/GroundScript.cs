using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public GameObject CedarJ;

    void Start()
    {
        Collider2D collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (CedarJ.activeSelf)
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
        else
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
