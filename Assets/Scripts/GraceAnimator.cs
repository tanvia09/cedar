using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraceAnimator : MonoBehaviour
{
    public Animator animator;
    int clickCount = 0;
    private bool Once = false;
    public GameObject Cedar;

    void Start()
    {
        animator.SetBool("Hug", false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickCount++;
        }

        if (clickCount == 17 && Once == false)
        {
            StartCoroutine(Wait());
            Once = true;
        }
    }

    private IEnumerator Wait()
    {
        Cedar.SetActive(false);
        animator.SetBool("Hug", true);
        Vector3 newPosition = new Vector3(-6f, 1.06f, 5f);
        transform.position = newPosition;
        yield return new WaitForSeconds(4.8f);
        Vector3 oldPosition = new Vector3(-7.52f, 1.06f, 5f);
        transform.position = oldPosition;
        animator.SetBool("Hug", false);
        Cedar.SetActive(true);
    }
}
