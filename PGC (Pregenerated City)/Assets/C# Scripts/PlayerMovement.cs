using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController thisCharController;
    protected float movementSpeed = 5.0f;
    protected float smoothTurnTime = 1.0f;
    float TurnVel;
    void Start()
    {

    }
    void LateUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new(horizontal, 0f, vertical);
        if(moveDirection.magnitude > 0.1f)
        {
            float desiredAngle = Mathf.Atan2(moveDirection.x,moveDirection.z) * Mathf.Rad2Deg;
            float turnAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, desiredAngle, ref TurnVel, smoothTurnTime);
            transform.rotation = Quaternion.Euler(0f,turnAngle,0f);

            thisCharController.Move(moveDirection * movementSpeed * Time.deltaTime);
        }

    }

}
