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
