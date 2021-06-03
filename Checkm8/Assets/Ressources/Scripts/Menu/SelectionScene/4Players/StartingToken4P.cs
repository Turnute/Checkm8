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
public class StartingToken4P : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject tkStartingCur;
    [SerializeField] private GameObject tkStartingOther1;
    [SerializeField] private GameObject tkStartingOther2;
    [SerializeField] private GameObject tkStartingOther3;

    private bool isIn;
    private CanvasGroup curCanvasGroup;
    private CanvasGroup otherCanvasGroup1;
    private CanvasGroup otherCanvasGroup2;
    private CanvasGroup otherCanvasGroup3;


    void Start()
    {
        curCanvasGroup = tkStartingCur.GetComponent<CanvasGroup>();
        otherCanvasGroup1 = tkStartingOther1.GetComponent<CanvasGroup>();
        otherCanvasGroup2 = tkStartingOther2.GetComponent<CanvasGroup>();
        otherCanvasGroup3 = tkStartingOther3.GetComponent<CanvasGroup>();

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
            if (curCanvasGroup.alpha != 0f)
            {
                curCanvasGroup.alpha = 0f;
            }
            else
            {
                if (otherCanvasGroup1.alpha != 0f)
                {
                    otherCanvasGroup1.alpha = 0f;
                }
                if (otherCanvasGroup2.alpha != 0f)
                {
                    otherCanvasGroup2.alpha = 0f;
                }
                if (otherCanvasGroup3.alpha != 0f)
                {
                    otherCanvasGroup3.alpha = 0f;
                }

                curCanvasGroup.alpha = 1f;
            }
        }
    }
}
