/*
 * script rotates the manequin to look at player while chasing. extra rotate needed because model
 * south isn't world south.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManequinScript : MonoBehaviour
{
    public Transform theplayer;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Renderer>().isVisible == false)
        {
            transform.LookAt(theplayer);
            transform.Rotate(0, 180, 0);
        }
    }
}
