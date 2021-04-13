using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidad : MonoBehaviour
{

    private Rigidbody rb;
    private bool pause = false;
    public GameObject restart;
    public GameObject exit;
    public GameObject background;

    public GameObject record;
    public GameObject recordfoto;
    public GameObject puntuacion;
    public GameObject puntuacionfoto;
    public GameObject health;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        restart.SetActive(false);
        exit.SetActive(false);
        background.SetActive(false);
        rb.velocity = new Vector3(0, 0, 4);
    }

    void Update()
    {
        
    }

    public void pauseGame()
    {
        if (pause)
        {
            background.SetActive(false);
            restart.SetActive(false);
            exit.SetActive(false);

            record.SetActive(true);
            recordfoto.SetActive(true);
            puntuacion.SetActive(true);
            puntuacionfoto.SetActive(true);
            health.SetActive(true);
            rb.velocity = new Vector3(0, 0, 4);
            pause = false;
        }
        else
        {
            background.SetActive(true);
            restart.SetActive(true);
            exit.SetActive(true);

            record.SetActive(false);
            recordfoto.SetActive(false);
            puntuacion.SetActive(false);
            puntuacionfoto.SetActive(false);
            health.SetActive(false);
            rb.velocity = new Vector3(0, 0, 0);
            pause = true;
        }


    }
}
