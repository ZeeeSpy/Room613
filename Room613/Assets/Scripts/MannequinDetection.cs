using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinDetection : MonoBehaviour
{
    public MannequinAIScript thisMannequin;

    private void Start()
    {
        thisMannequin.playerundetected();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            thisMannequin.playerdetected();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            thisMannequin.playerundetected();
        }
    }
}
