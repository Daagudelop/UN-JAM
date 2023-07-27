using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    inGame,
    menu,
    gameOver,

}
public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.menu;

    public static GameManager sharedInstanceGameManager;


    private void Awake()
    {
        if (sharedInstanceGameManager == null)//instance singleton
        {
            sharedInstanceGameManager = this;
        }
        //-----------------------
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Toca mirar hasta cuantos jugadores abran en pantalla al mismo tiempo y definir botones

        /*if (Input.GetButtonDown("Submit"))
        {
            StartGame();
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            BackToMenu();
        }*/ 
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);

    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.inGame)
        {

        }
        else if (newGameState == GameState.menu)
        {

        }
        else if (newGameState == GameState.gameOver)
        {

        }
        this.currentGameState = newGameState;
    }

}
