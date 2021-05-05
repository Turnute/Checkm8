using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    /**
    * Exit game when the program call it
    */
    public void quitGame(){
        Debug.Log("exitgame");
        Application.Quit();
    }

    /**
    * This is a temporary function, it will be changed later
    */
    public void startGame(){
        SceneManager.LoadScene("1v1_game");
    }
}
