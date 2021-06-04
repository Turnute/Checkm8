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
    [SerializeField] private GameObject p1Canvas;
    [SerializeField] private GameObject p2Canvas;

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
                if(p1Canvas.GetComponent<StartingToken2P>().isStarting)
                {
                    GameSettings.whoStarts = 1;
                }
                else if(p2Canvas.GetComponent<StartingToken2P>().isStarting)
                {
                    GameSettings.whoStarts = 2;
                }
                else
                {
                    int rand = Random.Range(1,3);
                    Debug.Log(rand);
                    GameSettings.whoStarts = rand;
                }
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
