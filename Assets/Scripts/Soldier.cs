using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    string[] needs = new string[] { "amputar", "herido", "intoxicado" };
    string[] state = new string[] { "enfermo", "muerto", "curado" };
    int randomIndex;
    string randomNeed;
    void Start()
    {
        randomIndex = Random.Range(0, needs.Length);
        randomNeed = needs[randomIndex];
        print(randomNeed);
    }
    public void SoldierState()
    {

    }
    //minuto 20 y 45 segundos para morir
}
