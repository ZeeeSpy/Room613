using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButtonScript : MonoBehaviour, Interactable
{
    public Stage1UIScript stage1script;
    public AudioSource elevatorbutton;

    public void Interact()
    {
        {
            elevatorbutton.Play();
        }
    }
}
