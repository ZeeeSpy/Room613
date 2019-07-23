/*
 *  Used for the lift buttons. Simmilar to door script but with no Update loop making it more efficient
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButtonScript : MonoBehaviour, Interactable
{
    public AudioSource elevatorbutton;

    public void Interact()
    {
        {
            elevatorbutton.Play();
        }
    }
}
