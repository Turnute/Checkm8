using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialActions : MonoBehaviour
{
    public GameObject controller;
    public static GameObject cancelButton;
    public static GameObject lastPiece;//La dernière pièce déplacée
    public static string pieceEaten = "";//Pièce potentiellement mangée lors du dernier tour
    public static bool pieceHasBeenEaten = false;
    public static int pieceEatenIndex;
    public static Vector2 lastPos;//La postion de la dernière pièce avant son dernier déplacement
    public static Vector2 pieceEatenPos;
    public static int nbMovePieceEaten;
    public static bool grandRoque = false;
    public static string which_player_roqued;
    public static bool petitRoque = false;
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
            if((rook.GetComponent<Chessman>().hasMoved == 0) && (king.GetComponent<Chessman>().hasMoved == 0) && 
                controller.GetComponent<Controller>().GetPosition(5,0) == null && controller.GetComponent<Controller>().GetPosition(6,0) == null)
            {
                //On effectue le roque
                king.GetComponent<Chessman>().xBoard = 6;
                king.GetComponent<Chessman>().hasMoved ++;
                rook.GetComponent<Chessman>().xBoard = 5;
                rook.GetComponent<Chessman>().hasMoved ++;
                controller.GetComponent<Controller>().SetPosition(king);
                king.GetComponent<Chessman>().setCoords(false);
                controller.GetComponent<Controller>().SetPosition(rook);
                rook.GetComponent<Chessman>().setCoords(true);
                controller.GetComponent<Controller>().SetPositionEmpty(4,0);
                controller.GetComponent<Controller>().SetPositionEmpty(7,0);
                controller.GetComponent<CheckMateManager>().movesPossible.Clear();
                controller.GetComponent<CheckMateManager>().PredictAllMoves(controller.GetComponent<Controller>().currentPlayer);
                controller.GetComponent<Controller>().NextTurn();
                petitRoque = true;
                which_player_roqued = "p1";
                cancelButton.SetActive(true);
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
            if((rook.GetComponent<Chessman>().hasMoved == 0) && (king.GetComponent<Chessman>().hasMoved == 0) && 
                controller.GetComponent<Controller>().GetPosition(5,7) == null && controller.GetComponent<Controller>().GetPosition(6,7) == null)
            {
                //On effectue le roque
                king.GetComponent<Chessman>().xBoard = 6;
                king.GetComponent<Chessman>().hasMoved ++;
                rook.GetComponent<Chessman>().xBoard = 5;
                rook.GetComponent<Chessman>().hasMoved ++;
                controller.GetComponent<Controller>().SetPosition(king);
                king.GetComponent<Chessman>().setCoords(false);
                controller.GetComponent<Controller>().SetPosition(rook);
                rook.GetComponent<Chessman>().setCoords(true);
                controller.GetComponent<Controller>().SetPositionEmpty(4,7);
                controller.GetComponent<Controller>().SetPositionEmpty(7,7);
                controller.GetComponent<CheckMateManager>().movesPossible.Clear();
                controller.GetComponent<CheckMateManager>().PredictAllMoves(controller.GetComponent<Controller>().currentPlayer);
                controller.GetComponent<Controller>().NextTurn();
                petitRoque = true;
                which_player_roqued = "p2";
                cancelButton.SetActive(true);
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
            if((rook.GetComponent<Chessman>().hasMoved == 0) && (king.GetComponent<Chessman>().hasMoved == 0) && 
                controller.GetComponent<Controller>().GetPosition(1,0) == null && controller.GetComponent<Controller>().GetPosition(2,0) == null && controller.GetComponent<Controller>().GetPosition(3,0) == null)
            {
                //On effectue le roque
                king.GetComponent<Chessman>().xBoard = 2;
                king.GetComponent<Chessman>().hasMoved ++;
                rook.GetComponent<Chessman>().xBoard = 3;
                rook.GetComponent<Chessman>().hasMoved ++;
                controller.GetComponent<Controller>().SetPosition(king);
                king.GetComponent<Chessman>().setCoords(false);
                controller.GetComponent<Controller>().SetPosition(rook);
                rook.GetComponent<Chessman>().setCoords(true);
                controller.GetComponent<Controller>().SetPositionEmpty(4,0);
                controller.GetComponent<Controller>().SetPositionEmpty(0,0);
                controller.GetComponent<CheckMateManager>().movesPossible.Clear();
                controller.GetComponent<CheckMateManager>().PredictAllMoves(controller.GetComponent<Controller>().currentPlayer);
                controller.GetComponent<Controller>().NextTurn();
                grandRoque = true;
                which_player_roqued = "p1";
                cancelButton.SetActive(true);
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
            if((rook.GetComponent<Chessman>().hasMoved == 0) && (king.GetComponent<Chessman>().hasMoved == 0) && 
                controller.GetComponent<Controller>().GetPosition(1,7) == null && controller.GetComponent<Controller>().GetPosition(2,7) == null && controller.GetComponent<Controller>().GetPosition(3,7) == null)
            {
                //On effectue le roque
                king.GetComponent<Chessman>().xBoard = 2;
                king.GetComponent<Chessman>().hasMoved ++;
                rook.GetComponent<Chessman>().xBoard = 3;
                rook.GetComponent<Chessman>().hasMoved ++;
                controller.GetComponent<Controller>().SetPosition(king);
                king.GetComponent<Chessman>().setCoords(false);
                controller.GetComponent<Controller>().SetPosition(rook);
                rook.GetComponent<Chessman>().setCoords(true);
                controller.GetComponent<Controller>().SetPositionEmpty(4,7);
                controller.GetComponent<Controller>().SetPositionEmpty(0,7);
                controller.GetComponent<CheckMateManager>().movesPossible.Clear();
                controller.GetComponent<CheckMateManager>().PredictAllMoves(controller.GetComponent<Controller>().currentPlayer);
                controller.GetComponent<Controller>().NextTurn();
                grandRoque = true;
                which_player_roqued = "p2";
                cancelButton.SetActive(true);
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

    public void CancelMove()
    {
        //On annule le dernier déplacement(on teste avant quel genre de déplacement cela était)
        if(petitRoque)
        {
            if(controller.GetComponent<Controller>().currentPlayer == "p2")
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
                
                    //On annule le roque
                    king.GetComponent<Chessman>().xBoard = 4;
                    king.GetComponent<Chessman>().hasMoved --;
                    rook.GetComponent<Chessman>().xBoard = 7;
                    rook.GetComponent<Chessman>().hasMoved --;
                    controller.GetComponent<Controller>().SetPosition(king);
                    king.GetComponent<Chessman>().setCoords(false);
                    controller.GetComponent<Controller>().SetPosition(rook);
                    rook.GetComponent<Chessman>().setCoords(true);
                    controller.GetComponent<Controller>().SetPositionEmpty(6,0);
                    controller.GetComponent<Controller>().SetPositionEmpty(5,0);
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
                
                    //On annule le roque
                    king.GetComponent<Chessman>().xBoard = 4;
                    king.GetComponent<Chessman>().hasMoved --;
                    rook.GetComponent<Chessman>().xBoard = 7;
                    rook.GetComponent<Chessman>().hasMoved --;
                    controller.GetComponent<Controller>().SetPosition(king);
                    king.GetComponent<Chessman>().setCoords(false);
                    controller.GetComponent<Controller>().SetPosition(rook);
                    rook.GetComponent<Chessman>().setCoords(true);
                    controller.GetComponent<Controller>().SetPositionEmpty(6,7);
                    controller.GetComponent<Controller>().SetPositionEmpty(5,7);
            }
                
        }else if(grandRoque)
            {
                if(controller.GetComponent<Controller>().currentPlayer == "p2")
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
                
                        //On annule le roque
                        king.GetComponent<Chessman>().xBoard = 4;
                        king.GetComponent<Chessman>().hasMoved --;
                        rook.GetComponent<Chessman>().xBoard = 0;
                        rook.GetComponent<Chessman>().hasMoved --;
                        controller.GetComponent<Controller>().SetPosition(king);
                        king.GetComponent<Chessman>().setCoords(false);
                        controller.GetComponent<Controller>().SetPosition(rook);
                        rook.GetComponent<Chessman>().setCoords(true);
                        controller.GetComponent<Controller>().SetPositionEmpty(2,0);
                        controller.GetComponent<Controller>().SetPositionEmpty(3,0);
                    
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

                        //On annule le roque
                        king.GetComponent<Chessman>().xBoard = 4;
                        king.GetComponent<Chessman>().hasMoved --;
                        rook.GetComponent<Chessman>().xBoard = 0;
                        rook.GetComponent<Chessman>().hasMoved --;
                        controller.GetComponent<Controller>().SetPosition(king);
                        king.GetComponent<Chessman>().setCoords(false);
                        controller.GetComponent<Controller>().SetPosition(rook);
                        rook.GetComponent<Chessman>().setCoords(true);
                        controller.GetComponent<Controller>().SetPositionEmpty(2,7);
                        controller.GetComponent<Controller>().SetPositionEmpty(3,7);
                }

            }else{
                controller.GetComponent<Controller>().SetPositionEmpty(lastPiece.GetComponent<Chessman>().xBoard,lastPiece.GetComponent<Chessman>().yBoard);

                lastPiece.GetComponent<Chessman>().xBoard = (int)lastPos.x;
                lastPiece.GetComponent<Chessman>().yBoard = (int)lastPos.y;
                lastPiece.GetComponent<Chessman>().setCoords(true);
                lastPiece.GetComponent<Chessman>().hasMoved--;
                controller.GetComponent<Controller>().SetPosition(lastPiece);
                controller.GetComponent<CheckMateManager>().movesPossible.Clear();
                controller.GetComponent<CheckMateManager>().PredictAllMoves(controller.GetComponent<Controller>().currentPlayer);
                controller.GetComponent<CheckMateManager>().check = false;
            }

        //Si une pièce a été mangée on la recrée et on la met à sa place ainsi que dans le tableau des pièces du joueurs
        if(pieceHasBeenEaten)
        {
            Debug.Log("eaten");
            switch(pieceEaten)
            {
            case "queen_p1":
                GameObject obj = controller.GetComponent<Controller>().Create("queen_p1",(int)pieceEatenPos.x,(int)pieceEatenPos.y);
                controller.GetComponent<Controller>().SetPosition(obj);
                obj.GetComponent<Chessman>().hasMoved = nbMovePieceEaten;
                controller.GetComponent<Controller>().player1[pieceEatenIndex] = obj;
                pieceEaten = "";
                break;
            case "king_p1":
                GameObject obj1 = controller.GetComponent<Controller>().Create("king_p1",(int)pieceEatenPos.x,(int)pieceEatenPos.y);
                controller.GetComponent<Controller>().SetPosition(obj1);
                obj1.GetComponent<Chessman>().hasMoved = nbMovePieceEaten;
                controller.GetComponent<Controller>().player1[pieceEatenIndex] = obj1;
                pieceEaten = "";
                break;
            case "bishop_p1":
                GameObject obj2 = controller.GetComponent<Controller>().Create("bishop_p1",(int)pieceEatenPos.x,(int)pieceEatenPos.y);
                controller.GetComponent<Controller>().SetPosition(obj2);
                obj2.GetComponent<Chessman>().hasMoved = nbMovePieceEaten;
                controller.GetComponent<Controller>().player1[pieceEatenIndex] = obj2;
                pieceEaten = "";
                break;
            case "knight_p1":
                GameObject obj3 = controller.GetComponent<Controller>().Create("knight_p1",(int)pieceEatenPos.x,(int)pieceEatenPos.y);
                controller.GetComponent<Controller>().SetPosition(obj3);
                obj3.GetComponent<Chessman>().hasMoved = nbMovePieceEaten;
                controller.GetComponent<Controller>().player1[pieceEatenIndex] = obj3;
                pieceEaten = "";
                break;
            case "rook_p1":
                GameObject obj4 = controller.GetComponent<Controller>().Create("rook_p1",(int)pieceEatenPos.x,(int)pieceEatenPos.y);
                controller.GetComponent<Controller>().SetPosition(obj4);
                obj4.GetComponent<Chessman>().hasMoved = nbMovePieceEaten;
                controller.GetComponent<Controller>().player1[pieceEatenIndex] = obj4;
                pieceEaten = "";
                break;
            case "pawn_p1":
                GameObject obj5 = controller.GetComponent<Controller>().Create("pawn_p1",(int)pieceEatenPos.x,(int)pieceEatenPos.y);
                controller.GetComponent<Controller>().SetPosition(obj5);
                obj5.GetComponent<Chessman>().hasMoved = nbMovePieceEaten;
                controller.GetComponent<Controller>().player1[pieceEatenIndex] = obj5;
                pieceEaten = "";
                break;

            case "queen_p2":
                GameObject obj6 = controller.GetComponent<Controller>().Create("queen_p2",(int)pieceEatenPos.x,(int)pieceEatenPos.y);
                controller.GetComponent<Controller>().SetPosition(obj6);
                obj6.GetComponent<Chessman>().hasMoved = nbMovePieceEaten;
                controller.GetComponent<Controller>().player2[pieceEatenIndex] = obj6;
                pieceEaten = "";
                break;
            case "king_p2":
                GameObject obj7 = controller.GetComponent<Controller>().Create("king_p2",(int)pieceEatenPos.x,(int)pieceEatenPos.y);
                controller.GetComponent<Controller>().SetPosition(obj7);
                obj7.GetComponent<Chessman>().hasMoved = nbMovePieceEaten;
                controller.GetComponent<Controller>().player2[pieceEatenIndex] = obj7;
                pieceEaten = "";
                break;
            case "bishop_p2":
                GameObject obj8 = controller.GetComponent<Controller>().Create("bishop_p2",(int)pieceEatenPos.x,(int)pieceEatenPos.y);
                controller.GetComponent<Controller>().SetPosition(obj8);
                obj8.GetComponent<Chessman>().hasMoved = nbMovePieceEaten;
                controller.GetComponent<Controller>().player2[pieceEatenIndex] = obj8;
                pieceEaten = "";
                break;
            case "knight_p2":
                GameObject obj9 = controller.GetComponent<Controller>().Create("knight_p2",(int)pieceEatenPos.x,(int)pieceEatenPos.y);
                controller.GetComponent<Controller>().SetPosition(obj9);
                obj9.GetComponent<Chessman>().hasMoved = nbMovePieceEaten;
                controller.GetComponent<Controller>().player2[pieceEatenIndex] = obj9;
                pieceEaten = "";
                break;
            case "rook_p2":
                GameObject obj10 = controller.GetComponent<Controller>().Create("rook_p2",(int)pieceEatenPos.x,(int)pieceEatenPos.y);
                controller.GetComponent<Controller>().SetPosition(obj10);
                obj10.GetComponent<Chessman>().hasMoved = nbMovePieceEaten;
                controller.GetComponent<Controller>().player2[pieceEatenIndex] = obj10;
                pieceEaten = "";
                break;
            case "pawn_p2":
                GameObject obj11 = controller.GetComponent<Controller>().Create("pawn_p2",(int)pieceEatenPos.x,(int)pieceEatenPos.y);
                controller.GetComponent<Controller>().SetPosition(obj11);
                obj11.GetComponent<Chessman>().hasMoved = nbMovePieceEaten;
                controller.GetComponent<Controller>().player2[pieceEatenIndex] = obj11;
                pieceEaten = "";
                break;
            }
            pieceHasBeenEaten = false;
            pieceEaten = "";
        }

        //On efface les potentielles movePlates créé par l'adversaire
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for(int i=0; i< movePlates.Length;i++)
        {
            Destroy(movePlates[i]);
        }

        //On redonne la main au joueur ayant annulé
        pieceHasBeenEaten = false;
        pieceEaten = "";
        controller.GetComponent<CheckMateManager>().movesPossible.Clear();
        controller.GetComponent<CheckMateManager>().PredictAllMoves(controller.GetComponent<Controller>().currentPlayer);
        controller.GetComponent<Controller>().NextTurn();
        
        //On grise le bouton tant qu'il n'y a pas de nouveau move de fait
        cancelButton.SetActive(false);

    }

    void Start()
    {
        cancelButton = GameObject.FindGameObjectWithTag("cancel");
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
