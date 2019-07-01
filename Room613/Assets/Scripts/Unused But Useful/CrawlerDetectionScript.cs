using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerDetectionScript : MonoBehaviour
{
    [SerializeField] //for debugging
    private bool detectplayer = false;
    public CrawlerDetectionScript otherscript;
    public GameObject othersphere;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) //if we hit the player
        {
            detectplayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) //if we hit the player
        {
            detectplayer = false;
        }
    }

    private void Update()
    {
        if (!othersphere.activeInHierarchy)
        {
            otherscript.killdetection();
        }
    }

    public void killdetection()
    {
        detectplayer = false;
    }

    public bool getPlayerDetected(){
        return detectplayer;
    }

}