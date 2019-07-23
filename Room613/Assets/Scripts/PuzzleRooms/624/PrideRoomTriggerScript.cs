/*
 *  If the player tries to work through the corridor and activates the third collider the players position
 *  is changed to make it seem as though the corridor is infinite.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrideRoomTriggerScript : MonoBehaviour
{
    public PrideRoomPuzzle thispuzzle;
    public int thistrigger;
    public GameObject theplayer;
    bool teleported = false;


    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            teleported = true;
            thispuzzle.activatetrig(3);
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            teleported = false;
        }
    }

    private void Update()
    {
        if (teleported)
        {
            Debug.Log("Teleported");
            theplayer.GetComponent<CharacterController>().enabled = false;
            theplayer.transform.position = new Vector3(-47.00f, theplayer.transform.position.y, theplayer.transform.position.z);  
            theplayer.GetComponent<CharacterController>().enabled = true; 
            teleported = false;
            /*
            100% of the credit for this goes to https://forum.unity.com/threads/does-transform-position-work-on-a-charactercontroller.36149/
            Unity changed the behaviour of character controllers and transforms at some point and didn't document it. 
            */

        }

    }

}
