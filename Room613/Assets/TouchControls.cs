using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TouchControls : MonoBehaviour
{
    public FixedJoystick MoveJoystick;
    public FixedJoystick LookJoystick;
    public float sensitivity = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var fps = GetComponent<FirstPersonController>();

        fps.RunAxis = MoveJoystick.Direction;
        fps.m_MouseLook.LookAxis = LookJoystick.Direction*sensitivity;
    }
}
