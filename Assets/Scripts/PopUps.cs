using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUps : MonoBehaviour
{
    public Sprite mezclaCura      ;
    public Sprite mezclaPoison    ;
    public Sprite mezclaMuerte    ;
    public Sprite sierra          ;
    public Sprite vendaje         ;
    //public Sprite resultadoMezcla ;
    public SpriteRenderer popUp;
    [SerializeField] PlayersController playerController;

    private void Awake()
    {
        popUp = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarSprite();
    }

    void CambiarSprite()
    {
        if(playerController.poseeMezclaCura)
        {
            popUp.sprite = mezclaCura;
        }
        else if (playerController.poseeMezclaPosion)
        {
            popUp.sprite = mezclaPoison;
        }
        else if (playerController.poseeMezclaMuerte)
        {
            popUp.sprite = mezclaMuerte;
        }
        else if (playerController.poseeSierra)
        {
            popUp.sprite = sierra;
        }
        else if (playerController.poseeVenda)
        {
            popUp.sprite = vendaje;
        }
    }

}
