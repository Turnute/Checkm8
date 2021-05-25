using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author : Samuel Goubeau
 * 
 * Manage : Change the color of sprite when the player click on buttons
 * 
 * Using : Canvas.Canvas-P1.ColInc, Canvas.Canvas-P1.ColDec, Canvas.Canvas-P2.ColInc, Canvas.Canvas-P2.ColDec
 */
public class PieceColorModify : MonoBehaviour
{
    private int colorChoose;

    // [White, Black, Red, Green, Blue]
    private static Color[] colors = { new Color(255, 255, 255), new Color(0, 0, 0), new Color(255, 0, 0), new Color(0, 255, 0), new Color(0, 0, 255) };

    void Start()
    {
        colorChoose = 0;
    }

    public void IncColor(SpriteRenderer piece)
    {
        if(piece != null)
        {
            colorChoose++;
            if (colorChoose >= colors.Length)
            {
                colorChoose = 0;
            }
            piece.color = colors[colorChoose];
        }
    }

    public void DecColor(SpriteRenderer piece)
    {
        if(piece != null)
        {
            colorChoose--;
            if (colorChoose < 0)
            {
                colorChoose = colors.Length - 1;
            }
            piece.color = colors[colorChoose];
        }
    }
}
