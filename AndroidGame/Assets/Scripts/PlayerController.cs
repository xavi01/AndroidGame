using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private bool pause = false;

    public int SaludInicial = 100;
    public int SaludActual;
    public Slider barraSlider;


    void Start()
    {
        middleM = true;
        rightR = false;
        leftL = false;
        m_Animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 4);
        m_Animator.SetTrigger("Run");

        SaludActual = SaludInicial;
    }

    void Update()
    {
        m_Animator.SetTrigger("Run");

        SaludActual = SaludActual - 1;
        barraSlider.value = SaludActual;
    }


    public void Left()
    {
        m_Animator.SetTrigger("Jump");

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
            m_Animator.SetTrigger("Jump");
        }

        if (leftL == true)
        {
            
            Debug.Log("MOURE mitg");
            transform.position = new Vector3(middle.transform.position.x, middle.transform.position.y, middle.transform.position.z);
            middleM = true;
            leftL = false;
            m_Animator.SetTrigger("Jump");
        }

        if (rightR == true)
        {
            Debug.Log("NO ES POT POURE CAP A L'A DRETA");
        }
    }

    public void pauseGame()
    {
        if (pause)
        {
            rb.velocity = new Vector3(0, 0, 4);
            pause = false;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            pause = true;
        }


    }
}
