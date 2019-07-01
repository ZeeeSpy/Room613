using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinningKeyScript : MonoBehaviour
{
    public GameObject finalinteractA;
    public GameObject finalinteractB;
    public GameObject self;

    public void opendoor()
    {
        finalinteractA.SetActive(true);
        finalinteractB.SetActive(true);
        self.SetActive(false);
    }
}
