using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLTriggerBox : MonoBehaviour
{
    public KL knockinglocker;
    bool activated = false;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && !activated)
        {
            knockinglocker.stopsound();
            activated = true;
        }
        else
        {
            //
        }
    }
}
