﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public GameObject player;
    public GameObject left;
    public GameObject right;
    public GameObject middle;
    private bool rightR;
    private bool leftL;
    private bool middleM;



    void Start()
    {
        middleM = true;
        rightR = false;
        leftL = false;

    }

    void Update()
    {
        
    }


    public void Left()
    {
        if (middleM == true)
        {

            player.transform.position = new Vector3(left.transform.position.x, left.transform.position.y, left.transform.position.z);

            Debug.Log("MOURE esquerra");
            leftL = true;
            middleM = false;
           

        }

        if (rightR == true)
        {
            Debug.Log("MOURE mitg");
            player.transform.position = new Vector3(middle.transform.position.x, middle.transform.position.y, middle.transform.position.z);
            middleM = true;
            rightR = false;
           
        }

        if (leftL==true)
        {

            Debug.Log("NO ES POT POURE CAP A L'ESQUERRA");

        }

    }

    public void Right()
    {


        if (middleM == true)
        {
            Debug.Log("MOURE dreta");
            player.transform.position = new Vector3(right.transform.position.x, right.transform.position.y, right.transform.position.z);
            rightR = true;
            middleM = false;
            

        }

        if (leftL == true)
        {
            Debug.Log("MOURE mitg");
            player.transform.position = new Vector3(middle.transform.position.x, middle.transform.position.y, middle.transform.position.z);
            middleM = true;
            leftL = false;
            
        }

        if (rightR == true)
        {

            Debug.Log("NO ES POT POURE CAP A L'A DRETA");

        }
    }
}
