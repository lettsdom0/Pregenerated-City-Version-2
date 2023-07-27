using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*
    // complete sciprt from https://www.noob-programmer.com/unity3d/basic-movement-in-unity3d/
    */
    CharacterController characterController;
    public float movementSpeed = 5.0f;
    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = moveDirection * movementSpeed;
        }
        //Gravity
        moveDirection.y -= 10f * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

}
