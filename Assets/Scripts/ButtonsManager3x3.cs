using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonsManager3x3 : MonoBehaviour
{
    public static ButtonsManager3x3 sharedIntance;
    public Button[] buttonsList;
    
    // auxiliar matrix for obtain the positions of clicked button and update the game history 
    int[,] auxMatrix = new int[3, 3];


    private void Awake()
    {
        sharedIntance = this;
    }

    private void Start()
    {
        int contAux = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                auxMatrix[i, j] = contAux;
                contAux++;
            }
        }
    }


    /// <summary>
    /// Method that allows me to change the image of the button according to the one selected by each player by clicking on the selected button
    /// </summary>
    /// <param name="buttonIndex">Index of the touched button that is passed on the OnClick</param>
    public void generateImageOnBoard(int buttonIndex)
    {
        Button clickedButton = buttonsList[buttonIndex-1];

        Image newImage = clickedButton.GetComponent<Image>();
        
        if (GameManager.sharedInstance.player1Turn)
        {
            newImage.sprite = GameManager.sharedInstance.player1Sprite;
        }
        else
        {
            newImage.sprite = GameManager.sharedInstance.player2Sprite;
        }

        clickedButton.interactable = false;
        updateMovementsHistory(buttonIndex);
        GameManager.sharedInstance.ChangeTurn();
    }


    /// <summary>
    /// Method to update the vector of the movements made that will help me determine the winner
    /// </summary>
    /// <param name="buttonIndex"> Index of the button that was pressed </param>
    public void updateMovementsHistory(int buttonIndex)
    {

        int rowPosition = 0;
        int columnPosition = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (buttonIndex == auxMatrix[i, j])
                {
                    rowPosition = i+1;
                    columnPosition = j+1;
                }
            }
        }

        float timeInSeconds = Time.time;

        if (GameManager.sharedInstance.player1Turn)
        {
            WinnerManager.sharedInstance.movementHistoryArray[buttonIndex - 1] = 1;
            string log = "[" + Math.Round(timeInSeconds, 4) + " s]" + " Player 1 played in position " + "[" + rowPosition + "," + columnPosition + "] of board";
            Debug.Log(log);
            HistoryManager.sharedInstance.AddLogToPlayerHistory(log, 1);
        }
        else
        {
            WinnerManager.sharedInstance.movementHistoryArray[buttonIndex - 1] = 2;
            string log = "[" + Math.Round(timeInSeconds, 4) + " s]" + " Player 2 played in position " + "[" + rowPosition + "," + columnPosition + "] of board";
            Debug.Log(log);
            HistoryManager.sharedInstance.AddLogToPlayerHistory(log, 2);
        }
    }

}
