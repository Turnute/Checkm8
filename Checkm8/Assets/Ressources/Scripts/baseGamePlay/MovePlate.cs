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


            Destroy(piece);//A FAIRE -> AJOUTER UNE ANIMATION DE DESTRUCTION
        }

        controller.GetComponent<Controller>().SetPositionEmpty(pieceCicked.GetComponent<Chessman>().xBoard, pieceCicked.GetComponent<Chessman>().yBoard);

        pieceCicked.GetComponent<Chessman>().xBoard = matrixX;
        pieceCicked.GetComponent<Chessman>().yBoard = matrixY;
        pieceCicked.GetComponent<Chessman>().setCoords(true);
        pieceCicked.GetComponent<Chessman>().selected = false;
        pieceCicked.GetComponent<Chessman>().hasMoved = true;
        pieceCicked.GetComponent<Chessman>().callPromote(pieceCicked.GetComponent<Chessman>().player);
        pieceCicked.GetComponent<SpriteRenderer>().color = pieceCicked.GetComponent<Chessman>().pieceColor;

        controller.GetComponent<Controller>().SetPosition(pieceCicked);

        controller.GetComponent<Controller>().NextTurn();

        pieceCicked.GetComponent<Chessman>().DestroyMovePlates();
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
