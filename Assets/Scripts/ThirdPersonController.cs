using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public Transform thirdPersonCamera;
    private float smoothVelocity = 5;
    private float smoothTime = 1;

    private Rigidbody rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        float moveLeftRight   = Input.GetAxis("Horizontal");
        float moveForwardBack = Input.GetAxis("Vertical");

        var direction = new Vector3(moveLeftRight, 0f, moveForwardBack).normalized;


        if (direction.magnitude > 0.1f)
        {
            var angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + thirdPersonCamera.eulerAngles.y;

            var smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref smoothVelocity, smoothTime);

            var moveDir = Quaternion.Euler(0f, smoothAngle, 0f) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(moveDir * speed * Time.deltaTime);
        }

    }
} 