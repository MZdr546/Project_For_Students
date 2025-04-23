using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float rotationSpeed = 1f;
    [SerializeField]
    private float jumpForce = 1f;

    [SerializeField]
    Animator Animator;

    private PlayerInputAction action;
   
    Rigidbody rb;
    [SerializeField]
    bool isOnGround = true;

    bool isPC;

    private void Awake()
    {

        action = new PlayerInputAction();
        action.Player.Move.Enable();
        action.Player.Jump.Enable();
        action.Player.Jump.performed += Jump;

        rb = GetComponent<Rigidbody>();
        
    }

    private void OnDisable()
    {
        action.Player.Move.Disable();
        action.Player.Jump.Disable();
        action.Player.Jump.performed -= Jump;
    }

    private void FixedUpdate()
    {

        Vector2 inputVector = action.Player.Move.ReadValue<Vector2>();

        {
            if (inputVector.x != 0 || inputVector.y != 0)
                Animator.SetBool("Running", true);
            else
                Animator.SetBool("Running", false);
        }

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotationSpeed * Time.deltaTime);

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isOnGround)
        {
            Animator.SetBool("Jump", true);
            Debug.Log("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.gameObject.CompareTag("Ground"))
        {
            if (isOnGround == false)
            {
                Animator.SetBool("Jump", false);
                isOnGround = true;
            }
        }
    }
    
    

}
