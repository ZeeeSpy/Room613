using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HintTrigger : MonoBehaviour
{

    public Text texttoshow;
    bool activated = false; 

    void Start()
    {
        texttoshow.enabled = false;
    }

    private void hidetext()
    {
        texttoshow.enabled = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && !activated)
        {
            activated = true;
            texttoshow.enabled = true;
            Invoke("hidetext", 5);
        }
    }
}
