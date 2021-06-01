using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPanel : MonoBehaviour
{
    public GameObject controller;

    public GameObject demoIm;

    public static bool demo;

    private float effectTime = 2;//Temps de l'effet en secondes

    void Update()
    {
        if(demo)
        {
            demoIm.SetActive(true);
            effectTime -= Time.deltaTime;
        }

        if(effectTime < 2)
        {
            effectTime -= Time.deltaTime;
        }
        if(effectTime <= 0)
        {
            demoIm.SetActive(false);
            demo = false;
            EventsManager.eventPanelText.GetComponent<Text>().text = "";
            controller.GetComponent<Controller>().lighting.GetComponent<Animator>().SetBool("gameOver",false);
            effectTime = 2;
        }
    }

}
