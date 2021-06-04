﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/**
 * Author : Samuel Goubeau
 * 
 * Manage : Put a yellow tokken on the player's profil when they right click on it
 * 
 * Using : SelectionScene2P.Canvas.Canvas-P1, SelectionScene2P.Canvas.Canvas-P2,
 *         SelectionScene4P.Canvas.Canvas-P1, SelectionScene4P.Canvas.Canvas-P2, 
 *         SelectionScene4P.Canvas.Canvas-P3, SelectionScene4P.Canvas.Canvas-P4
 */
public class StartingToken2P : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject tkStartingCur;
    [SerializeField] private GameObject tkStartingOther;

    public bool isStarting;
    private bool isIn;
    private CanvasGroup curCanvasGroup;
    private CanvasGroup otherCanvasGroup;


    void Start()
    {
        curCanvasGroup = tkStartingCur.GetComponent<CanvasGroup>();
        otherCanvasGroup = tkStartingOther.GetComponent<CanvasGroup>();

        curCanvasGroup.alpha = 0f;
        isStarting = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("isIn");
        isIn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("isOut");
        isIn = false;
    }

    void Update()
    {
        //  Permet de mettre à FALSE isStarting quand l'opacité est modifiée par
        // une autre instance
        if(curCanvasGroup.alpha == 0f && isStarting)
        {
            isStarting = false;
        }

        if (Input.GetAxisRaw("Fire2") > 0.5f && isIn)
        {
            if (curCanvasGroup.alpha != 0f)
            {
                curCanvasGroup.alpha = 0f;
                isStarting = false;
            }
            else
            {
                if(otherCanvasGroup.alpha != 0f)
                {
                    otherCanvasGroup.alpha = 0f;
                }

                curCanvasGroup.alpha = 1f;
                isStarting = true;
            }
        }
    }
}
