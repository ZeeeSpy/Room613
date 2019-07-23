/*
 *  Unused script: Used to rotate a celing fan with light above it that would cast real time shadow on ground
 *  not used due to performance hit of real time lighting calculations on mobile
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 100f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,100f * Time.deltaTime);
    }
}
