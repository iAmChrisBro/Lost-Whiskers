using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    //input fields
    //private PlayerControls playerActionsAsset;
    private InputActionAsset inputAsset;
    private InputActionMap player;
    private InputAction move;

    //movement fields
    private Rigidbody rb;
    [SerializeField]
    private float movementForce;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float maxSpeed;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField]
    private Camera playerCamera;
    private Animator animator;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        //playerActionsAsset = new PlayerControls();
        inputAsset = this.GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");
        animator = this.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //playerActionsAsset.Player.Jump.started += DoJump;
        //playerActionsAsset.Player.Attack.started += DoAttack;
        //move = playerActionsAsset.Player.Move;
        //playerActionsAsset.Player.Enable();
        player.FindAction("Jump").started += DoJump;
        move = player.FindAction("Move");
        player.Enable();
    }

    private void OnDisable()
    {
        //playerActionsAsset.Player.Jump.started -= DoJump;
        //playerActionsAsset.Player.Attack.started -= DoAttack;
        //playerActionsAsset.Player.Disable();
        player.FindAction("Jump").started -= DoJump;
        player.Disable();
    }

    private void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        animator.SetFloat("Speed",rb.velocity.magnitude / maxSpeed);

        animator.SetBool("isGrounded", IsGrounded());


        LookAt();
    }

    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            rb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera camera)
    {
        if (camera == null) return Vector3.forward; // Fallback to a default direction
        Vector3 forward = camera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera camera)
    {
        if (camera == null) return Vector3.right; // Fallback to a default direction
        Vector3 right = camera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            animator.SetBool("isGrounded", false);
            forceDirection += Vector3.up * jumpForce;
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        {
            return true;
            
        }
        else
        {
            return false;
        }
    }

    public void AssignCamera(Camera camera)
    {
        playerCamera = camera;
    }


}