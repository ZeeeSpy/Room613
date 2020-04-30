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

	public SpawnDetectionScript[] SDS;

	private Vector3[] TeleportLocations = new Vector3[]
	{
		new Vector3(0.5f,1,22),
		new Vector3(-21,1,2),
		new Vector3(2,1,2),
		new Vector3(23,1,-14),
		new Vector3(21, 1, -22)
	};

	public void Start()
	{
		SDS = new SpawnDetectionScript[] {A,B,C,D,E};
	}

	public int prefLoc;

    public KillBoxScript mykillbox;

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
                //Debug.Log("Mannequin is trapped :(");
                // teleportmannequin(); //teleport mannequin to corridor space that player isn't occupying
                teleportme();
            }


        }

        if (Chasing && (gameObject.GetComponent<Renderer>().isVisible == false)) //if the mannequin is chasing the player and cannot be seen chase
        {
                myAgent.SetDestination(player.transform.position);  //if not trapped i.e. agent has path to player
                //Debug.Log("Manneqiun Following Player");
                playchasesound(true);

            if (mykillbox.getplayer())
            {
                //Debug.Log("PlayerDead");
                gameover();
            }
        } else if (gameObject.GetComponent<Renderer>().isVisible == true) //if the mannequin can be seen
        {
            playchasesound(false);
            myAgent.isStopped = true;
            myAgent.ResetPath();
            //Debug.Log("Manneqiun StoppedFollowing Player");
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
		if (!SDS[prefLoc].actorDetected)
		{
			TeleportStart();
		} else
		{
			for (int i = 0; i < SDS.Length; i++)
			{
				if (!SDS[i].actorDetected)
				{
					TeleportStart(i);
					return;
				}
			}
		}
    }

	private void TeleportStart()
	{
		self.GetComponent<NavMeshAgent>().enabled = false;
		teleportsound.Play();
		self.transform.localPosition = TeleportLocations[prefLoc];
		self.GetComponent<NavMeshAgent>().enabled = true;
	}

	private void TeleportStart(int i)
	{
		self.GetComponent<NavMeshAgent>().enabled = false;
		teleportsound.Play();
		self.transform.localPosition = TeleportLocations[i];
		self.GetComponent<NavMeshAgent>().enabled = true;
	}

	private void TeleportEnd()
	{

	}

    private void gameover()
    {
        SceneManager.LoadScene("GameOverScreen"); //only way for player to lose is to die via mannequin
    }
}