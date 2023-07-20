using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CJump : MonoBehaviour
{
    public float jumpForce = 20;
    float velocity;
    public float gravity = -10f;
    private bool IsGrounded = true;
    public float UpSpeed = 10f;
    private bool SpacePressed = false;
    public float Island = 180f;
    public float moveSpeed = 5f;
    public Animator animator;
    public bool GroundOff = false;
    public float thresholdY = -10f;
    public GameObject Panel;
    public Rigidbody2D rb;
    public GameObject CSwim;
    public GameObject SwimCam;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            if (!GroundOff)
            {
                IsGrounded = true;
                animator.SetBool("Isjumping", false);
                animator.SetBool("Isswimming", false);
            }
        }
        else
        {
            IsGrounded = false;
        }
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * moveSpeed * Time.deltaTime);

        velocity += gravity * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity = jumpForce;
            StartCoroutine(WaitOnJump());
            StartCoroutine(OffGround());
        }

        if (SpacePressed == true)
        {
            transform.Translate(Vector3.down * velocity * Time.deltaTime);
        }

        if (IsGrounded)
        {
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Isswimming", false);
            }
        }

        if (!IsGrounded)
        {
            if (transform.position.y < Island)
            {
                if (!SpacePressed)
                {
                    transform.Translate(Vector3.up * UpSpeed * Time.deltaTime);
                    animator.SetBool("Isswimming", true);
                }
            }
        }

        if (transform.position.y > Island)
        {
            animator.SetBool("Isswimming", false);
        }

        if (transform.position.y < thresholdY)
        {
            if (currentScene.buildIndex == 7)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                Panel.SetActive(true);
                StartCoroutine(WaitForSeconds());
            }
            else if (currentScene.buildIndex == 12)
            {
                CSwim.SetActive(true);
                gameObject.SetActive(false);
                SwimCam.SetActive(true);
                Debug.Log("switch to swim");
            }
        }
    }

    private void OnEnable()
    {
        velocity = 0;
        float SwimPos = CSwim.transform.position.x;
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 12)
        {
            if (SwimPos > 0)
            {
                Island = 150f;
                Vector3 newPosition = new Vector3(15.2f, 155.5f, -1f);
                transform.position = newPosition;
            }
            
            if (SwimPos < 0)
            {
                Island = 166f;
                Vector3 newPosition = new Vector3(-17.6f, 169.3f, -1f);
                transform.position = newPosition;
                Debug.Log("left side");
            }
        }
    }

    private IEnumerator WaitOnJump()
    {
        SpacePressed = true;
        IsGrounded = false;
        animator.SetBool("Isswimming", false);
        animator.SetBool("Isjumping", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("Isjumping", false);
        SpacePressed = false;
    }

    private IEnumerator OffGround()
    {
        GroundOff = true;
        yield return new WaitForSeconds(0.25f);
        GroundOff = false;
    }

    private IEnumerator WaitForSeconds()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex == 7)
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(8);
        }

    }
}
