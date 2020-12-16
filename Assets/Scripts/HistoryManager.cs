using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryManager : MonoBehaviour
{
    public static HistoryManager sharedInstance;

    public List<string> player1MovementsHistory;
    public List<string> player2MovementsHistory;

    public Text player1GameHistoryText;
    public Text player2GameHistoryText;

    private void Awake()
    {
        sharedInstance = this;
    }

    /// <summary>
    /// Method that allows adding the events of the game to a list in which all the movements played by each player are stored
    /// </summary>
    /// <param name="log">message you want to add</param>
    /// <param name="player">player to whom the message of the movement made belongs</param>
    public void AddLogToPlayerHistory(string log, int player)
    {
        if (player == 1)
        {
            player1MovementsHistory.Add(log);
        }
        else
        {
            player2MovementsHistory.Add(log);
        }
    }

    /// <summary>
    /// Method that allows to show in the console the history of movements of the game
    /// </summary>
    public void DebugMovementsHistory()
    {
        Debug.Log("Historial del jugador 1: ");
        foreach (string log in player1MovementsHistory)
        {
            Debug.Log(log);
        }
        Debug.Log("Historial del jugador 2: ");
        foreach (string log in player2MovementsHistory)
        {
            Debug.Log(log);
        }
    }

    /// <summary>
    /// Method that allows to assign in each text the history of the player on the screen
    /// </summary>
    public void ShowGameHistoryInTexts()
    {
        string player1FullLogs = "";
        foreach (string log in player1MovementsHistory)
        {
            player1FullLogs += log + "\n";
        }
        player1GameHistoryText.text = player1FullLogs;

        string player2FullLogs = "";
        foreach (string log in player2MovementsHistory)
        {
            player2FullLogs += log + "\n";
        }
        player2GameHistoryText.text = player2FullLogs;
    }
}
