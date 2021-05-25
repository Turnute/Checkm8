using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteSelection : MonoBehaviour
{
    [SerializeField] private Sprite pion;
    [SerializeField] private Sprite bishop;
    [SerializeField] private Sprite cheval;
    [SerializeField] private Sprite king;
    [SerializeField] private Sprite queen;
    [SerializeField] private Sprite tower;

    private int spriteShown;
    private Sprite[] spritesPiece = new Sprite[6];

    public void Start()
    {
        spriteShown = 0;

        spritesPiece[0] = pion;
        spritesPiece[1] = bishop;
        spritesPiece[2] = cheval;
        spritesPiece[3] = king;
        spritesPiece[4] = queen;
        spritesPiece[5] = tower;
    }

    public void nextSprite(SpriteRenderer piece)
    {
        spriteShown++;

        if(spriteShown >= spritesPiece.Length)
        {
            spriteShown = 0;
        }
        piece.sprite = spritesPiece[spriteShown];
    }

    public void previousSprite(SpriteRenderer piece)
    {
        spriteShown--;

        if (spriteShown < 0)
        {
            spriteShown = spritesPiece.Length - 1;
        }
        piece.sprite = spritesPiece[spriteShown];
    }
}
