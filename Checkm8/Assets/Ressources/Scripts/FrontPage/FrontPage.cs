using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrontPage : MonoBehaviour
{
    /**
    * Load scene in parameter
    */
    public void changeScene(string scene){
        SceneManager.LoadScene(scene);
    }

}
