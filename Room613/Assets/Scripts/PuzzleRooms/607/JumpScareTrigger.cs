/*
 *  Used to ready JumpScarelocker signaling where the player is in relation to the triggers
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{
    public KL knockingdoor;
    public JumpScareLocker thisjumpscare;
    bool trigger = false;
    bool oneshot = true;

    void OnTriggerEnter(Collider collision)
    {
        trigger = knockingdoor.getactivated();
        if (collision.CompareTag("Player") && trigger && oneshot)
        {
            thisjumpscare.readyup();
            oneshot = false;
        }
    }
}
