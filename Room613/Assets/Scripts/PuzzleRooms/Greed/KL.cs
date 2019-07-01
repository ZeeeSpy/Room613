using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KL : MonoBehaviour
{
    public bool open = false;
    public AudioSource knockingsound;
    public float openangle = 114f;
    public float closeangle = 0f;
    public float smooth = 5f;
    public AudioSource lockeropen;
    private bool activated = false;

    public void playsound()
    {
        knockingsound.Play();
    }

    public void stopsound()
    {
        knockingsound.Stop();
    }

    private void Update()
    {
        if (open)
        {
            activated = true;
            knockingsound.Stop();
            //transform.localRotation = Quaternion.Euler(openangle);
            Quaternion targetRotationOpen = Quaternion.Euler(-90, 0, openangle);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, (smooth * Time.deltaTime));
        }

        if (!open)
        {
            transform.localRotation = Quaternion.Euler(-90,0, (Mathf.Sin(Time.time * 30)*1));
        }
    }

    public void openlocker()
    {
        if (!activated)
        {
            open = !open;
            lockeropen.Play();
        }
     }

    public bool getactivated()
    {
        return activated; 
    }
}
