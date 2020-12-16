using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerManager : MonoBehaviour
{
    public static WinnerManager sharedInstance;

    private int winnerPlayer;
    public int[] movementHistoryArray;
    public int remainingTurns = 1;

    private void Awake()
    {
        sharedInstance = this;
    }

    /// <summary>
    /// Method that verifies if there is any winner on the chosen board if the game has already started
    /// </summary>
    private void Update()
    {
        if (GameManager.sharedInstance.current3x3Board && GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            ThereIsAWinner3x3();
        }
        else if (GameManager.sharedInstance.current3x3Board != true && GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            ThereIsAWinner4x4();
        }
    }


    /// <summary>
    /// This method indicates that the game has started and creates the array with the positions in which each play will be stored.
    /// </summary>
    public void StartGame()
    {
        if (GameManager.sharedInstance.current3x3Board && GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            movementHistoryArray = new int[9];
            remainingTurns = 9;
            for (int i = 0; i < 9; i++)
            {
                movementHistoryArray[i] = 0;
            }
        }
        else if (GameManager.sharedInstance.current3x3Board != true && GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            movementHistoryArray = new int[16];
            remainingTurns = 16;
            for (int i = 0; i < 16; i++)
            {
                movementHistoryArray[i] = 0;
            }
        }
    }


    /// <summary>
    /// This method checks if any of the possible combinations gives 3 consecutive equal symbols
    /// The zeros numbers indicate that none has been chosen there in any turn
    /// Numbers 1 indicate that the winner is player 1
    /// Numbers 2 indicate that the winner is player 2
    /// </summary>
    public void ThereIsAWinner3x3()
    {
        // 1 1 1
        // 0 0 0
        // 0 0 0
        if ((movementHistoryArray[0] == movementHistoryArray[1]) && (movementHistoryArray[0] == movementHistoryArray[2]) && (movementHistoryArray[0] != 0))
        {
            winnerPlayer = movementHistoryArray[0];
            ShowWinner();
        }

        // 1 0 0
        // 1 0 0
        // 1 0 0
        else if (movementHistoryArray[0] == movementHistoryArray[3] && movementHistoryArray[0] == movementHistoryArray[6] && (movementHistoryArray[0] != 0))
        {
            winnerPlayer = movementHistoryArray[0];
            ShowWinner();
        }

        // 0 0 1
        // 0 0 1
        // 0 0 1
        else if (movementHistoryArray[2] == movementHistoryArray[5] && movementHistoryArray[2] == movementHistoryArray[8] && (movementHistoryArray[2] != 0))
        {
            winnerPlayer = movementHistoryArray[2];
            ShowWinner();
        }

        // 0 0 0
        // 0 0 0
        // 1 1 1
        else if (movementHistoryArray[6] == movementHistoryArray[7] && movementHistoryArray[6] == movementHistoryArray[8] && (movementHistoryArray[6] != 0))
        {
            winnerPlayer = movementHistoryArray[6];
            ShowWinner();
        }

        // 1 0 0
        // 0 1 0
        // 0 0 1
        else if (movementHistoryArray[0] == movementHistoryArray[4] && movementHistoryArray[0] == movementHistoryArray[8] && (movementHistoryArray[0] != 0))
        {
            winnerPlayer = movementHistoryArray[0];
            ShowWinner();
        }
        // 0 0 1
        // 0 1 0
        // 1 0 0
        else if (movementHistoryArray[2] == movementHistoryArray[4] && movementHistoryArray[2] == movementHistoryArray[6] && (movementHistoryArray[2] != 0))
        {
            winnerPlayer = movementHistoryArray[2];
            ShowWinner();
        }
        // 0 1 0
        // 0 1 0
        // 0 1 0
        else if (movementHistoryArray[1] == movementHistoryArray[4] && movementHistoryArray[1] == movementHistoryArray[7] && movementHistoryArray[1] != 0)
        {
            winnerPlayer = movementHistoryArray[1];
            ShowWinner();
        }
        // 0 0 0
        // 1 1 1
        // 0 0 0
        else if (movementHistoryArray[3] == movementHistoryArray[4] && movementHistoryArray[3] == movementHistoryArray[5] && movementHistoryArray[3] != 0)
        {
            winnerPlayer = movementHistoryArray[3];
            ShowWinner();
        }
        //They have already played every turn and none achieved 3 consecutive
        else if (remainingTurns == 0)
        {
            winnerPlayer = 0;
            ShowWinner();
        }
    }

    /// <summary>
    /// This method checks if any of the possible combinations gives 4 consecutive equal symbols
    /// The zeros numbers indicate that none has been chosen there in any turn
    /// Numbers 1 indicate that the winner is player 1
    /// Numbers 2 indicate that the winner is player 2
    /// </summary>
    public void ThereIsAWinner4x4()
    {
        // 1 1 1 1
        // 0 0 0 0 
        // 0 0 0 0
        // 0 0 0 0
        if ((movementHistoryArray[0] == movementHistoryArray[1]) && (movementHistoryArray[0] == movementHistoryArray[2]) && (movementHistoryArray[0] == movementHistoryArray[3]) && (movementHistoryArray[0] != 0))
        {
            winnerPlayer = movementHistoryArray[0];
            ShowWinner();
        }

        // 1 0 0 0
        // 1 0 0 0
        // 1 0 0 0
        // 1 0 0 0
        else if (movementHistoryArray[0] == movementHistoryArray[4] && movementHistoryArray[0] == movementHistoryArray[8] && movementHistoryArray[0] == movementHistoryArray[12] && (movementHistoryArray[0] != 0))
        {
            winnerPlayer = movementHistoryArray[0];
            ShowWinner();
        }

        // 0 0 0 1
        // 0 0 0 1
        // 0 0 0 1
        // 0 0 0 1
        else if (movementHistoryArray[3] == movementHistoryArray[7] && movementHistoryArray[3] == movementHistoryArray[11] && movementHistoryArray[3] == movementHistoryArray[15] && (movementHistoryArray[3] != 0))
        {
            winnerPlayer = movementHistoryArray[3];
            ShowWinner();
        }

        // 0 0 0 0
        // 0 0 0 0
        // 0 0 0 0
        // 1 1 1 1
        else if (movementHistoryArray[12] == movementHistoryArray[13] && movementHistoryArray[12] == movementHistoryArray[14] && movementHistoryArray[12] == movementHistoryArray[15] && (movementHistoryArray[12] != 0))
        {
            winnerPlayer = movementHistoryArray[12];
            ShowWinner();
        }

        // 1 0 0 0
        // 0 1 0 0
        // 0 0 1 0
        // 0 0 0 1
        else if (movementHistoryArray[0] == movementHistoryArray[5] && movementHistoryArray[0] == movementHistoryArray[10] && movementHistoryArray[0] == movementHistoryArray[15] && (movementHistoryArray[0] != 0))
        {
            winnerPlayer = movementHistoryArray[0];
            ShowWinner();
        }
        // 0 0 0 1
        // 0 0 1 0
        // 0 1 0 0
        // 1 0 0 0
        else if (movementHistoryArray[3] == movementHistoryArray[6] && movementHistoryArray[3] == movementHistoryArray[9] && movementHistoryArray[3] == movementHistoryArray[12] && (movementHistoryArray[3] != 0))
        {
            winnerPlayer = movementHistoryArray[3];
            ShowWinner();
        }
        // 0 1 0 0
        // 0 1 0 0
        // 0 1 0 0
        // 0 1 0 0
        else if (movementHistoryArray[1] == movementHistoryArray[5] && movementHistoryArray[1] == movementHistoryArray[9] && movementHistoryArray[1] == movementHistoryArray[13] && movementHistoryArray[1] != 0)
        {
            winnerPlayer = movementHistoryArray[1];
            ShowWinner();
        }
        // 0 0 0 0
        // 1 1 1 1
        // 0 0 0 0
        // 0 0 0 0
        else if (movementHistoryArray[4] == movementHistoryArray[5] && movementHistoryArray[4] == movementHistoryArray[6] && movementHistoryArray[4] == movementHistoryArray[7] && movementHistoryArray[4] != 0)
        {
            winnerPlayer = movementHistoryArray[4];
            ShowWinner();
        }
        // 0 0 0 0
        // 0 0 0 0
        // 1 1 1 1
        // 0 0 0 0
        else if (movementHistoryArray[8] == movementHistoryArray[9] && movementHistoryArray[8] == movementHistoryArray[10] && movementHistoryArray[8] == movementHistoryArray[11] && movementHistoryArray[8] != 0)
        {
            winnerPlayer = movementHistoryArray[8];
            ShowWinner();
        }
        // 0 0 1 0
        // 0 0 1 0
        // 0 0 1 0
        // 0 0 1 0
        else if (movementHistoryArray[2] == movementHistoryArray[6] && movementHistoryArray[2] == movementHistoryArray[10] && movementHistoryArray[2] == movementHistoryArray[14] && movementHistoryArray[2] != 0)
        {
            winnerPlayer = movementHistoryArray[2];
            ShowWinner();
        }
        //They have already played every turn and none achieved 4 consecutive
        else if (remainingTurns == 0)
        {
            winnerPlayer = 0;
            ShowWinner();
        }
    }


    /// <summary>
    /// Method shown by the winner according to the variable winnerPlayer
    /// if 0 means that the game was tied
    /// </summary>
    public void ShowWinner()
    {
        GameManager.sharedInstance.GameOver();

        if (winnerPlayer != 0)
        {
            GameManager.sharedInstance.winnerContainer.GetComponentInChildren<Text>().text = "¡Player " + winnerPlayer + " win!";
            Debug.Log("El ganador es: " + winnerPlayer);
            HistoryManager.sharedInstance.DebugMovementsHistory();
        }
        else if(winnerPlayer == 0)
        {
            GameManager.sharedInstance.winnerContainer.GetComponentInChildren<Text>().text = "¡it's a tie!";
            Debug.Log("El juego ha terminado en empate.");
            HistoryManager.sharedInstance.DebugMovementsHistory();
        }
    }
}
