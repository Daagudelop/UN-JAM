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

    bool coop = true;


    public static GameManager sharedInstanceGameManager;


    private void Awake()
    {

        if (sharedInstanceGameManager == null)//instance singleton
        {
            sharedInstanceGameManager = this;
        }
        //-----------------------
        Time.timeScale = 0f;
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
        
        coop = false;
        SetGameState(GameState.inGame);
    }

    public void StartGameCoop()
    {

        coop = true;
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
            Time.timeScale = 1f;
            playerController1.StartGame();
            if (coop)
            {
                playerController2.StartGame();
                playerController2.transform.position = new Vector3(5.26999998f, -0.09402439f, 0);
            } else if (!coop)
            {
                playerController2.enabled = false;
            }
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
