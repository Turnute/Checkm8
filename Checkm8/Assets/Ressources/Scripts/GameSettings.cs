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
    public static float eventProbability;

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
        //Valeurs par défauts des probas
        turnBtwnEvent = 3;
        eventProbability = 50;

        tpProbabilty = 12.5f;
        rotaProbabilty = 12.5f;
        twavesProbabilty = 12.5f;
        eruptProbabilty = 12.5f;
        promoProbabilty = 12.5f;
        demoProbabilty = 12.5f;
        protecProbabilty = 12.5f;
        fstrikeProbabilty = 12.5f;

        //On évite les doublons
        if(!exists)
        {
            DontDestroyOnLoad(gameObject);
            exists = true;
        }else{
            Destroy(gameObject);
        }
    }

    public static void UpdateProba()
    {
        turnBtwnEvent = Rulesets.NbTurnEvent;
        eventProbability = Rulesets.AllEventProb;

        tpProbabilty = Rulesets.TPEventProb;
        rotaProbabilty = Rulesets.RotEventProb;
        twavesProbabilty = Rulesets.RDMEventProb;
        eruptProbabilty = Rulesets.EruptionEventProb;
        promoProbabilty = Rulesets.PromEventProb;
        demoProbabilty = Rulesets.DemoEventProb;
        protecProbabilty = Rulesets.ProtecEventProb;
        fstrikeProbabilty = Rulesets.SofEventProb;
    }
}
