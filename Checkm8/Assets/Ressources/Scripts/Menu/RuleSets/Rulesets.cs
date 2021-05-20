using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rulesets : MonoBehaviour
{


    private UnityEngine.UI.Toggle toggle;

    public static bool PauseButton;
    public static float Time;
    public static float AddTime;
    public static float MultTimer;
    public static float MultTimeTurn;

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
    GameObject EventMenu;

    



    // Start is called before the first frame update
    void Start()
    {
        
        HelpMenu = GameObject.Find("HelpCanva");
        TimerMenu = GameObject.Find("TimerCanva");
        EventMenu = GameObject.Find("EventCanva");

        HelpMenu.SetActive(false);
        TimerMenu.SetActive(false);
        EventMenu.SetActive(false);

        PauseButton = false ;
        MultTimer = 1;
        MultTimeTurn = 1;
        Time = 0;
        AddTime = 0;

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
    // Setter pour les valeurs des Timers

    public void selectMultTimerTurn(int select)
    {
        switch (select)
        {
            case 1:
                MultTimeTurn = 60;
                break;
            case 2:
                MultTimeTurn = 3600;
                break;
            default:
                MultTimeTurn = 1;
                break;
        }
    }

    public void selectMultTimer(int select)
    {
        switch (select)
        {
            case 1:
                MultTimer = 60;
                break;
            case 2:
                MultTimer = 3600;
                break;
            default:
                MultTimer = 1;
                break;
        }
    }

    public void SetTime(string isTime)
    {
        Time = (float.Parse(isTime)*MultTimer);
        Debug.Log(Time);
    }

    public void SetTimeTurn(string isAddTime)
    {
        AddTime = (float.Parse(isAddTime) * MultTimeTurn);
        Debug.Log(AddTime);
    }


    // Setter pour les valeurs de Help
    public void SetAlliedMouvement(bool isAlliedMouvement)
    {
        AlliedMouvement = isAlliedMouvement;
        Debug.Log(AlliedMouvement);
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

    //Setter pour les valeurs des Events

    public void SetAllEventProb(string isAllEventProb)
    { 
        AllEventProb = float.Parse(isAllEventProb);
        Debug.Log(AllEventProb);
    }
    public void SetNbTurnEvent(string isNbTurnEvent)
    {
        NbTurnEvent = float.Parse(isNbTurnEvent);
        Debug.Log("it work");
    }
    public void SetTPEventProb(string isTPEventProb)
    {
        TPEventProb = float.Parse(isTPEventProb);
        Debug.Log("it work");
    }
    public void SetRotEventProb(string isRotEventProb)
    {
        RotEventProb = float.Parse(isRotEventProb);
        Debug.Log("it work");
    }
    public void SetRDMEventProb(string isRDMEventProb)
    {
        RDMEventProb = float.Parse(isRDMEventProb);
        Debug.Log("it work");
    }
    public void SetEruptionEventProb(string isEruptionEventProb)
    {
        EruptionEventProb = float.Parse(isEruptionEventProb);
        Debug.Log("it work");
    }
    public void SetPromEventProb(string isPromEventProb)
    {
        PromEventProb = float.Parse(isPromEventProb);
        Debug.Log("it work");
    }
    public void SetDemoEventProb(string isDemoEventProb)
    {
        DemoEventProb = float.Parse(isDemoEventProb);
        Debug.Log("it work");
    }
  
    public void SetProtecEventProb(string isProtecEventProb)
    {
        ProtecEventProb = float.Parse(isProtecEventProb);
        Debug.Log("it work");
    }
    public void SetSofEventProbb(string isSofEventProb)
    {
        SofEventProb = float.Parse(isSofEventProb);
        Debug.Log("it work");
    }





    //ensemble des ouverture et fermeture des menus

    public void HelpMenushow(bool isOpen)
    {
        TimerMenu.SetActive(false);
        EventMenu.SetActive(false);
        HelpMenu.SetActive(true);

    }

    public void TimerMenushow(bool isOpen)
    {
        HelpMenu.SetActive(false);
        EventMenu.SetActive(false);
        TimerMenu.SetActive(true);
    }

    public void EventMenushow(bool isOpen)
    {
        HelpMenu.SetActive(false);
        TimerMenu.SetActive(false);
        EventMenu.SetActive(true);
    }




}
