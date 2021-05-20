using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSlot2Players : MonoBehaviour, IDropHandler
{
    [SerializeField] private SelectCoins P1coin;
    [SerializeField] private SelectCoins P2coin;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<SelectCoins>() == P1coin)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + new Vector2(-30.0f, 20.0f);
            }
            else if (eventData.pointerDrag.GetComponent<SelectCoins>() == P2coin)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + new Vector2(30.0f, 20.0f);
            }
            else
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            }

            eventData.pointerDrag.GetComponent<SelectCoins>().isDrop = true;
        }
    }
}

