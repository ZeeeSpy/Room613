using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prideroomtrig2 : MonoBehaviour
{
    public PrideRoomPuzzle thispuzzle;
    public int thistrigger;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            thispuzzle.activatetrig(thistrigger);
        }
    }

}