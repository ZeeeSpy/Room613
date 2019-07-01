using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PeepholeScript : MonoBehaviour
{
    public GameObject coin;
    public GameObject theplayer;
    public AudioSource coindropsound;
    bool isenabled;
    public Canvas roomcanvas;

    void Start()
    {
        coin.SetActive(false);
        roomcanvas.enabled = false;
        isenabled = false;
    }

    public void lookthroughhole()
    {
        theplayer.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        roomcanvas.enabled = true;
        if (!isenabled)
        {
            coin.SetActive(true);
            coindropsound.Play();
            isenabled = true;
        }
    }

    public void stoplooking()
    {
        roomcanvas.enabled = false;
        theplayer.GetComponent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
