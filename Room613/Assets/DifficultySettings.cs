/*
 *  Script used to control difficulty in game as set in settings menu
 *  will need refactoring to allow ease of adding more enemies
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySettings : MonoBehaviour
{
    int difficulty;
    public GameObject mannequina;
    public GameObject mannequinb;
    public GameObject mannequinc;

    void Start()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");
        if (difficulty == 0)
        {
            mannequinb.SetActive(false);
            mannequina.SetActive(false);
        } else if (difficulty == 1)
        {
            mannequinb.SetActive(false);
        } else
        {
            //do nothing all mannequins are active
        }
    }
}
