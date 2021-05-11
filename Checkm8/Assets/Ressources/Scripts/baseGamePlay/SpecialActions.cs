using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialActions : MonoBehaviour
{
    public GameObject controller;
    private bool rookFind = false;//True lorsque l'on a récupéré la première tour 
    public GameObject roqueImpossible;//Message qui s'affiche lorsqu'on ne peut pas faire de Roque
    private float displayTimer = 2.5f;

    public void Roque()
    {
        if(controller.GetComponent<Controller>().currentPlayer == "p1")
        {
            GameObject rook = null;
            GameObject king = null;
            //On va chercher la tour et le roi du bon joueur
            for(int i=0; i<controller.GetComponent<Controller>().player1.Length;i++)
            {
                if(controller.GetComponent<Controller>().player1[i])
                {
                    if(controller.GetComponent<Controller>().player1[i].name == "rook_p1")
                        rookFind = true;

                    if(controller.GetComponent<Controller>().player1[i].name == "rook_p1" && rookFind)  
                        rook = controller.GetComponent<Controller>().player1[i];
                    
                    if(controller.GetComponent<Controller>().player1[i].name == "king_p1")
                        king = controller.GetComponent<Controller>().player1[i];
                }
            }
            rookFind = false;
            //On vérifie que le roque est possible
            if(!(rook.GetComponent<Chessman>().hasMoved) && !(king.GetComponent<Chessman>().hasMoved) && 
                controller.GetComponent<Controller>().GetPosition(5,0) == null && controller.GetComponent<Controller>().GetPosition(6,0) == null)
            {
                //On effectue le roque
                king.GetComponent<Chessman>().xBoard = 6;
                king.GetComponent<Chessman>().hasMoved = true;
                rook.GetComponent<Chessman>().xBoard = 5;
                rook.GetComponent<Chessman>().hasMoved = true;
                controller.GetComponent<Controller>().SetPosition(king);
                king.GetComponent<Chessman>().setCoords(false);
                controller.GetComponent<Controller>().SetPosition(rook);
                rook.GetComponent<Chessman>().setCoords(true);
                controller.GetComponent<Controller>().SetPositionEmpty(4,0);
                controller.GetComponent<Controller>().SetPositionEmpty(7,0);
                controller.GetComponent<Controller>().NextTurn();
            }else{
                printWarningMessage();
            }
        }else{
            GameObject rook = null;
            GameObject king = null;
            //On va chercher la tour et le roi du bon joueur
            for(int i=0; i<controller.GetComponent<Controller>().player2.Length;i++)
            {
                if(controller.GetComponent<Controller>().player2[i])
                {
                    if(controller.GetComponent<Controller>().player2[i].name == "rook_p2")
                        rookFind = true;

                    if(controller.GetComponent<Controller>().player2[i].name == "rook_p2" && rookFind)  
                        rook = controller.GetComponent<Controller>().player2[i];
                    
                    if(controller.GetComponent<Controller>().player2[i].name == "king_p2")
                        king = controller.GetComponent<Controller>().player2[i];
                }
            }
            rookFind = false;
            //On vérifie que le roque est possible
            if(!(rook.GetComponent<Chessman>().hasMoved) && !(king.GetComponent<Chessman>().hasMoved) && 
                controller.GetComponent<Controller>().GetPosition(5,7) == null && controller.GetComponent<Controller>().GetPosition(6,7) == null)
            {
                //On effectue le roque
                king.GetComponent<Chessman>().xBoard = 6;
                king.GetComponent<Chessman>().hasMoved = true;
                rook.GetComponent<Chessman>().xBoard = 5;
                rook.GetComponent<Chessman>().hasMoved = true;
                controller.GetComponent<Controller>().SetPosition(king);
                king.GetComponent<Chessman>().setCoords(false);
                controller.GetComponent<Controller>().SetPosition(rook);
                rook.GetComponent<Chessman>().setCoords(true);
                controller.GetComponent<Controller>().SetPositionEmpty(4,7);
                controller.GetComponent<Controller>().SetPositionEmpty(7,7);
                controller.GetComponent<Controller>().NextTurn();
            }else{
                printWarningMessage();
            }
        }
    }

    public void GrandRoque()
    {
        if(controller.GetComponent<Controller>().currentPlayer == "p1")
        {
            GameObject rook = null;
            GameObject king = null;
            //On va chercher la tour et le roi du bon joueur
            for(int i=0; i<controller.GetComponent<Controller>().player1.Length;i++)
            {
                if(controller.GetComponent<Controller>().player1[i])
                {
                    if(controller.GetComponent<Controller>().player1[i].name == "rook_p1" && !rookFind)
                    {
                        rook = controller.GetComponent<Controller>().player1[i];
                        rookFind = true;
                    }
                    
                    if(controller.GetComponent<Controller>().player1[i].name == "king_p1")
                        king = controller.GetComponent<Controller>().player1[i];
                }
            }
            rookFind = false;
            //On vérifie que le roque est possible
            if(!(rook.GetComponent<Chessman>().hasMoved) && !(king.GetComponent<Chessman>().hasMoved) && 
                controller.GetComponent<Controller>().GetPosition(1,0) == null && controller.GetComponent<Controller>().GetPosition(2,0) == null && controller.GetComponent<Controller>().GetPosition(3,0) == null)
            {
                //On effectue le roque
                king.GetComponent<Chessman>().xBoard = 2;
                king.GetComponent<Chessman>().hasMoved = true;
                rook.GetComponent<Chessman>().xBoard = 3;
                rook.GetComponent<Chessman>().hasMoved = true;
                controller.GetComponent<Controller>().SetPosition(king);
                king.GetComponent<Chessman>().setCoords(false);
                controller.GetComponent<Controller>().SetPosition(rook);
                rook.GetComponent<Chessman>().setCoords(true);
                controller.GetComponent<Controller>().SetPositionEmpty(4,0);
                controller.GetComponent<Controller>().SetPositionEmpty(0,0);
                controller.GetComponent<Controller>().NextTurn();
            }else{
                printWarningMessage();
            }
        }else{
            GameObject rook = null;
            GameObject king = null;
            //On va chercher la tour et le roi du bon joueur
            for(int i=0; i<controller.GetComponent<Controller>().player2.Length;i++)
            {
                if(controller.GetComponent<Controller>().player2[i])
                {
                    if(controller.GetComponent<Controller>().player2[i].name == "rook_p2" && !rookFind)
                    {
                        rook = controller.GetComponent<Controller>().player2[i];
                        rookFind = true;
                    }
                    
                    if(controller.GetComponent<Controller>().player2[i].name == "king_p2")
                        king = controller.GetComponent<Controller>().player2[i];
                }
            }
            rookFind = false;
            //On vérifie que le roque est possible
            if(!(rook.GetComponent<Chessman>().hasMoved) && !(king.GetComponent<Chessman>().hasMoved) && 
                controller.GetComponent<Controller>().GetPosition(1,7) == null && controller.GetComponent<Controller>().GetPosition(2,7) == null && controller.GetComponent<Controller>().GetPosition(3,7) == null)
            {
                //On effectue le roque
                king.GetComponent<Chessman>().xBoard = 2;
                king.GetComponent<Chessman>().hasMoved = true;
                rook.GetComponent<Chessman>().xBoard = 3;
                rook.GetComponent<Chessman>().hasMoved = true;
                controller.GetComponent<Controller>().SetPosition(king);
                king.GetComponent<Chessman>().setCoords(false);
                controller.GetComponent<Controller>().SetPosition(rook);
                rook.GetComponent<Chessman>().setCoords(true);
                controller.GetComponent<Controller>().SetPositionEmpty(4,7);
                controller.GetComponent<Controller>().SetPositionEmpty(0,7);
                controller.GetComponent<Controller>().NextTurn();
            }else{
                printWarningMessage();
            }
        }
    }

    private void printWarningMessage()
    {
        roqueImpossible.SetActive(true);
        displayTimer-= Time.deltaTime;
    }

    void Update()
    {
        if(displayTimer < 2.5f)
        {
            displayTimer -= Time.deltaTime;
        }
        if(displayTimer <= 0)
        {
            roqueImpossible.SetActive(false);
            displayTimer = 2.5f;
        }
    }
}
