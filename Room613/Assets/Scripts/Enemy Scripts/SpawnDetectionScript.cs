/*
 * Script used by mannequinAI to see where a sfe place to spawn is. Ideally mannequin teleports to an
 * area where there isn't another mannequin or player, this script helps facilitate that.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDetectionScript : MonoBehaviour
{
    [SerializeField]
    public bool actorDetected = false;
    [SerializeField]
    public int numberofactors;
    //check spawn points if there's a mannequin or player there
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Mannequin"))
        {
            numberofactors = numberofactors + 1;
            actorchecker();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Mannequin"))
        {
            numberofactors = numberofactors - 1;
            actorchecker();
        }
    }

    private void actorchecker()
    {
        if (numberofactors < 0)
        {
            actorDetected = false;
        } else
        {
            actorDetected = true;
        }
    }

    public bool isactorDetected()
    {
        return actorDetected;
    }
}
