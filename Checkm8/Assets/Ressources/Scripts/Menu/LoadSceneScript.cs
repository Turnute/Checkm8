using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    private static int previousScene = 0;

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
        previousScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(scene);
    }

    /** 
     * Load the previous scene
     */
    public void loadPreviousScene()
    {
        SceneManager.LoadScene(previousScene);
    }
}
