using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Author : Samuel Goubeau
 * 
 * Manage : Put a default name for all players
 * 
 * Using : SelectionScene2P.Canvas.Canvas-P1.Player1-Name, SelectionScene2P.Canvas.Canvas-P2.Player2-Name,
 *         SelectionScene4P.Canvas.Canvas-P1.Player1-Name, SelectionScene4P.Canvas.Canvas-P2.Player2-Name,
 *         SelectionScene4P.Canvas.Canvas-P3.Player3-Name, SelectionScene4P.Canvas.Canvas-P4.Player4-Name
 */
public class InputName : MonoBehaviour
{
    [SerializeField] private int playerNum;

    void Start()
    {
        GetComponent<InputField>().text = "Player" + playerNum;
    }
}
