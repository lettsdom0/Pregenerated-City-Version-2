using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A Regular Camera Follow script that allows the camera to follow the player smoothly
/// </summary>
public class PlayerFollow : MonoBehaviour
{
    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    
    protected float SmoothFactor = 0.5f;

    protected bool LookAtPlayer = true;

    protected bool RotateAroundPlayer = false;

    [SerializeField]protected float RotationSpeed = 5.0f;
    private void Awake()
    {
        if (PlayerTransform == null)
        {
            PlayerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // LateUpdate is called after update
    void LateUpdate()
    {
        toggleRotate();
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
    /// <summary>
    /// <para>Plain and simple, the function allows the player to toggle camera rotation.</para>
    /// Simply put, function checks if the player has pressed C or not before toggling rotation on(if RotateAroundPlayer false) or off(if RotateAroundPlayer true).
    /// </summary>
    internal void toggleRotate()
    {
        bool CDown = Input.GetKeyDown(KeyCode.C);
        switch (CDown)
        {
            case false:
                break;
            case true:
                switch (RotateAroundPlayer)
                {
                    case true:
                        RotateAroundPlayer = false;
                        break;
                    case false:
                        RotateAroundPlayer = true;
                        break;
                }
                break;
        }
    }
}
