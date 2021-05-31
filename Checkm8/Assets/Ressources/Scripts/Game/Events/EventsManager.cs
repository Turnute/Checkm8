using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static GameObject eventPlate;

    void Start()
    {
        eventPlate = GameObject.FindGameObjectWithTag("event");
    }

    public static void EventPlateSpawn(int posX, int posY, int eventNum)
    {
        float x = posX;
        float y = posY;

        x *= 0.125f;
        y *= 0.125f;

        x += -0.438f;
        y += -0.438f;

        GameObject ev = Instantiate(eventPlate, new Vector3(x,y,0), Quaternion.identity);

        EventsPlate eventScript = ev.GetComponent<EventsPlate>();

        eventScript.eventNum = eventNum;
        eventScript.SetCoords(posX,posY);
    }

    public static void SetTeleportation()
    {
        Debug.Log("Teleportation");
    }

    public static void SetRotation()
    {
        Debug.Log("Rotation");
    }

    public static void SetTidalWaves()
    {
        Debug.Log("Tidal Waves");
    }

    public static void SetEruption()
    {
        Debug.Log("Eruption");
    }

    public static void SetPromotion()
    {
        Debug.Log("Promotion");
    }

    public static void Demotion()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        //On récupère une pièce de chaque joueur
        GameObject p1 = null;
        GameObject p2 = null;
        for(int i=0; i<controller.GetComponent<Controller>().player1.Length;i++)
        {
            if(controller.GetComponent<Controller>().player1[i])
            {
                if(controller.GetComponent<Controller>().player1[i].name != "pawn_p1" && controller.GetComponent<Controller>().player2[i].name != "king_p1")
                     p1 = controller.GetComponent<Controller>().player1[i];
            }
            if(controller.GetComponent<Controller>().player2[i])
            {
                if(controller.GetComponent<Controller>().player2[i].name != "pawn_p2" && controller.GetComponent<Controller>().player2[i].name != "king_p2")
                     p2 = controller.GetComponent<Controller>().player2[i];
            }
        }

        //On effectue la démotion
        int x1,y1,x2,y2;
        x1 = p1.GetComponent<Chessman>().xBoard;
        y1 = p1.GetComponent<Chessman>().yBoard;
        x2 = p2.GetComponent<Chessman>().xBoard;
        y2 = p2.GetComponent<Chessman>().yBoard;

        Destroy(p1);
        Destroy(p2);

        GameObject pawn1 = controller.GetComponent<Controller>().Create("pawn_p1",x1,y1);
        GameObject pawn2 = controller.GetComponent<Controller>().Create("pawn_p2",x2,y2);
        controller.GetComponent<Controller>().SetPosition(pawn1);
        controller.GetComponent<Controller>().SetPosition(pawn2);
    }

    public static void SetDemotion()
    {
        GameObject cont = GameObject.FindGameObjectWithTag("GameController");
        //Trouver une case libre
        List<Vector2> freePos = new List<Vector2>();
        for(int i = 0;i<8;i++)
        {
            for(int j = 0;j<8;j++)
            {
                if(cont.GetComponent<Controller>().GetPosition(i,j) == null)//Si position vide
                {
                    freePos.Add(new Vector2(i,j));
                }
            }
        }
        //Tirage d'une case aléatoire
        int rand = Random.Range(0, freePos.Count);

        EventPlateSpawn((int)freePos[rand].x,(int)freePos[rand].y,5);
    }

    public static void SetProtection()
    {
        Debug.Log("Protection");
    }

    public static void SetFlamesStrike()
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
            float maxVal;

            //Créations d'intervalles de valeurs correspondant à chaque events
            float tp = 0 + GameSettings.tpProbabilty;
            float rota = tp + GameSettings.rotaProbabilty;
            float twaves = rota + GameSettings.twavesProbabilty;
            float erupt = twaves + GameSettings.eruptProbabilty;
            float promo = erupt + GameSettings.promoProbabilty;
            float demo = promo + GameSettings.demoProbabilty;
            float protect = demo + GameSettings.protecProbabilty;
            float fstrike = protect + GameSettings.fstrikeProbabilty;

            maxVal = fstrike;
            float rand = Random.Range(0, maxVal);

            //Choix de l'event
            if(rand >=0 && rand <=tp)
                SetTeleportation();
            if(rand >tp && rand <=rota)
                SetRotation();
            if(rand >rota && rand <=twaves)
                SetTidalWaves();
            if(rand >twaves && rand <=erupt)
                SetEruption();
            if(rand >erupt && rand <=promo)
                SetPromotion();
            if(rand >promo && rand <=demo)
                SetDemotion();
            if(rand >demo && rand <=protect)
                SetProtection();
            if(rand >protect && rand <=fstrike)
                SetFlamesStrike();
        }
    }
}
