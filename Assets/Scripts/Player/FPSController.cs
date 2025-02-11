﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
 // public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

       // Lock cursor asAS
 //       Cursor.lockState = CursorLockMode.Locked;
 //       Cursor.visible = false;
    }

    void Update()
    {
        Move();
        CameraRotation();
    }
    void Move()
    {
        Vector3 forward = RecalculateMoveDirection(Vector3.forward);
        Vector3 right = RecalculateMoveDirection(Vector3.right);

        float curSpeedX = 0;
        if (canMove) curSpeedX = walkingSpeed* Input.GetAxis("Vertical");
        float curSpeedY = 0;
        if (canMove) curSpeedY =  walkingSpeed* Input.GetAxis("Horizontal");

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        //if (Input.GetButton("Jump") && canMove && characterController.isGrounded) moveDirection.y = jumpSpeed;
        //moveDirection.y = movementDirectionY;

        Gravity();
        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
    void Gravity()
    {
        if (!characterController.isGrounded) moveDirection.y -= gravity * Time.deltaTime;
    }
    void CameraRotation()
    {
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
    Vector3 RecalculateMoveDirection(Vector3 v)
    {
        return transform.TransformDirection(v);
    }
    public bool GetCanMove()
    {
        return canMove;
    }
}