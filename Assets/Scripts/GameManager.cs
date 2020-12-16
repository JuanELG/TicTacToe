using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Options for different game states
/// </summary>
public enum GameState
{
    menu,
    inGame,
    gameOver,
    preferences1, preferences2, preferences3,
    gameHistory
}

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;

    public Sprite player1Sprite;
    public GameObject currentSymbolButtonPlayer1;
    public Sprite player2Sprite;
    public GameObject currentSymbolButtonPlayer2;

    public GameObject board3x3Container;
    public GameObject board4x4Container;
    public GameObject winnerContainer;
    public GameObject mainMenuContainer;
    public GameObject preferences1Container;
    public GameObject preferences2Container;
    public GameObject preferences3Container;
    public GameObject gameHistoryContainer;

    public Image player1Image3x3;
    public Image Player2Image3x3;
    public Image player1Image4x4;
    public Image Player2Image4x4;

    public bool player1Turn;
    public bool current3x3Board;

    public GameState currentGameState = GameState.menu;

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    private void Start()
    {
        BackToMenu();
    }


    /// <summary>
    /// Method to change the status of the game to game over
    /// </summary>
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }


    /// <summary>
    /// Method to change the status of the game to main menu
    /// </summary>
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    /// <summary>
    /// Method to start the game according to the chosen board
    /// </summary>
    public void StartGame()
    {
        SetGameState(GameState.inGame);
        player1Turn = true;
        WinnerManager.sharedInstance.StartGame();

        if (current3x3Board)
        {
            board3x3Container.SetActive(true);
            board4x4Container.SetActive(false);
            player1Image3x3.sprite = player1Sprite;
            Player2Image3x3.sprite = player2Sprite;
        }
        else
        {
            board4x4Container.SetActive(true);
            board3x3Container.SetActive(false);
            player1Image4x4.sprite = player1Sprite;
            Player2Image4x4.sprite = player2Sprite;
        }
    }

    /// <summary>
    /// method to assign a button to player one in the selection of symbols to deactivate it later
    /// </summary>
    /// <param name="currentButton">the game object that was selected</param>
    public void SetCurrentSymbolPlayer1(GameObject currentButton)
    {
        if (currentSymbolButtonPlayer1 != null)
        {
            currentSymbolButtonPlayer1.GetComponentInChildren<Button>().interactable = true;
        }
        currentSymbolButtonPlayer1 = currentButton;
        currentSymbolButtonPlayer1.GetComponentInChildren<Button>().interactable = false;
    }

    /// <summary>
    /// method to assign a button to player two in the selection of symbols to deactivate it later
    /// </summary>
    /// <param name="currentButton">the game object that was selected</param>
    public void SetCurrentSymbolPlayer2(GameObject currentButton)
    {
        if (currentSymbolButtonPlayer2 != null)
        {
            currentSymbolButtonPlayer2.GetComponentInChildren<Button>().interactable = true;
        }
        currentSymbolButtonPlayer2 = currentButton;
        currentSymbolButtonPlayer2.GetComponentInChildren<Button>().interactable = false;
    }

    /// <summary>
    /// method to assign a sprite to player one in the selection of symbols to use the image in the game
    /// </summary>
    /// <param name="currentSprite">the sprite that was selected</param>
    public void SetCurrentPlayer1Sprite(Sprite currentSprite)
    {
        player1Sprite = currentSprite;
    }

    /// <summary>
    /// method to assign a sprite to player two in the selection of symbols to use the image in the game
    /// </summary>
    /// <param name="currentSprite">the sprite that was selected</param>
    public void SetCurrentPlayer2Sprite(Sprite currentSprite)
    {
        player2Sprite = currentSprite;
    }

    /// <summary>
    /// Method to assign the board size chosen by the players
    /// </summary>
    /// <param name="is3x3">true to indicate that the board is 3x3</param>
    public void SetCurrent3x3Board(bool is3x3)
    {
        current3x3Board = is3x3;
    }


    /// <summary>
    /// method to change the status of the game to the first preferences section
    /// </summary>
    public void GoToPreferences1()
    {
        SetGameState(GameState.preferences1);
    }

    /// <summary>
    /// method to change the status of the game to the second preferences section
    /// </summary>
    public void GoToPreferences2()
    {
        SetGameState(GameState.preferences2);
        GameObject buttonToDisable = GameObject.Find(currentSymbolButtonPlayer1.name);
        buttonToDisable.SetActive(false);
    }

    /// <summary>
    /// method to change the status of the game to the third preferences section
    /// </summary>
    public void GoToPreferences3()
    {
        SetGameState(GameState.preferences3);
    }

    /// <summary>
    /// method to change the status of the game to the game history section
    /// </summary>
    public void GoToGameHistory()
    {
        SetGameState(GameState.gameHistory);
    }

    /// <summary>
    /// Method to change the game state by activating the necessary containers and deactivating those that are not needed
    /// </summary>
    /// <param name="newGameState">the new game state to which it is going to change</param>
    void SetGameState(GameState newGameState)
    {

        if (newGameState == GameState.menu)
        {
            mainMenuContainer.SetActive(true);
            board3x3Container.SetActive(false);
            board4x4Container.SetActive(false);
            winnerContainer.SetActive(false);
            preferences1Container.SetActive(false);
            preferences2Container.SetActive(false);
            preferences3Container.SetActive(false);
            gameHistoryContainer.SetActive(false);
        }
        else if (newGameState == GameState.inGame && current3x3Board)
        {
            mainMenuContainer.SetActive(false);
            board3x3Container.SetActive(true);
            board4x4Container.SetActive(false);
            winnerContainer.SetActive(false);
            preferences1Container.SetActive(false);
            preferences2Container.SetActive(false);
            preferences3Container.SetActive(false);
            gameHistoryContainer.SetActive(false);
        }
        else if (newGameState == GameState.inGame && !current3x3Board)
        {
            mainMenuContainer.SetActive(false);
            board3x3Container.SetActive(false);
            board4x4Container.SetActive(true);
            winnerContainer.SetActive(false);
            preferences1Container.SetActive(false);
            preferences2Container.SetActive(false);
            preferences3Container.SetActive(false);
            gameHistoryContainer.SetActive(false);
        }
        else if (newGameState == GameState.gameOver)
        {
            mainMenuContainer.SetActive(false);
            preferences1Container.SetActive(false);
            preferences2Container.SetActive(false);
            preferences3Container.SetActive(false);
            winnerContainer.SetActive(true);
            gameHistoryContainer.SetActive(false);
        }
        else if(newGameState == GameState.preferences1)
        {
            mainMenuContainer.SetActive(false);
            board3x3Container.SetActive(false);
            board4x4Container.SetActive(false);
            winnerContainer.SetActive(false);
            preferences1Container.SetActive(true);
            preferences2Container.SetActive(false);
            preferences3Container.SetActive(false);
            gameHistoryContainer.SetActive(false);
        }
        else if (newGameState == GameState.preferences2)
        {
            mainMenuContainer.SetActive(false);
            board3x3Container.SetActive(false);
            board4x4Container.SetActive(false);
            winnerContainer.SetActive(false);
            preferences1Container.SetActive(false);
            preferences2Container.SetActive(true);
            preferences3Container.SetActive(false);
            gameHistoryContainer.SetActive(false);
        }
        else if (newGameState == GameState.preferences3)
        {
            mainMenuContainer.SetActive(false);
            board3x3Container.SetActive(false);
            board4x4Container.SetActive(false);
            winnerContainer.SetActive(false);
            preferences1Container.SetActive(false);
            preferences2Container.SetActive(false);
            preferences3Container.SetActive(true);
            gameHistoryContainer.SetActive(false);
        }
        else if (newGameState == GameState.gameHistory)
        {
            mainMenuContainer.SetActive(false);
            board3x3Container.SetActive(false);
            board4x4Container.SetActive(false);
            winnerContainer.SetActive(false);
            preferences1Container.SetActive(false);
            preferences2Container.SetActive(false);
            preferences3Container.SetActive(false);
            gameHistoryContainer.SetActive(true);

            HistoryManager.sharedInstance.ShowGameHistoryInTexts();
        }
        this.currentGameState = newGameState;
    }

    /// <summary>
    /// method to exit the game even while in the unity editor
    /// </summary>
    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                     Application.Quit();
        #endif
    }


    /// <summary>
    /// Method that allows changing the next player's turn
    /// </summary>
    public void ChangeTurn()
    {
        player1Turn = !player1Turn;
        WinnerManager.sharedInstance.remainingTurns--;
    }

    /// <summary>
    /// Method to restart the game
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }


    /// <summary>
    /// method to lower or increase the audio volume
    /// </summary>
    public void MuteAudio()
    {
        GameObject audioGameObject = GameObject.Find("AudioSource");
        AudioSource audio = audioGameObject.GetComponent<AudioSource>();
        if(audio.volume == 0.5f)
        {
            audio.volume = 0f;
        }
        else
        {
            audio.volume = 0.5f;
        }
    }
}
