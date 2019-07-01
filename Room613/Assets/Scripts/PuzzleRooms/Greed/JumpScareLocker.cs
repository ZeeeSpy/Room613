using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareLocker : MonoBehaviour
{
    public AudioSource loudsound;
    bool ready = false;

    // Update is called once per frame

    
   
    void Update()
    {
        if (ready){
            //transform.localRotation = Quaternion.Euler(openangle);

            Quaternion targetRotationOpen = Quaternion.Euler(-90, 0, 170);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, (500 * Time.deltaTime));
        }
    }

    public void readyup()
    {
        ready = true;
        loudsound.Play();
    }
}
