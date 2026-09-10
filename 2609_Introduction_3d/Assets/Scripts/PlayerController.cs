using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector2 moveInput;
    private CharacterController controller;

    public float jumpPower = 5.0f;
    public float gravity = -20.0f;

    private float verticalVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        moveInput *= moveSpeed;
    }

    private void OnJump(InputValue value)
    {
        if(value.isPressed && controller.isGrounded)
        {
            verticalVelocity = jumpPower;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded && verticalVelocity < 0.0f)
        {
            verticalVelocity = -2.0f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = move * moveSpeed;
        move.y = verticalVelocity;

        controller.Move(move* Time.deltaTime);
    }
}
