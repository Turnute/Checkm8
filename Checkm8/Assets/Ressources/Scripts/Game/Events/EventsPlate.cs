using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsPlate : MonoBehaviour
{
    public int eventNum;
   //Position du board
    int matrixX;
    int matrixY;

    public void SetCoords(int posX, int posY)
    {
        matrixX = posX;
        matrixY = posY;
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("piece"))
        {
            switch(eventNum)
            {
                case 5 :
                    EventsManager.Demotion();
                    Destroy(gameObject);
                    Debug.Log("demo");
                    break;
            }
        }
    }
}
