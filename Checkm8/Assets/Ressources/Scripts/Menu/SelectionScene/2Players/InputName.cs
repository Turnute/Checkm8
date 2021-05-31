using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Author : Samuel Goubeau
 * 
 * Manage : Put a default name for all players
 * 
 * Using : Canvas.Canvas-P1.Player1-Name, Canvas.Canvas-P2.Player2-Name
 */
public class InputName : MonoBehaviour
{
    [SerializeField] private InputField firstPlayer;

    void Start()
    {
        if(GetComponent<InputField>() == firstPlayer)
        {
            GetComponent<InputField>().text = "Player1";
        }
        else
        {
            GetComponent<InputField>().text = "Player2";
        }
    }
}
