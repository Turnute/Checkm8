using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
 * Author : Samuel Goubeau
 * 
 * Manage : Manage when user drop the token on the object, place the token at 
 *          specific position. And change the sprite of the current player.
 *          
 * Using : Canvas.Select1, Canvas.Select2, Canvas.Select3, Canvas.Select4, 
 *         Canvas.Select5, Canvas.Select6, Canvas.Select7, Canvas.Select8
 */
public class CharacterSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private SelectCoins P1coin;
    [SerializeField] private SelectCoins P2coin;
    [SerializeField] private SelectCoins P3coin;
    [SerializeField] private SelectCoins P4coin;

    [SerializeField] private Sprite piece;

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            if(P3coin == null || P4coin == null)
            {
                if (eventData.pointerDrag.GetComponent<SelectCoins>() == P1coin)
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + new Vector2(-30.0f, 20.0f);
                    eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.sprite = piece;
                    eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.color = PieceColorModify.colors[0];
                }
                else if (eventData.pointerDrag.GetComponent<SelectCoins>() == P2coin)
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + new Vector2(30.0f, 20.0f);
                    eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.sprite = piece;
                    eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.color = PieceColorModify.colors[0];
                }
                else
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                }
            }
            else
            {
                if (eventData.pointerDrag.GetComponent<SelectCoins>() == P1coin)
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + new Vector2(-60.0f, 20.0f);
                    eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.sprite = piece;
                    eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.color = PieceColorModify.colors[0];
                }
                else if (eventData.pointerDrag.GetComponent<SelectCoins>() == P2coin)
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + new Vector2(-25.0f, 20.0f);
                    eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.sprite = piece;
                    eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.color = PieceColorModify.colors[0];
                }
                else if (eventData.pointerDrag.GetComponent<SelectCoins>() == P3coin)
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + new Vector2(25.0f, 20.0f);
                    eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.sprite = piece;
                    eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.color = PieceColorModify.colors[0];
                }
                else if (eventData.pointerDrag.GetComponent<SelectCoins>() == P4coin)
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + new Vector2(60.0f, 20.0f);
                    eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.sprite = piece;
                    eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.color = PieceColorModify.colors[0];
                }
                else
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                }
            }

            

            eventData.pointerDrag.GetComponent<SelectCoins>().isDrop = true;
        }
    }
}

