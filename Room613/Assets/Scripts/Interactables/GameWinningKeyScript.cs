/*
 * CoinPuzzleScript calls this to enable the game winning triggers.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinningKeyScript : MonoBehaviour, Interactable
{
    public GameObject finalinteractA;
    public GameObject finalinteractB;
    public GameObject self;

    public void Interact()
    {
        finalinteractA.SetActive(true);
        finalinteractB.SetActive(true);
        self.SetActive(false);
    }
}
