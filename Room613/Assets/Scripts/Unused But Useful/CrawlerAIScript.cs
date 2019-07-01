using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrawlerAIScript : MonoBehaviour
{
    public Flashlight playerflashlight;
    public CrawlerDetectionScript BigDetectionSphere;
    public GameObject bigphysical;
    public CrawlerDetectionScript SmallDetectionSphere;
    public GameObject smallphysical;
    private CrawlerDetectionScript CurrentSphere;
    private NavMeshAgent myAgent;
    public Transform target;

    private void Start()
    {   //disable both spheres at start

        bigphysical.SetActive(false);
        smallphysical.SetActive(false);
        myAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        //checking players flashlight status
        if (playerflashlight.Getflashlighton)
        {
            bigphysical.SetActive(true);
            smallphysical.SetActive(false);
            CurrentSphere = BigDetectionSphere;
        } else
        {
            smallphysical.SetActive(true);
            bigphysical.SetActive(false);
            CurrentSphere = SmallDetectionSphere;
        }

        if (CurrentSphere.getPlayerDetected())
        {
            myAgent.SetDestination(target.position);
        }
    }
}

