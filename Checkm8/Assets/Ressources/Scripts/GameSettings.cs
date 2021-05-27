using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    private static bool exists;
    public static Color colorP1 = Color.white;
    public static Color colorP2 = Color.black;

    //Attributs nécessaires à la gestion des events
    public static int turnBtwnEvent;

    public static float tpProbabilty;
    public static float rotaProbabilty;
    public static float twavesProbabilty;
    public static float eruptProbabilty;
    public static float promoProbabilty;
    public static float demoProbabilty;
    public static float protecProbabilty;
    public static float fstrikeProbabilty;

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
