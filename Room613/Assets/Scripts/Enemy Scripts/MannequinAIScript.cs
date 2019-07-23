/*
 * dictates what the mannequin enemies do.
 * If they are being rendered do nothing
 * If they're not rendered and are within distance they move towards the player
 * If the player is close enough kill player
 * If player blocks nav mesh path with door thereby trapping themselves or the mannequin the mannequin
 * teleports to one of 5 predetermined locations.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MannequinAIScript : MonoBehaviour
{
    public GameObject player;
    public bool Chasing;
    public NavMeshAgent myAgent;
    public GameObject self;
    NavMeshPath path;

    //sounds
    public AudioSource chasesound;
    public AudioSource teleportsound;
    bool playing = false;


    //spawning values
    public SpawnDetectionScript A;
    public SpawnDetectionScript B;
    public SpawnDetectionScript C;
    public SpawnDetectionScript D;
    public SpawnDetectionScript E;
    private Vector3 ALoc;
    private Vector3 BLoc;
    private Vector3 CLoc;
    private Vector3 DLoc;
    private Vector3 ELoc;
    public int prefLoc;

    public KillBoxScript mykillbox;

    private void Start()
    {
        ALoc = new Vector3(0.5f,1,22);
        BLoc = new Vector3(-21,1,2);
        CLoc = new Vector3(2,1,2);
        DLoc = new Vector3(23,1,-14);
        ELoc = new Vector3(21, 1, -22);
    }
    void Update()
    {

        /*
         if mannequin is chasing, check to see if it has a path, if not teleport it
         if it does have a path and is invisible follow the player
         if it has a path and is visible stop. 
         */

        if (Chasing)
        {
            NavMeshPath path = new NavMeshPath(); //used to see if mannequin is trapped or not
            myAgent.CalculatePath(player.transform.position, path);

            if (path.status == NavMeshPathStatus.PathPartial) // The agent is trapped
            {
                Debug.Log("Mannequin is trapped :(");
                // teleportmannequin(); //teleport mannequin to corridor space that player isn't occupying
                teleportme();
            }


        }

        if (Chasing && (gameObject.GetComponent<Renderer>().isVisible == false)) //if the mannequin is chasing the player and cannot be seen chase
        {
                myAgent.SetDestination(player.transform.position);  //if not trapped i.e. agent has path to player
                Debug.Log("Manneqiun Following Player");
                playchasesound(true);

            if (mykillbox.getplayer())
            {
                Debug.Log("PlayerDead");
                gameover();
            }
        } else if (gameObject.GetComponent<Renderer>().isVisible == true) //if the mannequin can be seen
        {
            playchasesound(false);
            myAgent.isStopped = true;
            myAgent.ResetPath();
            Debug.Log("Manneqiun StoppedFollowing Player");
        }
         
    }

    private void playchasesound(bool todo) //handles the chase sound effect
    {
        if (!playing && todo) //if not playing and is chasing
        {
            chasesound.Play();
            playing = true;
        } else if (playing && todo) // if playing and chasing
        {
            //do nothing
        } 

        if (playing && !todo) //if playing anot not chasing
        {
            chasesound.Stop();
            playing = false;
        } else if (!playing && !todo)
        {
            //do nothing
        }
    }


    public void playerdetected()
    {
        Chasing = true;
    }

    public void playerundetected()
    {
        Chasing = false;
    }

    private void teleportme() //TODO refactor to make it more readable/efficient
    {
        //PrefLoc stops manniquens being teleported ontop of eachother
        if (prefLoc == 1 && A.isactorDetected() == false)
        {
            Debug.Log("Teleported To A Pref");
            self.GetComponent<NavMeshAgent>().enabled = false;
            teleportsound.Play();
            self.transform.localPosition = ALoc;
            self.GetComponent<NavMeshAgent>().enabled = true;
        } else if (prefLoc == 2 && B.isactorDetected() == false)
        {
            Debug.Log("Teleported To B Pref");
            self.GetComponent<NavMeshAgent>().enabled = false;
            teleportsound.Play();
            self.transform.localPosition = BLoc;
            self.GetComponent<NavMeshAgent>().enabled = true;
        } else if (prefLoc == 3 && C.isactorDetected() == false)
        {
            Debug.Log("Teleported To C Pref");
            self.GetComponent<NavMeshAgent>().enabled = false;
            teleportsound.Play();
            self.transform.localPosition = CLoc;
            self.GetComponent<NavMeshAgent>().enabled = true;
        }

        else if (A.isactorDetected() == false) { //if nothing in spawn box A
            Debug.Log("Teleported To A");
            self.GetComponent<NavMeshAgent>().enabled = false;
            teleportsound.Play();
            self.transform.localPosition = ALoc;
            self.GetComponent<NavMeshAgent>().enabled = true;
        } else if (B.isactorDetected() == false) // if nothing in spawn box B
        {
            Debug.Log("Teleported To B");
            self.GetComponent<NavMeshAgent>().enabled = false;
            teleportsound.Play();
            self.transform.localPosition = BLoc;
            self.GetComponent<NavMeshAgent>().enabled = true;
        } else if (C.isactorDetected() == false) // if nothing in spawn box C
        {
            Debug.Log("Teleported To C");
            self.GetComponent<NavMeshAgent>().enabled = false;
            teleportsound.Play();
            self.transform.localPosition = CLoc;
            self.GetComponent<NavMeshAgent>().enabled = true;
        } else if (D.isactorDetected() == false) {
            Debug.Log("Teleported To D");
            self.GetComponent<NavMeshAgent>().enabled = false;
            teleportsound.Play();
            self.transform.localPosition = DLoc;
            self.GetComponent<NavMeshAgent>().enabled = true;
        } else if (E.isactorDetected() == false)
                {
            Debug.Log("Teleported To E");
            self.GetComponent<NavMeshAgent>().enabled = false;
            teleportsound.Play();
            self.transform.localPosition = ELoc;
            self.GetComponent<NavMeshAgent>().enabled = true;
        } else
        {
            //IF theres a player or mannequin in all of them the player will eventually move allowing the mannequin to teleport
        }
    }


    private void gameover()
    {
        SceneManager.LoadScene("GameOverScreen"); //only way for player to lose is to die via mannequin
    }
}