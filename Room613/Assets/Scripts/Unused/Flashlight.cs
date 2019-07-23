/*
 *  Unused script: A way for the flashlight to be toggled on and off, not used because there's no reason
 *  to ever turn off the flashlight.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    public bool flashlighton;
    // Start is called before the first frame update
    void Start()
    {
        flashlighton = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            if (flashlighton)
            {
                flashlight.enabled = false;
                flashlighton = false;
            } else
            {
                flashlight.enabled = true;
                flashlighton = true;
            }

        //flashlight object to check light status for monsters

        //todo flashlight flicker
    }

     public bool Getflashlighton { get { return flashlighton; } }
}
