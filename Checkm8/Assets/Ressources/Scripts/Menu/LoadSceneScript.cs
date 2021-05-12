using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{

    /**
    * Exit game when the program call it
    */
    public void quitGame(){
        Debug.Log("exitgame");
        Application.Quit();
    }

    /**
    * Load scene in parameter
    */
    public void changeScene(string scene){
        SceneManager.LoadScene(scene);
    }
}
