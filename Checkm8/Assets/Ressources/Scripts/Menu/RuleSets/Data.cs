using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DataConfig 
{
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

    
    public DataConfig(Rulesets Data)
    {
        PauseButton = Data.getPauseButton();
        Time = Data.getTime();
        AddTime = Data.getAddTime();
        MultTimer = Data.getMultTimer();
        MultTimeTurn = Data.getMultTimer();

        AlliedMouvement = Data.getAlliedMouvement();
        EnemyMouvement = Data.getEnemyMouvement();
        AlliedinDanger = Data.getAlliedinDanger();
        EnemyinDanger = Data.getEnemyinDanger();

        AllEventProb = Data.getAllEventProb();
        NbTurnEvent = Data.getNbTurnEvent();
        TPEventProb = Data.getTPEventProb();
        RotEventProb = Data.getRotEventProb();
        RDMEventProb = Data.getRDMEventProb();
        EruptionEventProb = Data.getEruptionEventProb();
        PromEventProb = Data.getPromEventProb();
        DemoEventProb = Data.getDemoEventProb();
        ProtecEventProb = Data.getProtecEventProb();
        SofEventProb = Data.getSofEventProb();
    }

}
