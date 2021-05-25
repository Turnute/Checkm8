using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public  class Rulesets : MonoBehaviour
{
    private UnityEngine.UI.Toggle toggle;

    private int Nsave;

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

        Nsave = 1;

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
   

    public void SaveConfig()
    {
        if(Nsave == 0)
        {
            //SaveSystem.SaveConfig(this, "");
        }
        else
        {
            SaveSystem.SaveConfig(this, Nsave.ToString());
        }
        
    }

    public void LoadConfig(string nb)
    {
        DataConfig DataConfig = SaveSystem.loadConfig(nb);

        PauseButton = DataConfig.PauseButton;
        Time = DataConfig.Time;
        AddTime = DataConfig.AddTime;
        MultTimer = DataConfig.MultTimer;
        MultTimeTurn = DataConfig.MultTimeTurn;

        AlliedMouvement = DataConfig.AlliedMouvement;
        EnemyMouvement = DataConfig.EnemyMouvement;
        AlliedinDanger = DataConfig.AlliedinDanger;
        EnemyinDanger = DataConfig.EnemyinDanger;

        AllEventProb = DataConfig.AllEventProb;
        NbTurnEvent = DataConfig.NbTurnEvent;
        TPEventProb = DataConfig.TPEventProb;
        RotEventProb = DataConfig.RotEventProb;
        RDMEventProb = DataConfig.RDMEventProb;
        EruptionEventProb = DataConfig.EruptionEventProb;
        PromEventProb = DataConfig.PromEventProb;
        DemoEventProb = DataConfig.DemoEventProb;
        ProtecEventProb = DataConfig.ProtecEventProb;
        SofEventProb = DataConfig.SofEventProb;

        ReLogValue();
    }




    private void ReLogValue()
    {
        if (TimerMenu.activeSelf)
        {
            //Timer
            switch (Mathf.RoundToInt(MultTimer))
            {
                case 60:
                    GameObject.Find("TimeNB").GetComponent<InputField>().text = (Time/60).ToString();
                    GameObject.Find("Unites").GetComponent<Dropdown>().value = 1;
                    break;
                case 3600:
                    GameObject.Find("TimeNB").GetComponent<InputField>().text = (Time / 3600).ToString();
                    GameObject.Find("Unites").GetComponent<Dropdown>().value = 2;
                    break;
                default:
                    GameObject.Find("TimeNB").GetComponent<InputField>().text = Time.ToString();
                    GameObject.Find("Unites").GetComponent<Dropdown>().value = 0;

                    break;
            }
            switch (Mathf.RoundToInt(MultTimeTurn))
            {
                case 60:
                    GameObject.Find("TimeTurn").GetComponent<InputField>().text = (AddTime / 60).ToString();
                    GameObject.Find("Unites_2").GetComponent<Dropdown>().value = 1;
                    break;
                case 3600:
                    GameObject.Find("TimeTurn").GetComponent<InputField>().text = (AddTime / 3600).ToString();
                    GameObject.Find("Unites_2").GetComponent<Dropdown>().value = 2;
                    break;
                default:
                    GameObject.Find("TimeTurn").GetComponent<InputField>().text = AddTime.ToString();
                    GameObject.Find("Unites_2").GetComponent<Dropdown>().value = 0;

                    break;
            }
            GameObject.Find("Pause").GetComponent<Toggle>().isOn = PauseButton;

        }
        else
        {

            if (HelpMenu.activeSelf)
            {
                //Help
                GameObject.Find("AlliedMouvement").GetComponent<Toggle>().isOn = AlliedMouvement;
                GameObject.Find("EnemyMouvement").GetComponent<Toggle>().isOn = EnemyMouvement;
                GameObject.Find("AlliedinDanger").GetComponent<Toggle>().isOn = AlliedinDanger;
                GameObject.Find("EnemyinDanger").GetComponent<Toggle>().isOn = EnemyinDanger;
            }
            else
            {
                if (EventMenu.activeSelf)
                {
                    //Event
                    GameObject.Find("AllEvent").GetComponent<InputField>().text = AllEventProb.ToString();
                    GameObject.Find("NbTurn").GetComponent<InputField>().text = NbTurnEvent.ToString();
                    GameObject.Find("TP").GetComponent<InputField>().text = TPEventProb.ToString();
                    GameObject.Find("Rotation").GetComponent<InputField>().text = RotEventProb.ToString();
                    GameObject.Find("Tidal Waves").GetComponent<InputField>().text = RDMEventProb.ToString();
                    GameObject.Find("Eruption").GetComponent<InputField>().text = EruptionEventProb.ToString();
                    GameObject.Find("Promotion").GetComponent<InputField>().text = PromEventProb.ToString();
                    GameObject.Find("Demotion").GetComponent<InputField>().text = DemoEventProb.ToString();
                    GameObject.Find("Protection").GetComponent<InputField>().text = ProtecEventProb.ToString();
                    GameObject.Find("Streak of Flames").GetComponent<InputField>().text = SofEventProb.ToString();
                }
            }

        }
    }

    public void selectConfig(int Nconfig)
    {
        Nsave = Nconfig - 1;
        switch (Nconfig)
        {
            case 1:
                LoadConfig("");
                break;

            default:
                
                LoadConfig(Nsave.ToString());
                break;
        }

    }
    // Setter pour les valeurs des Timers

    public void selectMultTimerTurn(int select)
    {
        switch (select)
        {
            case 1:
                MultTimeTurn = 60;
                ReLogValue();
                break;
            case 2:
                MultTimeTurn = 3600;
                ReLogValue();
                break;
            default:
                MultTimeTurn = 1;
                ReLogValue();
                break;
        }
    }

    public void selectMultTimer(int select)
    {
        switch (select)
        {
            case 1:
                MultTimer = 60;
                ReLogValue();
                break;
            case 2:
                MultTimer = 3600;
                ReLogValue();
                break;
            default:
                MultTimer = 1;
                ReLogValue();
                break;
        }
    }



    //ensemble des ouverture et fermeture des menus

    public void HelpMenushow(bool isOpen)
    {
        TimerMenu.SetActive(false);
        EventMenu.SetActive(false);
        HelpMenu.SetActive(true);
        ReLogValue();

    }

    public void TimerMenushow(bool isOpen)
    {
        HelpMenu.SetActive(false);
        EventMenu.SetActive(false);
        TimerMenu.SetActive(true);
        ReLogValue();
    }

    public void EventMenushow(bool isOpen)
    {
        HelpMenu.SetActive(false);
        TimerMenu.SetActive(false);
        EventMenu.SetActive(true);
        ReLogValue();
    }



    public void SetTime(string isTime)
    {
        Time = (float.Parse(isTime)*MultTimer);
    }

    public void SetTimeTurn(string isAddTime)
    {
        AddTime = (float.Parse(isAddTime) * MultTimeTurn);
    }


    // Setter pour les valeurs de Help
    public void SetAlliedMouvement(bool isAlliedMouvement)
    {
        AlliedMouvement = isAlliedMouvement;
    }

    public void SetEnemyMouvement(bool isEnemyMouvement)
    {
        EnemyMouvement = isEnemyMouvement;
    }

    public void SetAlliedinDanger(bool isAlliedinDanger)
    {
        AlliedinDanger = isAlliedinDanger;
    }

    public void SetEnemyinDanger(bool isEnemyinDanger)
    {
        EnemyinDanger = isEnemyinDanger;
    }

    //Setter pour les valeurs des Events

    public void SetAllEventProb(string isAllEventProb)
    { 
        AllEventProb = float.Parse(isAllEventProb);
    }
    public void SetNbTurnEvent(string isNbTurnEvent)
    {
        NbTurnEvent = float.Parse(isNbTurnEvent);
    }
    public void SetTPEventProb(string isTPEventProb)
    {
        TPEventProb = float.Parse(isTPEventProb);
    }
    public void SetRotEventProb(string isRotEventProb)
    {
        RotEventProb = float.Parse(isRotEventProb);
    }
    public void SetRDMEventProb(string isRDMEventProb)
    {
        RDMEventProb = float.Parse(isRDMEventProb);
    }
    public void SetEruptionEventProb(string isEruptionEventProb)
    {
        EruptionEventProb = float.Parse(isEruptionEventProb);
    }
    public void SetPromEventProb(string isPromEventProb)
    {
        PromEventProb = float.Parse(isPromEventProb);
    }
    public void SetDemoEventProb(string isDemoEventProb)
    {
        DemoEventProb = float.Parse(isDemoEventProb);
    }
  
    public void SetProtecEventProb(string isProtecEventProb)
    {
        ProtecEventProb = float.Parse(isProtecEventProb);
    }
    public void SetSofEventProbb(string isSofEventProb)
    {
        SofEventProb = float.Parse(isSofEventProb);
    }



    // getters 

    public bool getPauseButton()
    {
        return PauseButton;
    }
    public float getTime()
    {
        return Time;
    }
    public float getAddTime()
    {
        return AddTime;
    }
    public float getMultTimer()
    {
        return MultTimer;
    }
    public float getMultTimeTurn()
    {
        return MultTimeTurn;
    }

    public bool getAlliedMouvement()
    {
        return AlliedMouvement;
    }
    public bool getEnemyMouvement()
    {
        return EnemyMouvement;
    }
    public bool getAlliedinDanger()
    {
        return AlliedinDanger;
    }
    public bool getEnemyinDanger()
    {
        return EnemyinDanger;
    }



    public float getAllEventProb()
    {
        return AllEventProb;
    }
    public float getNbTurnEvent()
    {
        return NbTurnEvent;
    }
    public float getTPEventProb()
    {
        return TPEventProb;
    }
    public float getRotEventProb()
    {
        return RotEventProb;
    }
    public float getRDMEventProb()
    {
        return RDMEventProb;
    }
    public float getEruptionEventProb()
    {
        return EruptionEventProb;
    }
    public float getPromEventProb()
    {
        return PromEventProb;
    }
    public float getDemoEventProb()
    {
        return DemoEventProb;
    }
    public float getProtecEventProb()
    {
        return ProtecEventProb;
    }
    public float getSofEventProb()
    {
        return SofEventProb;
    }

















    




}
