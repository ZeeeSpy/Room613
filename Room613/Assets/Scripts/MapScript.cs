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
    public Text texttoshow;
    public GameObject GUImapbutton;
    public GameObject GUImapbuttonExit;

    // Start is called before the first frame update
    void Start()
    {
        if (mapparent != null)
        {
            mapparent.enabled = false; //canvas
            mapimg.SetActive(false); //map screen
            texttoshow.enabled = false;
            GUImapbutton.SetActive(false);
            GUImapbuttonExit.SetActive(false);
        }
    }

    public void MapButtonPress()
    {
        mapimg.SetActive(true);
        GUImapbutton.SetActive(false);
        GUImapbuttonExit.SetActive(true);
    }

    public void MapButtonExitPress()
    {
        Debug.Log("MapExit");
        mapimg.SetActive(false);
        GUImapbutton.SetActive(true);
        GUImapbuttonExit.SetActive(false);
    }

    public void mapcollect()
    {
        mapparent.enabled = true;
        maponthewall.transform.localScale = new Vector3(0,0,0); //make invisible
        Debug.Log("Map Collected");
        GUImapbutton.SetActive(true);
        texttoshow.enabled = true;
        Invoke("hidetext", 5);
    }

    private void hidetext()
    {
        texttoshow.enabled = false;
    }

}
