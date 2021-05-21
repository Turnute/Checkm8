using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;
    GameObject pieceCicked = null;//La pièce sur laquelle on a cliqué pour faire apparaître la surbrillance actuelle

    //Position du board
    int matrixX;
    int matrixY;

    public bool isAttacking = false;


    void Start()
    {
        if(isAttacking)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;//On indique qu'on peut manger une pièce
        }
    }

    void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if(isAttacking)
        {
            GameObject piece = controller.GetComponent<Controller>().GetPosition(matrixX,matrixY);

            if(piece.name == "king_p1")
                controller.GetComponent<Controller>().Winner("p2");

            if(piece.name == "king_p2")
                controller.GetComponent<Controller>().Winner("p1");

            SpecialActions.pieceEaten = piece.name;
            if(controller.GetComponent<Controller>().currentPlayer == "p1")
            {
                SpecialActions.pieceEatenIndex = System.Array.IndexOf(controller.GetComponent<Controller>().player2,piece);
            }else{
                SpecialActions.pieceEatenIndex = System.Array.IndexOf(controller.GetComponent<Controller>().player1,piece);
            }
            
            SpecialActions.pieceHasBeenEaten = true;
            SpecialActions.pieceEatenPos = new Vector2(piece.GetComponent<Chessman>().xBoard, piece.GetComponent<Chessman>().yBoard);
            SpecialActions.nbMovePieceEaten = piece.GetComponent<Chessman>().hasMoved;
            Destroy(piece);//A FAIRE -> AJOUTER UNE ANIMATION DE DESTRUCTION
        }else{
            SpecialActions.pieceHasBeenEaten = false;
        }
        SpecialActions.lastPiece = pieceCicked;
        SpecialActions.lastPos = new Vector2(pieceCicked.GetComponent<Chessman>().xBoard, pieceCicked.GetComponent<Chessman>().yBoard);

        controller.GetComponent<Controller>().SetPositionEmpty(pieceCicked.GetComponent<Chessman>().xBoard, pieceCicked.GetComponent<Chessman>().yBoard);

        pieceCicked.GetComponent<Chessman>().xBoard = matrixX;
        pieceCicked.GetComponent<Chessman>().yBoard = matrixY;
        pieceCicked.GetComponent<Chessman>().setCoords(true);
        pieceCicked.GetComponent<Chessman>().selected = false;
        pieceCicked.GetComponent<Chessman>().hasMoved ++;
        pieceCicked.GetComponent<Chessman>().callPromote(pieceCicked.GetComponent<Chessman>().player);
        pieceCicked.GetComponent<SpriteRenderer>().color = pieceCicked.GetComponent<Chessman>().pieceColor;

        controller.GetComponent<Controller>().SetPosition(pieceCicked);

        controller.GetComponent<CheckMateManager>().movesPossible.Clear();

        controller.GetComponent<CheckMateManager>().PredictAllMoves(controller.GetComponent<Controller>().currentPlayer);

        controller.GetComponent<CheckMateManager>().check = false;

        controller.GetComponent<Controller>().NextTurn();

        pieceCicked.GetComponent<Chessman>().DestroyMovePlates();

        SpecialActions.cancelButton.SetActive(true);
    }

    public void SetCoords(int posX, int posY)
    {
        matrixX = posX;
        matrixY = posY;
    }

    public void setPieceClicked(GameObject obj)
    {
        pieceCicked = obj;
    }

    public GameObject getPieceClicked()
    {
        return pieceCicked;
    }
}
