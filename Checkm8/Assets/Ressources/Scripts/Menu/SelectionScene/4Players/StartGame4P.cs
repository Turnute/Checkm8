using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * Author : Samuel Goubeau
 * 
 * Manage : Manage the start of the game, with pop up display when something is wrong
 * 
 * Using : SelectionScene4P.SceneManager, SelectionScene4P.Canvas.StartButton
 */
public class StartGame4P : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Player1;
    [SerializeField] private SpriteRenderer Player2;
    [SerializeField] private SpriteRenderer Player3;
    [SerializeField] private SpriteRenderer Player4;
    [SerializeField] private GameObject popUpMissingChoice;
    [SerializeField] private GameObject popUpSameColor;

    public void Start()
    {
        popUpMissingChoice.SetActive(false);
        popUpSameColor.SetActive(false);
    }

    /**
     * Start the game 
     */
    public void startGame()
    {
        if(Player1.sprite == null || Player2.sprite == null || Player3.sprite == null || Player4.sprite == null)
        {
            popUpMissingChoice.SetActive(true);
        }
        else
        {
            if(checkColorsSet())
            {
                popUpSameColor.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("WorkInProgress");
            }
        }
    }


    public void closePopUp()
    {
        popUpMissingChoice.SetActive(false);
        popUpSameColor.SetActive(false);
    }


    public bool checkColorsSet()
    {
        if (Player1.color.Equals(Player2.color) && Player1.sprite == Player2.sprite)
        {
            return true;
        }

        if (Player1.color.Equals(Player3.color) && Player1.sprite == Player3.sprite)
        {
            return true;
        }

        if (Player1.color.Equals(Player4.color) && Player1.sprite == Player4.sprite)
        {
            return true;
        }

        if (Player2.color.Equals(Player3.color) && Player2.sprite == Player3.sprite)
        {
            return true;
        }

        if (Player2.color.Equals(Player4.color) && Player2.sprite == Player4.sprite)
        {
            return true;
        }

        if (Player3.color.Equals(Player4.color) && Player3.sprite == Player4.sprite)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
