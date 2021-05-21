using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceSelected : MonoBehaviour
{
    [SerializeField] private SelectCoins tokenPlayer;
    [SerializeField] private Sprite piece;

    private SpriteRenderer curSprite;

    public void Start()
    {
        curSprite = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (tokenPlayer.isDrop)
        {
            curSprite.sprite = piece;
        }
    }

}
