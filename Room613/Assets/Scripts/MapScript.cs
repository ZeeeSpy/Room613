using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{

    public Canvas mapparent; //map parent

    public GameObject mapimg; //map screen

    public string mapbutton; //m 
    public GameObject maponthewall; //physical map 

    bool mapcollected = false;
    bool mapisshowing = false;

    public Text texttoshow;


    // Start is called before the first frame update
    void Start()
    {
        if (mapparent != null)
        {
            mapparent.enabled = false; //canvas
            mapimg.SetActive(false); //map screen
            texttoshow.enabled = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(mapbutton) && mapcollected)
        {
           Debug.Log("MapButtonPressed");
           if (mapisshowing)
            {
                mapimg.SetActive(false);
                mapisshowing = false;
            } else
            {
                mapimg.SetActive(true);
                mapisshowing = true;
            }
        } if (Input.GetButtonDown(mapbutton) && !mapcollected)
        {
            Debug.Log("MapButtonPressedWithNoMap");
            //do nothing
        }
    }

    public void mapcollect()
    {
        mapcollected = true;
        mapparent.enabled = true;
        maponthewall.transform.localScale = new Vector3(0,0,0); //make invisible
        Debug.Log("Map Collected");
        texttoshow.enabled = true;
        Invoke("hidetext", 5);
    }

    private void hidetext()
    {
        texttoshow.enabled = false;
    }

}
