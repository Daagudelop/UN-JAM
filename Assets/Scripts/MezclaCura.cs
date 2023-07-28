using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MezclaCura : MonoBehaviour
{
    [SerializeField] bool mezclaCura = false;
    [SerializeField] bool mezclaPoison = false;
    [SerializeField] bool mezclaMuerte = false;
    [SerializeField] bool sierra = false;
    [SerializeField] bool vendaje = false;
    [SerializeField] bool resultadoMezcla = false;

    private PlayersController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    ToDetectPlayer(collision);
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        ToDetectPlayer(collision);
    }

    void ToDetectPlayer(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController = collision.GetComponent<PlayersController>();

            if (playerController.tomar)
            {
                if (mezclaCura)
                {
                    collision.GetComponent<PlayersController>().poseeMezclaCura = true;
                    collision.GetComponent<PlayersController>().poseeMezclaMuerte = false;
                    collision.GetComponent<PlayersController>().poseeMezclaPosion = false;
                    collision.GetComponent<PlayersController>().poseeResultadoMezcla = false;
                    collision.GetComponent<PlayersController>().poseeSierra = false;
                    collision.GetComponent<PlayersController>().poseeVenda = false;
                }
                else if (mezclaPoison)
                {
                    collision.GetComponent<PlayersController>().poseeMezclaCura = false;
                    collision.GetComponent<PlayersController>().poseeMezclaMuerte = false;
                    collision.GetComponent<PlayersController>().poseeMezclaPosion = true;
                    collision.GetComponent<PlayersController>().poseeResultadoMezcla = false;
                    collision.GetComponent<PlayersController>().poseeSierra = false;
                    collision.GetComponent<PlayersController>().poseeVenda = false;
                }
                else if (mezclaMuerte)
                {
                    collision.GetComponent<PlayersController>().poseeMezclaCura = false;
                    collision.GetComponent<PlayersController>().poseeMezclaMuerte = true;
                    collision.GetComponent<PlayersController>().poseeMezclaPosion = false;
                    collision.GetComponent<PlayersController>().poseeResultadoMezcla = false;
                    collision.GetComponent<PlayersController>().poseeSierra = false;
                    collision.GetComponent<PlayersController>().poseeVenda = false;
                }
                else if (sierra)
                {
                    collision.GetComponent<PlayersController>().poseeMezclaCura = false;
                    collision.GetComponent<PlayersController>().poseeMezclaMuerte = false;
                    collision.GetComponent<PlayersController>().poseeMezclaPosion = false;
                    collision.GetComponent<PlayersController>().poseeResultadoMezcla = false;
                    collision.GetComponent<PlayersController>().poseeSierra = true;
                    collision.GetComponent<PlayersController>().poseeVenda = false;
                }
                else if (vendaje)
                {
                    collision.GetComponent<PlayersController>().poseeMezclaCura = false;
                    collision.GetComponent<PlayersController>().poseeMezclaMuerte = false;
                    collision.GetComponent<PlayersController>().poseeMezclaPosion = false;
                    collision.GetComponent<PlayersController>().poseeResultadoMezcla = false;
                    collision.GetComponent<PlayersController>().poseeSierra = false;
                    collision.GetComponent<PlayersController>().poseeVenda = true;
                }
                else if (resultadoMezcla)
                {
                    collision.GetComponent<PlayersController>().poseeMezclaCura = false;
                    collision.GetComponent<PlayersController>().poseeMezclaMuerte = false;
                    collision.GetComponent<PlayersController>().poseeMezclaPosion = false;
                    collision.GetComponent<PlayersController>().poseeResultadoMezcla = true;
                    collision.GetComponent<PlayersController>().poseeSierra = false;
                    collision.GetComponent<PlayersController>().poseeVenda = false;
                }
            }
            else if (!playerController.tomar)
            {
            
            }
        }
    }
}
