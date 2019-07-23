/*
 * Upon collection of the sloth coin play a sound and deactivte a coin. Simmilar to coin script but
 * does more 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothCoinLightScript : MonoBehaviour, Interactable
{
    public Light thislight;
    public GameObject coin;
    public AudioSource buzz;
    public int coinnumber;
    public CoinPuzzleScript thispuzzlescript;


    public void Interact()
    {
        buzz.Play();
        thislight.enabled = false;
        coin.SetActive(false);
        thispuzzlescript.getcoin(coinnumber);
    }
}
