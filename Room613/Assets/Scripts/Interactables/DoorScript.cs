using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour, Interactable
{
    //bools for remembering door position
    public bool open = false; //all door are closed by default
    public bool locked = true; //all doors are locked by default

    //door opening/closing values
    public float openangle = -105f;
    public float closeangle = 0f;
    public float smooth = 1f;

    //audio setup 
    public AudioSource dooropen;
    public AudioSource doorclose;
    public AudioSource doorlocked;
    public AudioSource doorunlock;
    bool setup = false;

    //add UI marker to locked doors
    public Image lockeddoorcross;
    public Image opendoorarrow; 

    void Start()
    {
        if (lockeddoorcross != null) { lockeddoorcross.enabled = false; }
        if (opendoorarrow != null) { opendoorarrow.enabled = false; } 
    }
    void Update()
    {
      if (open){
            Quaternion targetRotationOpen = Quaternion.Euler(0,0,openangle);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, (smooth * Time.deltaTime)*3);
        }  else {
            Quaternion targetRotationClosed = Quaternion.Euler(0,0, closeangle);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClosed, (smooth * Time.deltaTime)*4);
        }
    }

    public void Interact()
    {
        if (!setup)
        {
            setupbecauseimstupid();
        }
        //if door is locked 
        if (locked)
        {
            doorlocked.Play();
            lockeddoorcross.enabled = true;
        }

        //if door is not locked
        else if (!locked) {
                open = !open;
                try { opendoorarrow.enabled = true; } catch { Debug.Log("MapOpenArrowNotSet"); }
                try { lockeddoorcross.enabled = false; } catch { Debug.Log("MapLockedCrossNotSetOnOpenDoor"); }
                
                if (dooropen != null && open)
                {
                    doorclose.Play();
                }
                else if (doorclose != null && !open)
                {
                    dooropen.Play();
                }
            }
    }

    private void setupbecauseimstupid()
    {
        try
        {
            dooropen.volume = 0.3f;
            doorclose.volume = 0.3f;
            doorlocked.volume = 0.3f;
            setup = true;
        } catch
        {
            //Door is probably not openable/not lockable
        }
    }   

    public void unlockme()
    {
        locked = false;
    }
}
