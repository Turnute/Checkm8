using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static void Teleportation()
    {
        Debug.Log("Teleportation");
    }

    public static void Rotation()
    {
        Debug.Log("Rotation");
    }

    public static void TidalWaves()
    {
        Debug.Log("Tidal Waves");
    }

    public static void Eruption()
    {
        Debug.Log("Eruption");
    }

    public static void Promotion()
    {
        Debug.Log("Promotion");
    }

    public static void Demotion()
    {
        Debug.Log("Demotion");
    }

    public static void Protection()
    {
        Debug.Log("Protection");
    }

    public static void FlamesStrike()
    {
        Debug.Log("Flames Strike");
    }

    private static bool shouldEventPlay(float proba)//Renvoie true si un event doit apparaître ce tour ci
    {
        float rand = Random.Range(0, 100);
        if(rand <= proba)
            return true;
        else
            return false;
    }

    public static void chooseEvent()//Choisit un event en fonction des proba d'apparition
    {
        if(shouldEventPlay(GameSettings.eventProbability))
        {
            float rand = Random.Range(0, 100);

            //Créations d'intervalles de valeurs correspondant à chaque events
            float tp = 0 + GameSettings.tpProbabilty;
            float rota = tp + GameSettings.rotaProbabilty;
            float twaves = rota + GameSettings.twavesProbabilty;
            float erupt = twaves + GameSettings.eruptProbabilty;
            float promo = erupt + GameSettings.promoProbabilty;
            float demo = promo + GameSettings.demoProbabilty;
            float protect = demo + GameSettings.protecProbabilty;
            float fstrike = protect + GameSettings.fstrikeProbabilty;

            //Choix de l'event
            if(rand >=0 && rand <=tp)
                Teleportation();
            if(rand >tp && rand <=rota)
                Rotation();
            if(rand >rota && rand <=twaves)
                TidalWaves();
            if(rand >twaves && rand <=erupt)
                Eruption();
            if(rand >erupt && rand <=promo)
                Promotion();
            if(rand >promo && rand <=demo)
                Demotion();
            if(rand >demo && rand <=protect)
                Protection();
            if(rand >protect && rand <=fstrike)
                FlamesStrike();
        }
    }
}
