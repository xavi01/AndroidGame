using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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


    public Text puntuacioText;
    public Text RecordText;
    private int puntuacio = 0;
    private int record;

    private int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;
    private float life;


    void Start()
    {
        middleM = true;
        rightR = false;
        leftL = false;
        m_Animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 4);
        m_Animator.SetTrigger("Run");



        puntuacioText.text = "PUNTUACIO: " + puntuacio;
        

        RecordText.text = "RECORD: " + record.ToString();
        record = PlayerPrefs.GetInt("RecordGuardat");


        life = 100;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        puntuacio = puntuacio + 1/100;
        puntuacioText.text = "PUNTUACIO: " + puntuacio;

        m_Animator.SetTrigger("Run");



        life = life - 1;
        Debug.Log("Life player: " + life);

        currentHealth = currentHealth - 1;
        healthBar.SetHealth(currentHealth);

        if (life <= 0)
        {
            SceneManager.LoadScene("GameOver");   
        }

    }

    void Guardar()
    {
       PlayerPrefs.SetInt("RecordGuardat", puntuacio);
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
            Guardar();
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            pause = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PUM"))
        {
            life = life + 100;
            Debug.Log("Life player: " + life);

            currentHealth = currentHealth + 100;
            healthBar.SetHealth(currentHealth);
            Debug.Log("pum");            
        }
    }
}
