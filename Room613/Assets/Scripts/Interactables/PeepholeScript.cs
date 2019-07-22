using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PeepholeScript : MonoBehaviour, Interactable
{
    public GameObject coin;
    public GameObject theplayer;
    public AudioSource coindropsound;
    bool isenabled;
    public Camera roomcanvas;
    public Light peepholelight;
    public GameObject manequina;
    public AudioSource lightfizz;
    public GameObject backbutton;
    public GameObject UI;
    public GameObject UI2;
    public AudioListener secondcamlistener;

    void Start()
    {
        coin.SetActive(false);
        roomcanvas.enabled = false;
        isenabled = false;
        secondcamlistener.enabled = false;
    }

    public void Interact()
    {
        roomcanvas.enabled = true;
        backbutton.SetActive(true);
        UI.SetActive(false);
        UI2.SetActive(false);
        if (!isenabled)
        {
            StartCoroutine(Peepholesequence());
            isenabled = true;
        } 
    }

    public void stoplooking()
    {
        roomcanvas.enabled = false;
        backbutton.SetActive(false);
        UI.SetActive(true);
        UI2.SetActive(true);
    }

    IEnumerator Peepholesequence()
    {
        yield return new WaitForSeconds(2.0f);
        lightfizz.Play();
        yield return new WaitForSeconds(1.2f);
        peepholelight.intensity = 0;
        manequina.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        lightfizz.Play();
        peepholelight.intensity = 1;
        coin.SetActive(true);
        coindropsound.Play();
        isenabled = true;
    }
}
