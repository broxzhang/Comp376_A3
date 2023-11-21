using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float playerSpeed;
    private int desiredLane = 1; // 0 = left, 1 = middle, 2 = right
    public float laneDistance = 4; // the distance between two lanes
    public float jumpForce;
    public float gravity = -20;

    public Animator animator;

    private bool shouldJump;

    public GameObject countdownTimer;

    public GameObject particleEffect;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator.SetBool("isGameStart", true);

        countdownTimer.SetActive(false);

        particleEffect.SetActive(false);
        
    }

    void Update()
    {

        // animator.SetBool("isJump", controller.isGrounded);
        direction.z = playerSpeed;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            shouldJump = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Shrink());
        }
        
        // if (controller.isGrounded)
        // {
        //     direction.y = -0.1f; // Keep a small downward force to ensure the controller stays grounded
        //     if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        //     {
        //         direction.y = jumpForce;
        //     }
        // }
        // else
        // {
        //     direction.y += gravity * Time.deltaTime;
        // }
        // Gather the inputs on which lane we should be
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            if (desiredLane > 2)
                desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            if (desiredLane < 0)
                desiredLane = 0;
        }


        // Get power up
        if (GameManager.instance.HugePumpkinRoll == true)
        {
            countdownTimer.SetActive(true);

            transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);

            particleEffect.SetActive(true);

        }


        if (GameManager.instance.isTimeUp == true)
        {
            GameManager.instance.HugePumpkinRoll = false;
            GameManager.instance.isTimeUp = false;
            countdownTimer.SetActive(false);


        }

    }

    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            direction.y = -0.1f; // Keep a small downward force to ensure the controller stays grounded
            if (shouldJump)
            {
                direction.y = jumpForce;
                animator.SetBool("isJump", shouldJump);

                shouldJump = false;
            }
        }
        else
        {
            animator.SetBool("isJump", false);
            direction.y += gravity * Time.fixedDeltaTime;
        }
        
        controller.Move(direction * Time.fixedDeltaTime);
        // Calculate where we should be in the future
        Vector3 targetPosition = transform.position;
        if (desiredLane == 0)
        {
            targetPosition.x = -laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition.x = laneDistance;
        }
        else
        {
            targetPosition.x = 0;
        }

        // Move the player to the target position
        if (controller.isGrounded || direction.y < 0)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.fixedDeltaTime; // 25 is a speed factor
            // Clamp the magnitude of moveDir to make sure we do not overshoot the target position
            if (moveDir.magnitude < diff.magnitude)
            {
                controller.Move(moveDir);
            }
            else
            {
                controller.Move(diff);
            }
        }
        
        // Apply the direction (forward and gravity)
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private IEnumerator Shrink()
    {
        animator.SetBool("isShrink", true);

        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;

        yield return new WaitForSeconds(0.5f);

        controller.center = Vector3.zero;
        controller.height = 2;
        animator.SetBool("isShrink", false);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == "Obstacle")
        {
            // GameManager.isGameOver = true;

            if (GameManager.instance.HugePumpkinRoll) {
                // hit.gameObject.SetActive(false);
                Destroy(hit.gameObject);
            } else {
                GameManager.instance.isGameOver = true;
            }

            if (GameManager.instance.OneTimeShield > 0) {
                GameManager.instance.OneTimeShield--;
                Destroy(hit.gameObject);

            } else {
                GameManager.instance.isGameOver = true;
            }
        }
    }
}
