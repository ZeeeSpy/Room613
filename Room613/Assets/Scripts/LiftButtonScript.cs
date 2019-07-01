using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButtonScript : MonoBehaviour
{
    public Stage1UIScript stage1script;
    public AudioSource elevatorbutton;

    public void liftmethod()
    {
        {
            elevatorbutton.Play();
        }
    }
}
