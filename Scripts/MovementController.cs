using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private CharacterController characterController;
    public float speed = 10.0f;

    private float gravity = -9.8f;
    private Vector3 velocity;

    public Transform groundPos;
    private bool isGrounded;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundPos.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * hor + transform.forward * ver;
        characterController.Move(dir * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
