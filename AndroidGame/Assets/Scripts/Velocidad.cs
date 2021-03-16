using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidad : MonoBehaviour
{

    private Rigidbody rb;

    void Start()
    {
        
    }

    void Update()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0,0,4);
    }
}
