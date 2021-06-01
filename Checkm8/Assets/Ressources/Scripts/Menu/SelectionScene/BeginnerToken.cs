using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/**
 * Author : Samuel Goubeau
 * 
 * Manage : 
 * 
 * Using : SelectionScene2P.Canvas.Canvas-P1, SelectionScene2P.Canvas.Canvas-P2,
 *         SelectionScene4P.Canvas.Canvas-P1, SelectionScene4P.Canvas.Canvas-P2, 
 *         SelectionScene4P.Canvas.Canvas-P3, SelectionScene4P.Canvas.Canvas-P4
 */
public class BeginnerToken : MonoBehaviour
{
    [SerializeField] private GameObject tkBeginner;

    void Start()
    {
        tkBeginner.SetActive(false);
    }
}
