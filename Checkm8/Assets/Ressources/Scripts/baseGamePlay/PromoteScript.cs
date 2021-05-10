using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromoteScript : MonoBehaviour
{
    public GameObject controller;

    public void BishopPromotion()
    {
        if(controller.GetComponent<Controller>().pieceToPromote.GetComponent<Chessman>().player == "p1")
        {
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().sprite = controller.GetComponent<Controller>().pieceToPromote.GetComponent<Chessman>().bishop;
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().color = Color.white;
            controller.GetComponent<Controller>().pieceToPromote.name = "bishop_p1";
        }else{
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().sprite = controller.GetComponent<Controller>().pieceToPromote.GetComponent<Chessman>().bishop;
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().color = Color.black;
            controller.GetComponent<Controller>().pieceToPromote.name = "bishop_p2";
        }
        controller.GetComponent<Controller>().promotingPanelUp = false;
        controller.GetComponent<Controller>().promotePanel.SetActive(false);
    }

    public void KnightPromotion()
    {
        if(controller.GetComponent<Controller>().pieceToPromote.GetComponent<Chessman>().player == "p1")
        {
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().sprite = controller.GetComponent<Controller>().pieceToPromote.GetComponent<Chessman>().knight;
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().color = Color.white;
            controller.GetComponent<Controller>().pieceToPromote.name = "knight_p1";
        }else{
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().sprite = controller.GetComponent<Controller>().pieceToPromote.GetComponent<Chessman>().knight;
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().color = Color.black;
            controller.GetComponent<Controller>().pieceToPromote.name = "knight_p2";
        }
        controller.GetComponent<Controller>().promotingPanelUp = false;
        controller.GetComponent<Controller>().promotePanel.SetActive(false);
    }

    public void RookPromotion()
    {
        if(controller.GetComponent<Controller>().pieceToPromote.GetComponent<Chessman>().player == "p1")
        {
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().sprite = controller.GetComponent<Controller>().pieceToPromote.GetComponent<Chessman>().rook;
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().color = Color.white;
            controller.GetComponent<Controller>().pieceToPromote.name = "rook_p1";
        }else{
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().sprite = controller.GetComponent<Controller>().pieceToPromote.GetComponent<Chessman>().rook;
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().color = Color.black;
            controller.GetComponent<Controller>().pieceToPromote.name = "rook_p2";
        }
        controller.GetComponent<Controller>().promotingPanelUp = false;
        controller.GetComponent<Controller>().promotePanel.SetActive(false);
    }

    public void QueenPromotion()
    {
        if(controller.GetComponent<Controller>().pieceToPromote.GetComponent<Chessman>().player == "p1")
        {
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().sprite = controller.GetComponent<Controller>().pieceToPromote.GetComponent<Chessman>().queen;
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().color = Color.white;
            controller.GetComponent<Controller>().pieceToPromote.name = "queen_p1";
        }else{
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().sprite = controller.GetComponent<Controller>().pieceToPromote.GetComponent<Chessman>().queen;
            controller.GetComponent<Controller>().pieceToPromote.GetComponent<SpriteRenderer>().color = Color.black;
            controller.GetComponent<Controller>().pieceToPromote.name = "queen_p2";
        }
        controller.GetComponent<Controller>().promotingPanelUp = false;
        controller.GetComponent<Controller>().promotePanel.SetActive(false);
    }
}
