/*
 * Script used by all coins so that when they're interacted with they 
 * dissapear and update the main puzzle count
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour, Interactable
{
    public int coinnumber;
    public GameObject thiscoin;
    public CoinPuzzleScript thispuzzlescript;

    public void Interact()
    {
        thispuzzlescript.getcoin(coinnumber);
        thiscoin.SetActive(false);
    }
}
