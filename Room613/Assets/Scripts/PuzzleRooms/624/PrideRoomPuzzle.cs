/*
 *  Checks to see in which order the three triggers in the infinite corridor are acitaved
 *  if activated in the wrong order nothing happens.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrideRoomPuzzle : MonoBehaviour
{
    bool trig1 = false;
    bool trig2 = false;
    bool trig3 = false;
    public GameObject coin;
    public Light thislight;

    private void Start()
    {
        coin.SetActive(false);
        thislight.enabled = false;
    }

    public void activatetrig1(){ 
            if (trig1 & trig2 & !trig3)
        {
            coin.SetActive(true);
            thislight.enabled = true;


        }   else //if puzzle isn't complete reset triggers
        {
            trig2 = false;
            trig3 = false;
            trig1 = true;
        }
        }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            activatetrig1(); //check if puzzle is complete
        }
    }

    public void activatetrig(int trig)
    {
        if (trig == 2)
        {
            trig2 = true;
        } else if (trig == 3)
        {
            trig3 = true;
        } else
        {
            Debug.Log("unexpected else if in pride room trigger script");
        }
    }
}
