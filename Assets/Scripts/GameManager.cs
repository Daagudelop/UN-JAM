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
    [SerializeField] private PlayersController playerController1;
    [SerializeField] private PlayersController playerController2;


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

        if (Input.GetButtonDown("Submit"))
        {
            StartGame();
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            BackToMenu();
        }
    }

    public void StartGame()
    {
        Debug.Log("prendido");
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
            playerController1.StartGame();
            playerController2.StartGame();
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

}
