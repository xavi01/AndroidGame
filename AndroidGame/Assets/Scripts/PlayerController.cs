using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject left;
    public GameObject right;
    public GameObject middle;
    private bool rightR;
    private bool leftL;
    private bool middleM;
    //private float speed = 1;
    private Rigidbody rb;
    private Animator m_Animator;

    void Start()
    {
        middleM = true;
        rightR = false;
        leftL = false;
        m_Animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = new Vector3(0, 0, 4);
        m_Animator.SetTrigger("Run");
    }


    public void Left()
    {
        if (middleM == true)
        {

            transform.position = new Vector3(left.transform.position.x, left.transform.position.y, left.transform.position.z);
            //float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(left.position, left.position, step);



            Debug.Log("MOURE esquerra");
            leftL = true;
            middleM = false;


        }

        if (rightR == true)
        {
            Debug.Log("MOURE mitg");
            transform.position = new Vector3(middle.transform.position.x, middle.transform.position.y, middle.transform.position.z);
            middleM = true;
            rightR = false;

        }

        if (leftL == true)
        {

            Debug.Log("NO ES POT POURE CAP A L'ESQUERRA");

        }

    }

    public void Right()
    {


        if (middleM == true)
        {
            Debug.Log("MOURE dreta");
            transform.position = new Vector3(right.transform.position.x, right.transform.position.y, right.transform.position.z);
            rightR = true;
            middleM = false;


        }

        if (leftL == true)
        {
            Debug.Log("MOURE mitg");
           transform.position = new Vector3(middle.transform.position.x, middle.transform.position.y, middle.transform.position.z);
            middleM = true;
            leftL = false;

        }

        if (rightR == true)
        {

            Debug.Log("NO ES POT POURE CAP A L'A DRETA");

        }
    }
}
