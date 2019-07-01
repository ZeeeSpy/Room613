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
