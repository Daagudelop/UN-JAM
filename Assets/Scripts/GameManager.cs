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

    //-----parte de ejemplo de actualización de meshes---
    
    public int collectedObject = 0;

    //---------------------------------------------------


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
            ReloadGame();
            Time.timeScale = 1f;
            MenuManager.sharedInstance.HideMainMenu();
            MenuManager.sharedInstance.HidePausedGameMenu();
            MenuManager.sharedInstance.showInGameMenu();
            MenuManager.sharedInstance.HideGameOverMenu();
        }
        else if (newGameState == GameState.menu)
        {
            Time.timeScale = 0f;
            MenuManager.sharedInstance.showPausedGameMenu();
            MenuManager.sharedInstance.HideInGameMenu();
        }
        else if (newGameState == GameState.gameOver)
        {
            MenuManager.sharedInstance.showGameOverMenu();
            MenuManager.sharedInstance.HideInGameMenu();

        }
        this.currentGameState = newGameState;
    }


    //-----parte de ejemplo de actualización de meshes---

    /*public void PointosCollected(Pointo pointos)
    {
        collectedObject += pointos.value;
    }*/

    //---------------------------------------------------


    private void ReloadGame()
    {

    }

}
