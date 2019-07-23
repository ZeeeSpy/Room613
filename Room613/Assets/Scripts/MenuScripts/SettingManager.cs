/*
 *  Script used in the settings menu to update the playerPrefs. 
 *  Currently includes: joystick opacity, sensitivty
 *  Soon will indlude: Difficulty, Brightness
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public GameObject Uibuttons;
    public GameObject Settings;

    private const string OPACITY_PREF = "joystick_opacitiy";
    private const string SENSITIVITY_PREF = "joystick_sensitivity";
    private const string DIFFICULTY_PREF = "difficulty";
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private int opacity;

    public Slider opacityslider;
    public Slider sensitivityslider;

    private void SetPref(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    private void SetPref(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    private float GetPrefFloat(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }

    private int GetPrefInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey(SENSITIVITY_PREF))
        {
            sensitivity = GetPrefFloat(SENSITIVITY_PREF);
            opacity = GetPrefInt(OPACITY_PREF);
            opacityslider.value = opacity;
            sensitivityslider.value = sensitivity;
            Debug.Log("Settings Updated");
        } else
        {
            SetPref(SENSITIVITY_PREF, 1.1f);
            SetPref(OPACITY_PREF, 200);
        }
    }

    public void OpenSettings()
    {
        Uibuttons.SetActive(false);
        Settings.SetActive(true);
    }

    public void Back()
    {
        Uibuttons.SetActive(true);
        Settings.SetActive(false);
        SetPref(OPACITY_PREF, opacity);
        SetPref(SENSITIVITY_PREF, sensitivity);
        Debug.Log(PlayerPrefs.GetInt(OPACITY_PREF));
    }

    public void SetSensitivity(Slider slider)
    {
        sensitivity = slider.value;
    }

    public void SetOpacity(Slider slider)
    {
        opacity = (int)slider.value;

    }
}
