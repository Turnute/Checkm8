using System.Collections;
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
public class StartingToken : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject tkBeginnerCur;
    [SerializeField] private GameObject tkBeginnerOther;

    private bool isActive;
    private bool isIn;
    private CanvasGroup curCanvasGroup;
    private CanvasGroup otherCanvasGroup;


    void Start()
    {
        curCanvasGroup = tkBeginnerCur.GetComponent<CanvasGroup>();
        otherCanvasGroup = tkBeginnerOther.GetComponent<CanvasGroup>();

        isActive = false;
        curCanvasGroup.alpha = 0f;
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
        if (Input.GetAxisRaw("Fire2") > 0.5f && isIn)
        {
            if (isActive)
            {
                isActive = false;
                curCanvasGroup.alpha = 0f;
            }
            else
            {
                if(otherCanvasGroup.alpha != 0f)
                {
                    otherCanvasGroup.alpha = 0f;
                }

                isActive = true;
                curCanvasGroup.alpha = 1f;
            }
        }
    }
}
