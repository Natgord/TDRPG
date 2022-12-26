using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    Animator characterAnimator;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                characterAnimator.SetBool("isJumping", true);
                moveDirection.y = jumpSpeed;
            }
            else
            {
                characterAnimator.SetBool("isJumping", false);
            }
        }

        if ((characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") ||
            characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mining")) &&
            Input.GetButton("Fire1"))
        {
            characterAnimator.SetBool("isMining", true);
        }
        else
        {
            characterAnimator.SetBool("isMining", false);
            if (Input.GetAxis("Horizontal") != 0 ||
            Input.GetAxis("Vertical") != 0)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(moveDirection.x, transform.rotation.eulerAngles.x, moveDirection.z));
                characterAnimator.SetBool("isRunning", true);
            }
            else
            {
                characterAnimator.SetBool("isRunning", false);
            }
            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)
            moveDirection.y -= gravity * Time.deltaTime;

            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}
