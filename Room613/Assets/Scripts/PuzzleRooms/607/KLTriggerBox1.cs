/*
 *  signals when player is in the locker room
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLTriggerBox1 : MonoBehaviour
{
    public KL knockinglocker;
    bool activated = false;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && !activated)
        {
            knockinglocker.playsound();
            activated = true;
        } else
        {
            //
        }
    }
}
