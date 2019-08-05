/*
 *  Script in charge of initializing player settings (opacity, sensitivity, and difficulty) on load and 
 *  converting on screen joystick movement to first person controller movement.
 *  on update listens for android buttons. 
 *  
 *  Keyboard controls are used so that the game can be quickly played without a phone on hand
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchControls : MonoBehaviour
{
    public FixedJoystick MoveJoystick;
    public FixedJoystick LookJoystick;
    private float sensitivity = 1.1f;
    public Image Joy1;
    public Image Joy1c;
    public Image Joy2;
    public Image Joy2c;

    void Start()
    {
        Joy1.color = new Color32(255, 255, 255, ((byte)PlayerPrefs.GetInt("joystick_opacitiy")));
        Joy1c.color = new Color32(255, 255, 255, ((byte)PlayerPrefs.GetInt("joystick_opacitiy")));
        Joy2.color = new Color32(255, 255, 255, ((byte)PlayerPrefs.GetInt("joystick_opacitiy")));
        Joy2c.color = new Color32(255, 255, 255, ((byte)PlayerPrefs.GetInt("joystick_opacitiy")));

        sensitivity = PlayerPrefs.GetFloat("joystick_sensitivity");
        Debug.Log(sensitivity);


        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var fps = GetComponent<FirstPersonController>();
        //Touch Controls

        fps.RunAxis = MoveJoystick.Direction;
        fps.m_MouseLook.LookAxis = LookJoystick.Direction*sensitivity;

        /*
        //Keyboard Controls 
        
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
        fps.RunAxis = Movement;
        Vector3 Looking = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"),0 );
        fps.m_MouseLook.LookAxis = Looking;
        */


        AndroidListen();
    }

    private void AndroidListen()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); }
    }
}
