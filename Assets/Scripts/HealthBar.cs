using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    [SerializeField]private Transform bar;
    [SerializeField] public bool isRunning = true;
    [SerializeField] public float timeToFill = 60;
    float health = 1f;
    public float contadorcito;
    float tiempoFaltante;
    void Start()
    {
        tiempoFaltante = timeToFill;
    }

    void Update()
    {
        tiempoFaltante = timeToFill - contadorcito;
        if (isRunning && health > 0 && contadorcito <= timeToFill)
        {
            contadorcito += Time.deltaTime;
            bar.localScale = new Vector3(contadorcito / timeToFill, 1f);
        }
    }

    public void Reinitiated()
    {
        tiempoFaltante = timeToFill;
        bar.localScale = Vector3.one;
    }

}
