using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int coinnumber;
    public GameObject thiscoin;
    public CoinPuzzleScript thispuzzlescript;

    public void activatecoin()
    {
        thispuzzlescript.getcoin(coinnumber);
        thiscoin.SetActive(false);
    }
}
