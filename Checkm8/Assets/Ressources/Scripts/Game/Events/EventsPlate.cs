using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsPlate : MonoBehaviour
{
    public int eventNum;
    public SpriteRenderer eventImage;
   //Position du board
    int matrixX;
    int matrixY;

    public void SetCoords(int posX, int posY)
    {
        matrixX = posX;
        matrixY = posY;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("piece"))
        {
            switch(eventNum)
            {
                case 0 :
                    EventsManager.Teleportation(matrixX, matrixY);
                    Destroy(gameObject);
                    break;
                /*case 5 :
                    EventsManager.Demotion();
                    Destroy(gameObject);
                    break;*/
                case 7 :
                    EventsManager.FlameStrike();
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
