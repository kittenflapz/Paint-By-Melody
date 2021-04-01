using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

    
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] 
        float walkSpeed;
        [SerializeField] 
        float runSpeed;
        [SerializeField] 
        float jumpForce;
        
        Vector2 inputVector = Vector2.zero;
        Vector3 moveDirection = Vector3.zero;
        Animator animator;
        PlayerController playerController;
        Rigidbody rigidBody;
        Transform playerTransform;



    private void Awake()
        {
            playerController = GetComponent<PlayerController>();
            animator = GetComponent<Animator>();
            rigidBody = GetComponent<Rigidbody>();
             playerTransform = base.transform;

        }

        private void Update()
        {
            if (playerController.isJumping) return;
            
            if (!(inputVector.magnitude > 0))  moveDirection = Vector3.zero;
            
            moveDirection = playerTransform.forward * inputVector.y + playerTransform.right * inputVector.x;

            float currentSpeed = playerController.isRunning ? runSpeed : walkSpeed;

            Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);

            playerTransform.position += movementDirection;
        }

        public void OnMovement(InputValue value)
        {
            inputVector = value.Get<Vector2>();
            
            animator.SetFloat("MovementX", inputVector.x);
            animator.SetFloat("MovementZ", inputVector.y);
        }

        public void OnRun(InputValue button)
        {
            playerController.isRunning = button.isPressed;
            animator.SetBool("IsRunning", button.isPressed);
        }

        public void OnJump(InputValue button)
        {
            if (playerController.isJumping) return;
            playerController.isJumping = true;
            animator.SetBool("IsJumping", true);
            Jump();
        }
        public void Jump()
        {
        rigidBody.AddForce((base.transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
        }





    private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Ground") && !playerController.isJumping) return;

            playerController.isJumping = false;
            animator.SetBool("IsJumping", false);
        }
    }
