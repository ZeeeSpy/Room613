using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stage1UIScript : MonoBehaviour
{
    public Image q1;
    public Image q2;
    public Text hint1;
    public Text hint2;
    public Text Stage2Start;
    private Text texttohide;
    public Image q3;
    

    bool active1 = false;
    bool active2 = false;
    bool first = true;


    void Start()
    {
        q1.enabled = true; 
        q2.enabled = true;
        q3.enabled = false;
        hint1.enabled = false;
        hint2.enabled = false;
        Stage2Start.enabled = false;
    }

    private void stage1x1() {
        active1 = true;
        hint1.enabled = true;
        texttohide = hint1;
        q1.enabled = false;
        Invoke("hidetext", 5);
    }

    private void stage1x2()
    {
        active2 = true;
        hint2.enabled = true;
        texttohide = hint2;
        q2.enabled = false;
        q3.enabled = true;
        Invoke("hidetext", 5);
    }


    private void hidetext()
    {
        texttohide.enabled = false;
    }

    public void stage2check()
    {
        if (active1 & active2){
            Stage2Start.enabled = true;
            texttohide = Stage2Start;
            q3.enabled = false;
            Invoke("hidetext", 5);
        }
    }

    public void whichstair()
    {
        if (!first)
        {
            stage1x2();
        } else
        {
            first = !first;
            stage1x1();
        }
    }
}
