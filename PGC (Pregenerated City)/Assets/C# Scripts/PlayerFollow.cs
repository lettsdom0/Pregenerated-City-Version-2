using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    
    public float SmoothFactor = 0.5f;

    public bool LookAtPlayer = true;

    private bool RotateAroundPlayer = false;

    public float RotationSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerTransform == null)
        {
            PlayerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    void Update()
    {
        toggleRotate();
    }
    // LateUpdate is called after update
    void LateUpdate()
    {
        if (RotateAroundPlayer)
        {
            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            _cameraOffset = camTurnAngle * _cameraOffset;
        }
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        if (LookAtPlayer || RotateAroundPlayer)
            transform.LookAt(PlayerTransform);
    }
    public void toggleRotate()
    {
        if (Input.GetKeyDown(KeyCode.C) && RotateAroundPlayer == true)
        {
            RotateAroundPlayer = false;
        }
        else if (Input.GetKeyDown(KeyCode.C) && RotateAroundPlayer == false)
        {
            RotateAroundPlayer = true;
        }
    }
}
