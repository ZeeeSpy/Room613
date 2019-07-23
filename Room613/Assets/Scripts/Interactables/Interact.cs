/*
 * Raycast is shot out of First person controller and checks for objects that use 
 * the "interactable" interface. When an interactable is hit show the UI hand
 * on screen press the interactable object is interacted with.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for image

public class Interact : MonoBehaviour
{
    public string interactbutton;
    public LayerMask interactLayer;

    public Image interactIcon;
    public float interactionDistance;
    public bool isInteracting;
    public GameObject theplayer; 
    private bool OSBD = false;

    // Start is called before the first frame update
    void Start()
    {
        if (interactIcon != null)
        {
            interactIcon.enabled = false;
        }
    }

    public void OnScreenButtonDown()
    {
        OSBD = true;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance,interactLayer)) //Raycast sees through walls and objects can be interacted with through other coliders
        {
                if (isInteracting == false) //if player isn't interacting with something else
                {
                    if (interactIcon != null)
                    {
                        interactIcon.enabled = true;
                    }
                if (OSBD || Input.GetButtonDown("Interact"))
                    {
                        OSBD = false;
                        Interactable iinteractable = hit.collider.GetComponent<Interactable>();
                        if (iinteractable != null)
                            {
                                iinteractable.Interact();
                            }
                    }

                }
        } else {
            interactIcon.enabled = false;
            OSBD = false;
        }
    }
}
