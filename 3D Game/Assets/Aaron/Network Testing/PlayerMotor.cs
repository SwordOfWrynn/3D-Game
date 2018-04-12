﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;


    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Gets a movement vector
    public void Move(Vector3 controlVelocity)
    {
        velocity = controlVelocity;
    }

    //Gets a rotational vector
    public void Rotate(Vector3 controlRotation)
    {
        rotation = controlRotation;
    }

    //Gets a rotational vector for camera
    public void RotateCamera(Vector3 controlCameraRotation)
    {
        cameraRotation = controlCameraRotation;
    }

    //Run every physics iteration
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Perform movement based on velocity variable
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    //Perform rotation
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }

}
