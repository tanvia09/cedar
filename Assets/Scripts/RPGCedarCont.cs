using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPGCedarCont : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rb;
    public float Xthresh = 50f;
    public GameObject Night;

    // Start is called before the first frame update
    void Start()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        GetComponent<Rigidbody2D>().freezeRotation = true;

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 3)
        {
            animator.SetBool("Awake", false);
        }
        else
        {
            animator.SetBool("Awake", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialougeManager.isActive)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().freezeRotation = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            movement.Normalize();
            rb.velocity = movement * moveSpeed;

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                animator.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
            }
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            animator.SetFloat("Speed", 0f);
        }

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 8)
        {
            if (transform.position.x > Xthresh)
            {
                Night.SetActive(true);
                StartCoroutine(WaitForSeconds());
            }
        }

        //animation
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Awake", true);
        }
    }

    private IEnumerator WaitForSeconds()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex == 8)
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(9);
        }
    }
}
