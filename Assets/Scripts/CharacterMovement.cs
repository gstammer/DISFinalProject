using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    //public float flightSpeed = 2f;



    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    //public State state;


    Vector3 velocity;
    bool isGrounded;


    void Start()
    {
        //state = State.WALKING;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward.normalized;
        Vector3 right = Camera.main.transform.right.normalized;

        Vector3 movement = z * forward + x * right;
        movement.y = 0;

        //transform.Translate(movement * speed * Time.deltaTime, Space.World);


        controller.Move(movement * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
