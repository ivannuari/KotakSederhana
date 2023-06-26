using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField , Range(50f , 150f)] private float playerSpeed = 20f;
    [SerializeField , Range(50f , 250f)] private float turnSpeed = 10f;
    [SerializeField , Range(0f , 50f)] private float camSensitivity = 10f;

    [SerializeField] private Transform cam;

    [SerializeField] private bool isGrounded;
    [SerializeField, Range(0.1f, 1f)] private float checkGroundRadius = 0.2f;

    private Vector3 movement;
    private Rigidbody rb;
    [SerializeField] private float _verticalVelocity;
    [SerializeField] private float JumpHeight;
    [SerializeField] private float Gravity = -8.6f;
    [SerializeField] private float _terminalVelocity;
    [SerializeField] private float _jumpTimeoutDelta;
    [SerializeField] private float _fallTimeoutDelta;
    [SerializeField] private float JumpTimeout;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>().transform;
    }

    private void Update()
    {
        float inputZ = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        movement = transform.forward * inputZ;
        transform.Rotate(0f, mouseX * turnSpeed * Time.deltaTime, 0f);

        float inputMouse = mouseY * camSensitivity;
        //float temp = Mathf.Clamp(inputMouse ,75f, -75f);

        cam.localRotation = Quaternion.Euler(-inputMouse, 0f, 0f);

        JumpAndGravity();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(transform.position, checkGroundRadius);
        rb.velocity = movement * playerSpeed * Time.deltaTime;
    }

	private void JumpAndGravity()
	{
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            movement.y *= JumpHeight;
        }
	}

	private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkGroundRadius);
    }
}
