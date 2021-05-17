using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rulesets : MonoBehaviour
{
    public static bool PauseButton;
    public static float Time;

    public static bool AlliedMouvement;
    public static bool EnemyMouvement;
    public static bool AlliedinDanger;
    public static bool EnemyinDanger;

    public static float AllEventProb;
    public static float NbTurnEvent;
    public static float TPEventProb;
    public static float RotEventProb;
    public static float RDMEventProb;
    public static float EruptionEventProb;
    public static float PromEventProb;
    public static float DemoEventProb;
    public static float ProtecEventProb;
    public static float SofEventProb;

    GameObject HelpMenu;
    GameObject TimerMenu;
    


    // Start is called before the first frame update
    void Start()
    {
        HelpMenu = GameObject.Find("HelpCanva");
        TimerMenu = GameObject.Find("TimerCanva");

        PauseButton = false ;
         Time = 0;

         AlliedMouvement = true;
         EnemyMouvement = true;
         AlliedinDanger = true;
         EnemyinDanger = true ;

         AllEventProb = 10;
         NbTurnEvent = 1;
         TPEventProb = 1;
         RotEventProb = 1;
         RDMEventProb = 1;
         EruptionEventProb = 1;
         PromEventProb = 1;
        DemoEventProb = 1;
        ProtecEventProb = 1;
        SofEventProb = 1;
}



    public void SetAlliedMouvement(bool isAlliedMouvement)
    {
        AlliedMouvement = isAlliedMouvement;
        Debug.Log("it work");
    }

    public void SetEnemyMouvement(bool isEnemyMouvement)
    {
        EnemyMouvement = isEnemyMouvement;
        Debug.Log("it work");
    }

    public void SetAlliedinDanger(bool isAlliedinDanger)
    {
        AlliedinDanger = isAlliedinDanger;
        Debug.Log("it work");
    }

    public void SetEnemyinDanger(bool isEnemyinDanger)
    {
        EnemyinDanger = isEnemyinDanger;
        Debug.Log("it work");
    }

    public void HelpMenushow(bool isOpen)
    {
        HelpMenu.SetActive(isOpen);
    }




}
