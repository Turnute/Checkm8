using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DataConfig 
{
    public  bool PauseButton;
    public  float Time;
    public  float AddTime;
    public  float MultTimer;
    public  float MultTimeTurn;

    public  bool AlliedMouvement;
    public  bool EnemyMouvement;
    public  bool AlliedinDanger;
    public  bool EnemyinDanger;

    public  float AllEventProb;
    public  float NbTurnEvent;
    public  float TPEventProb;
    public  float RotEventProb;
    public  float RDMEventProb;
    public  float EruptionEventProb;
    public  float PromEventProb;
    public  float DemoEventProb;
    public  float ProtecEventProb;
    public  float SofEventProb;

    
    public DataConfig(Rulesets Config)
    {
        PauseButton = Config.getPauseButton();
        Time = Config.getTime();
        AddTime = Config.getAddTime();
        MultTimer = Config.getMultTimer();
        MultTimeTurn = Config.getMultTimer();

        AlliedMouvement = Config.getAlliedMouvement();
        EnemyMouvement = Config.getEnemyMouvement();
        AlliedinDanger = Config.getAlliedinDanger();
        EnemyinDanger = Config.getEnemyinDanger();

        AllEventProb = Config.getAllEventProb();
        NbTurnEvent = Config.getNbTurnEvent();
        TPEventProb = Config.getTPEventProb();
        RotEventProb = Config.getRotEventProb();
        RDMEventProb = Config.getRDMEventProb();
        EruptionEventProb = Config.getEruptionEventProb();
        PromEventProb = Config.getPromEventProb();
        DemoEventProb = Config.getDemoEventProb();
        ProtecEventProb = Config.getProtecEventProb();
        SofEventProb = Config.getSofEventProb();
    }

}
