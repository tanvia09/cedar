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
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
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

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            animator.SetInteger("Direction 1U 2D 3L 4R", 1);
            animator.SetBool("Moving", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            animator.SetInteger("Direction 1U 2D 3L 4R", 2);
            animator.SetBool("Moving", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            animator.SetInteger("Direction 1U 2D 3L 4R", 3);
            animator.SetBool("Moving", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Moving", false);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("Direction 1U 2D 3L 4R", 4);
            animator.SetBool("Moving", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Moving", false);
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
