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
public class CharacterSlot2Players : MonoBehaviour, IDropHandler
{
    [SerializeField] private SelectCoins P1coin;
    [SerializeField] private SelectCoins P2coin;

    [SerializeField] private Sprite piece;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<SelectCoins>() == P1coin)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + new Vector2(-30.0f, 20.0f);
                eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.sprite = piece;
            }
            else if (eventData.pointerDrag.GetComponent<SelectCoins>() == P2coin)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + new Vector2(30.0f, 20.0f);
                eventData.pointerDrag.GetComponent<SelectCoins>().pieceSelected.sprite = piece;
            }
            else
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            }

            eventData.pointerDrag.GetComponent<SelectCoins>().isDrop = true;
        }
    }
}

