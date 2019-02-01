using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 rotateValue;


    void Start()
    {
        rotateValue = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    void Update()
    {
        transform.Rotate(rotateValue);        
        transform.localPosition= new Vector3(0, Mathf.PingPong(Time.time, 2f), 0);

    }
}
