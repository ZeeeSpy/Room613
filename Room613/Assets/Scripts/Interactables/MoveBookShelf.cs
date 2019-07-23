/*
 *  Interactable bookshelf is moved across the ground when interacted with.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBookShelf : MonoBehaviour, Interactable
{
    public Transform target;
    private bool activated = false;
    private bool moving = false;
    

    public void Interact(){
        if (!activated)
        {
            moving = true;
            activated = true;
        }
    }

    private void Update()
    {
        if (moving)
        {
            if (transform.position != target.position)
            {
                transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * 0.5f);
            } else
            {
                moving = false;
            }
        }
    }
}
