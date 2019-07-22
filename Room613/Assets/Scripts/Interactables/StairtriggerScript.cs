using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairtriggerScript : MonoBehaviour, Interactable
{
    public Stage1UIScript stage1script;
    bool activated = false;
    public AudioSource opendoorsound; 

    public void Interact()
    {
        opendoorsound.Play();
        if (!activated)
        {
            activated = true;
            stage1script.whichstair();
        }
    }
}
