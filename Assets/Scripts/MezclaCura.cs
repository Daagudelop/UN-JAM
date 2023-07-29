using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MezclaCura : MonoBehaviour
{
    [SerializeField] bool mezclaCura = false;
    [SerializeField] bool mezclaPoison = false;
    [SerializeField] bool mezclaMuerte = false;
    [SerializeField] bool sierra = false;
    [SerializeField] bool vendaje = false;
    [SerializeField] bool resultadoMezcla = false;
    [SerializeField] bool tijeras = false;
    [SerializeField] bool alquimista = false;

    private PlayersController playerController;
    private GameObject prefabHealthBar;

    [SerializeField] private ParticleSystem Shine;
    //[SerializeField] PopUps popUpObj;

    private void Awake()
    {
        Shine.Stop();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ToChangeColor(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        ToDetectPlayer(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ToStopSystem(collision);
    }

    void ToStopSystem(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Shine.Stop();
    }

    void ToChangeColor(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Shine.Play();


    }

    void ToDetectPlayer(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController = collision.GetComponent<PlayersController>();
            if (!playerController.estaOcupada)
            {
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
                        collision.GetComponent<PlayersController>().tijerasEstaCortando = false;
                        collision.GetComponent<PlayersController>().alquimiaEstaMezclando = false;
                        //popUpObj.popUp.sprite = popUpObj.mezclaCura;
                    }

                    else if (mezclaPoison)
                    {
                        collision.GetComponent<PlayersController>().poseeMezclaCura = false;
                        collision.GetComponent<PlayersController>().poseeMezclaMuerte = false;
                        collision.GetComponent<PlayersController>().poseeMezclaPosion = true;
                        collision.GetComponent<PlayersController>().poseeResultadoMezcla = false;
                        collision.GetComponent<PlayersController>().poseeSierra = false;
                        collision.GetComponent<PlayersController>().poseeVenda = false;
                        collision.GetComponent<PlayersController>().tijerasEstaCortando = false;
                        collision.GetComponent<PlayersController>().alquimiaEstaMezclando = false;
                        //popUpObj.popUp.sprite = popUpObj.mezclaPoison;
                    }
                    else if (mezclaMuerte)
                    {
                        collision.GetComponent<PlayersController>().poseeMezclaCura = false;
                        collision.GetComponent<PlayersController>().poseeMezclaMuerte = true;
                        collision.GetComponent<PlayersController>().poseeMezclaPosion = false;
                        collision.GetComponent<PlayersController>().poseeResultadoMezcla = false;
                        collision.GetComponent<PlayersController>().poseeSierra = false;
                        collision.GetComponent<PlayersController>().poseeVenda = false;
                        collision.GetComponent<PlayersController>().tijerasEstaCortando = false;
                        collision.GetComponent<PlayersController>().alquimiaEstaMezclando = false;
                        //popUpObj.popUp.sprite = popUpObj.mezclaMuerte;

                    }
                    else if (sierra)
                    {
                        collision.GetComponent<PlayersController>().poseeMezclaCura = false;
                        collision.GetComponent<PlayersController>().poseeMezclaMuerte = false;
                        collision.GetComponent<PlayersController>().poseeMezclaPosion = false;
                        collision.GetComponent<PlayersController>().poseeResultadoMezcla = false;
                        collision.GetComponent<PlayersController>().poseeSierra = true;
                        collision.GetComponent<PlayersController>().poseeVenda = false;
                        collision.GetComponent<PlayersController>().tijerasEstaCortando = false;
                        collision.GetComponent<PlayersController>().alquimiaEstaMezclando = false;
                        //popUpObj.popUp.sprite = popUpObj.sierra;
                    }
                    else if (vendaje)
                    {
                        collision.GetComponent<PlayersController>().poseeMezclaCura = false;
                        collision.GetComponent<PlayersController>().poseeMezclaMuerte = false;
                        collision.GetComponent<PlayersController>().poseeMezclaPosion = false;
                        collision.GetComponent<PlayersController>().poseeResultadoMezcla = false;
                        collision.GetComponent<PlayersController>().poseeSierra = false;
                        collision.GetComponent<PlayersController>().poseeVenda = true;
                        collision.GetComponent<PlayersController>().tijerasEstaCortando = false;
                        collision.GetComponent<PlayersController>().alquimiaEstaMezclando = false;
                        // popUpObj.popUp.sprite = popUpObj.vendaje;
                    }
                    else if (resultadoMezcla)
                    {
                        collision.GetComponent<PlayersController>().poseeMezclaCura = false;
                        collision.GetComponent<PlayersController>().poseeMezclaMuerte = false;
                        collision.GetComponent<PlayersController>().poseeMezclaPosion = false;
                        collision.GetComponent<PlayersController>().poseeResultadoMezcla = true;
                        collision.GetComponent<PlayersController>().poseeSierra = false;
                        collision.GetComponent<PlayersController>().poseeVenda = false;
                        collision.GetComponent<PlayersController>().tijerasEstaCortando = false;
                        collision.GetComponent<PlayersController>().alquimiaEstaMezclando = false;
                    }

                    //playerController.estaOcupada = true;
                }
                else if (playerController.accion && playerController.poseeVenda)
                {
                    if (tijeras)
                    {
                        playerController.poseeVenda = false;
                        collision.GetComponent<PlayersController>().tijerasEstaCortando = true;
                        collision.GetComponent<PlayersController>().quieto = true;
                        if (playerController.healthBar.timeToFill != 2.5f)
                        {
                            playerController.healthBar.Reinitiated();
                        }
                        playerController.healthBar.isRunning = true;
                        /*if (playerController.healthBar.contadorcito <= playerController.healthBar.timeToFill)
                        {
                            //collision.GetComponent<PlayersController>().tijerasEstaCortando = false;
                            //tijeras = false;
                        }*/

                        StartCoroutine(EmpiezaAMover());

                    }
                    //collision.GetComponent<PlayersController>().tijerasEstaCortando = false;
                    //tijeras = false;
                }
                else if (playerController.accion && playerController.poseeMezclaCura)
                {
                    if (alquimista)
                    {
                        playerController.poseeMezclaCura = false;
                        collision.GetComponent<PlayersController>().alquimiaEstaMezclando = true;
                        collision.GetComponent<PlayersController>().quieto = true;
                        if (playerController.healthBar.timeToFill != 2.5f)
                        {
                            playerController.healthBar.Reinitiated();
                        }
                        playerController.healthBar.isRunning = true;
                        /*if (playerController.healthBar.contadorcito <= playerController.healthBar.timeToFill)
                        {
                            //collision.GetComponent<PlayersController>().tijerasEstaCortando = false;
                            //tijeras = false;
                        }*/
                        StartCoroutine(EmpiezaAMover());
                    }
                }
            }
        }
    }

    private IEnumerator EmpiezaAMover()
    {
        yield return new WaitForSeconds(2.5f);
        playerController.quieto = false;
    }
}


