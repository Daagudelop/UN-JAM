using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    string[] needs = new string[] { "amputar", "herido", "intoxicado", "infeccion" , "herido"};
    string[] states = new string[] { "enfermo", "muerto", "curado" };
    int randomIndex;
    string randomNeed;
    string currentState;

    public SpriteRenderer spriteRendererSoldier, spriteRendererPopUp;
    public Sprite soldierSprite, muertoSprite, curadoSprite;
    public Sprite amputarSprite, vendaSprite, intoxicacionSprite, infeccionSprite, heridoSprite;
    void Start()
    {
        //spriteRendererPopUp = GetComponentInChildren<SpriteRenderer>();
        currentState = states[0];  // Inicia enfermo
        randomIndex = Random.Range(0, needs.Length);
        randomNeed = needs[randomIndex];
        ChangeSpritePopUp();
        print(randomNeed);
        StartCoroutine(TimeOfDeathCoroutine());
        
    }
    void ChangeSpritePopUp()
    {
        if (randomNeed == "amputar")
        {
            spriteRendererPopUp.sprite = amputarSprite;
        }
        else if (randomNeed == "herido")
        {
            spriteRendererPopUp.sprite = vendaSprite;
        }
        else if (randomNeed == "intoxicado")
        {
            spriteRendererPopUp.sprite = intoxicacionSprite;
        }
        else if (randomNeed == "infeccion")
        {
            spriteRendererPopUp.sprite = infeccionSprite;
        }
        else if (randomNeed == "herido")
        {
            spriteRendererPopUp.sprite = heridoSprite;
        }
    }
    void ChangeSpriteSoldier()
    {
        if (currentState == "enfermo")
        {
            spriteRendererSoldier.sprite = soldierSprite;
        }
        else if (currentState == "curado"){
            spriteRendererSoldier.sprite = curadoSprite;
        }
        else if (currentState == "muerto")
        {
            spriteRendererSoldier.sprite = muertoSprite;
        }
        
    }
    public void SoldierState()
    {

    }
    private IEnumerator TimeOfDeathCoroutine()
    {

        float _CastTimeLimit = Time.deltaTime + 10;
        Vector3 _PaddleScale = transform.localScale;
        while (Time.time < _CastTimeLimit)
        {
            yield return null; // Esperar hasta la siguiente actualización del frame
        }
        currentState = states[1];
        ChangeSpriteSoldier();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        //HACER QUE SE MATE
    }


    //minuto 20 y 45 segundos para morir
}
