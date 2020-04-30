/*
 *  Allows the map on the wall to be collected and opened via onscreen button as well as closed.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour, Interactable
{

    public GameObject mapparent; //map parent

    public string mapbutton; 
    public GameObject maponthewall; 
    public Text texttoshow;
    public GameObject GUImapbutton;

    // Start is called before the first frame update
    void Start()
    {
        if (mapparent != null)
        {
            texttoshow.enabled = false;
            GUImapbutton.SetActive(false);
        }
    }

    public void MapButtonPress()
    {
		mapparent.SetActive(!mapparent.activeInHierarchy) ;
        GUImapbutton.SetActive(!GUImapbutton.activeInHierarchy);
    }

    public void Interact()
    {
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
