using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject thiskey;
    public DoorScript doortounlock;


    public void keyaction()
    {
        thiskey.SetActive(false);
        doortounlock.unlockme();
    }
}
