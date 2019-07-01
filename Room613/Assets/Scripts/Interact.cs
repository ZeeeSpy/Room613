
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

    // Start is called before the first frame update
    void Start()
    {
        if (interactIcon != null)
        {
            interactIcon.enabled = false;
        }
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
                    if (Input.GetButtonDown(interactbutton))
                    {

                        /*should really be done with a interactable object and everything inherits from it. so it's if interact layer, if interactable, getcomponent.interact();
                        * but don't know how to do multiple inheritance or how to reconstruct the code in order for it to work better. it works now but it's horribly inefficient
                        * works for now but needs to be changed. UPDATE, I should learn to read children dont need to inherit monobehaviour since they already inherit it from the parent object. 
                        * sadly I realized this too late, but for future referance this can be made a load clearner. 
                        */
                        if (hit.collider.CompareTag("Door"))
                        {
                            hit.collider.GetComponent<DoorScript>().opendoor();
                        }
                        else if (hit.collider.CompareTag("Map"))
                        {
                            hit.collider.GetComponent<MapScript>().mapcollect();
                        }
                        else if (hit.collider.CompareTag("Locker"))
                        {
                            hit.collider.GetComponent<KL>().openlocker();
                        }
                        else if (hit.collider.CompareTag("LiftButton"))
                        {
                            hit.collider.GetComponent<LiftButtonScript>().liftmethod();
                        }
                        else if (hit.collider.CompareTag("stair"))
                        {
                            hit.collider.GetComponent<StairtriggerScript>().stairscritpt();
                        }
                        else if (hit.collider.CompareTag("Key"))
                        {
                            hit.collider.GetComponent<KeyScript>().keyaction();
                        }
                        else if (hit.collider.CompareTag("Bookshelf"))
                        {
                            hit.collider.GetComponent<MoveBookShelf>().moveme();
                        }
                        else if (hit.collider.CompareTag("Coin"))
                        {
                            hit.collider.GetComponent<CoinScript>().activatecoin();
                        }
                        else if (hit.collider.CompareTag("Peephole"))
                        {
                            hit.collider.GetComponent<PeepholeScript>().lookthroughhole();
                        }
                        else if (hit.collider.CompareTag("SlothCoin"))
                        {
                            hit.collider.GetComponent<SlothCoinLightScript>().activate();
                        }
                        else if (hit.collider.CompareTag("Cointable"))
                        {
                            hit.collider.GetComponent<CoinPuzzleScript>().interactwithbox();
                        } 
                        else if (hit.collider.CompareTag("StairKey"))
                        {
                            hit.collider.GetComponent <GameWinningKeyScript>().opendoor();
                        }
                        else if (hit.collider.CompareTag("FinalTrigger"))
                        {
                            hit.collider.GetComponent<YouWinScript>().youwin();
                        }
                    }

                }
        } else {interactIcon.enabled = false;}
    }
}
