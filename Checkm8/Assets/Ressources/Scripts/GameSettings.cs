using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    private static bool exists;
    public static Color colorP1 = Color.white;
    public static Color colorP2 = Color.black;

    void Start()
    {
        //On évite les doublons
        if(!exists)
        {
            DontDestroyOnLoad(gameObject);
            exists = true;
        }else{
            Destroy(gameObject);
        }
    }
}
