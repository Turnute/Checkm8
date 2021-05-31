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
 * Using : SelectionScene2P.SceneManager, SelectionScene2P.Canvas.StartButton
 */
public class StartGame2P : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Player1;
    [SerializeField] private SpriteRenderer Player2;
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
        if(Player1.sprite == null || Player2.sprite == null)
        {
            popUpMissingChoice.SetActive(true);
        }
        else
        {
            if(Player1.color.Equals(Player2.color))
            {
                popUpSameColor.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("1v1_game");
            }
        }
    }

    public void closePopUp()
    {
        popUpMissingChoice.SetActive(false);
        popUpSameColor.SetActive(false);
    }
}
