
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
                    if (OSBD)
                    {
                    //highly inefficient but works for the purposes of the game
                    OSBD = false;
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
        } else {
            interactIcon.enabled = false;
            OSBD = false;
        }
    }
}
