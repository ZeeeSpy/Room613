/*
 * Script used to update what coins the player has collected. upon collection of all coins and activating 
 * the coin box this script also enables the winning triggers at the stair doors.
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPuzzleScript : MonoBehaviour, Interactable
{
    public Canvas thiscanvas;
    public Text needmorecoins;
    public Text youwin;

    public bool toggle = true;

    public GameObject finaltrig1;
    public GameObject finaltrig2;

    private int count = 0;
    //key stuff
    public GameObject Key;

	[SerializeField]
	private bool[] CoinCheck = new bool[6] {true,false,false,false,false,false};
	private bool alltrue = false;

    private void Start()
    {
        Key.SetActive(false);
        finaltrig1.SetActive(false);
        finaltrig2.SetActive(false);
        thiscanvas.enabled = false;
        needmorecoins.enabled = false;
        youwin.enabled = false;
    }

    public void getcoin(int a) //TODO replace with switch
    {
		CoinCheck[a] = true;
		count++;

		foreach (bool tf in CoinCheck)
		{
			if (tf == false)
			{
				return;
			}
		}

		alltrue = true;
    }

    public void Interact()
    {
        if (alltrue)
        {
            if (toggle)
            {
                thiscanvas.enabled = true;
                youwin.enabled = true;
                Invoke("hidetext", 10);
                Key.SetActive(true);
                toggle = false;
            }

        } else
        {
            thiscanvas.enabled = true;
            needmorecoins.enabled = true;
            Invoke("hidetext", 5);
        }
    }

    private void hidetext()
    {
        needmorecoins.enabled = false;
        youwin.enabled = false;
    }

    public string coincount()
    {
        return count.ToString(); ;
    }
}
