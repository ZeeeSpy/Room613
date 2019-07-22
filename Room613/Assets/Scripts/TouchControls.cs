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
    }

    // Update is called once per frame
    void Update()
    {
        var fps = GetComponent<FirstPersonController>();

        fps.RunAxis = MoveJoystick.Direction;
        fps.m_MouseLook.LookAxis = LookJoystick.Direction*sensitivity;

        if (Input.GetKeyDown(KeyCode.Escape)) {SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); }
    }
}
