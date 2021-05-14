using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMateManager : MonoBehaviour
{
    public GameObject controller;
    public static bool playerInstantiated = false;
    public bool check = false;

    //Les rois des deux joueurs
    private GameObject kingp1;
    private GameObject kingp2;

    //Liste des déplacements possibles de l'adversaire
    public List<Vector2> movesPossible = new List<Vector2>();

    //Fonction a appelé après chaque coup d'un jouer afin de voir si le roi de l'adversaire est en echec
    public void PredictAllMoves(string which_player)
    {
        for(int i=0; i<controller.GetComponent<Controller>().player1.Length;i++)
        {
            if(which_player == "p1")
            {
                if(controller.GetComponent<Controller>().player1[i])
                {
                    ComputeMoves(controller.GetComponent<Controller>().player1[i]);
                }
            }else{
                if(controller.GetComponent<Controller>().player2[i])
                {
                    ComputeMoves(controller.GetComponent<Controller>().player2[i]);
                }
            }
        }
    }

    //Fonction initiant le calcule des déplacement disponible
    public void ComputeMoves(GameObject piece)
    {
        switch(piece.name)
        {
            case "queen_p1":
            case "queen_p2":
                LineCompute(piece,1,0);
                LineCompute(piece,0,1);
                LineCompute(piece,1,1);
                LineCompute(piece,-1,0);
                LineCompute(piece,-1,1);
                LineCompute(piece,1,-1);
                LineCompute(piece,0,-1);
                LineCompute(piece,-1,-1);
                break;
            case "knight_p1" :
            case "knight_p2" :
                LCompute(piece);
                break;
            case "bishop_p1":
            case "bishop_p2":
                LineCompute(piece,1,1);
                LineCompute(piece,1,-1);
                LineCompute(piece,-1,1);
                LineCompute(piece,-1,-1);
                break;
            case "king_p1":
            case "king_p2":
                SurroundCompute(piece);
                break;
            case "rook_p1":
            case "rook_p2":
                LineCompute(piece,1,0);
                LineCompute(piece,0,1);
                LineCompute(piece,-1,0);
                LineCompute(piece,0,-1);
                break;
            case "pawn_p2":
                if(!piece.GetComponent<Chessman>().hasMoved)
                {
                    PawnFirstTurnCompute(piece,piece.GetComponent<Chessman>().xBoard,piece.GetComponent<Chessman>().yBoard-1,-1);
                }else{
                    PawnCompute(piece,piece.GetComponent<Chessman>().xBoard, piece.GetComponent<Chessman>().yBoard - 1);
                }
                break;
            case "pawn_p1":
                if(!piece.GetComponent<Chessman>().hasMoved)
                {
                    PawnFirstTurnCompute(piece,piece.GetComponent<Chessman>().xBoard, piece.GetComponent<Chessman>().yBoard + 1,1);
                }else{
                    PawnCompute(piece,piece.GetComponent<Chessman>().xBoard, piece.GetComponent<Chessman>().yBoard + 1);
                }
                break;
        } 
    }

    //Liste des fonctions individuelles de calcul de déplacements
    private void LineCompute(GameObject piece, int xIncrement, int yIncrement)
    {
        Controller cont = controller.GetComponent<Controller>();

        int x = piece.GetComponent<Chessman>().xBoard + xIncrement;
        int y = piece.GetComponent<Chessman>().yBoard + yIncrement;

        while(cont.PositionOnBoard(x,y) && cont.GetPosition(x,y) == null)
        {
            Vector2 pos = new Vector2(x,y);
            movesPossible.Add(pos);
            x += xIncrement;
            y += yIncrement;
        }

          if(cont.PositionOnBoard(x,y) && cont.GetPosition(x,y).GetComponent<Chessman>().player != piece.GetComponent<Chessman>().player)
        {
            Vector2 pos = new Vector2(x,y);
            movesPossible.Add(pos);
        }
    }

    private void LCompute(GameObject piece)
    {
        PointCompute(piece.GetComponent<Chessman>().xBoard + 1, piece.GetComponent<Chessman>().yBoard + 2);
        PointCompute(piece.GetComponent<Chessman>().xBoard - 1, piece.GetComponent<Chessman>().yBoard + 2);
        PointCompute(piece.GetComponent<Chessman>().xBoard + 2, piece.GetComponent<Chessman>().yBoard + 1);
        PointCompute(piece.GetComponent<Chessman>().xBoard + 2, piece.GetComponent<Chessman>().yBoard - 1);
        PointCompute(piece.GetComponent<Chessman>().xBoard + 1, piece.GetComponent<Chessman>().yBoard - 2);
        PointCompute(piece.GetComponent<Chessman>().xBoard - 1, piece.GetComponent<Chessman>().yBoard - 2);
        PointCompute(piece.GetComponent<Chessman>().xBoard -2, piece.GetComponent<Chessman>().yBoard -1);
        PointCompute(piece.GetComponent<Chessman>().xBoard -2, piece.GetComponent<Chessman>().yBoard + 1);
    }

    private void SurroundCompute(GameObject piece)
    {
        PointCompute(piece.GetComponent<Chessman>().xBoard, piece.GetComponent<Chessman>().yBoard + 1);
        PointCompute(piece.GetComponent<Chessman>().xBoard, piece.GetComponent<Chessman>().yBoard - 1);
        PointCompute(piece.GetComponent<Chessman>().xBoard + 1, piece.GetComponent<Chessman>().yBoard);
        PointCompute(piece.GetComponent<Chessman>().xBoard -1, piece.GetComponent<Chessman>().yBoard - 1);
        PointCompute(piece.GetComponent<Chessman>().xBoard - 1, piece.GetComponent<Chessman>().yBoard +1);
        PointCompute(piece.GetComponent<Chessman>().xBoard + 1, piece.GetComponent<Chessman>().yBoard + 1);
        PointCompute(piece.GetComponent<Chessman>().xBoard -1, piece.GetComponent<Chessman>().yBoard);
        PointCompute(piece.GetComponent<Chessman>().xBoard + 1, piece.GetComponent<Chessman>().yBoard -1);
    }

    private void PawnCompute(GameObject piece, int x, int y)
    {
        Controller cont = controller.GetComponent<Controller>();

        if(cont.PositionOnBoard(x,y))
        {
            if(cont.GetPosition(x,y) == null)
            {
                Vector2 pos = new Vector2(x,y);
                movesPossible.Add(pos); 
            }

            if(cont.PositionOnBoard(x+1,y) && cont.GetPosition(x+1,y) != null && cont.GetPosition(x+1,y).GetComponent<Chessman>().player != piece.GetComponent<Chessman>().player)
            {
                Vector2 pos = new Vector2(x+1,y);
                movesPossible.Add(pos); 
            }

            if(cont.PositionOnBoard(x-1,y) && cont.GetPosition(x-1,y) != null && cont.GetPosition(x-1,y).GetComponent<Chessman>().player != piece.GetComponent<Chessman>().player)
            {
                Vector2 pos = new Vector2(x-1,y);
                movesPossible.Add(pos); 
            }
        }
    }

    private void PawnFirstTurnCompute(GameObject piece, int x, int y, int which_player)
    {
        Controller cont = controller.GetComponent<Controller>();

        if(cont.PositionOnBoard(x,y))
        {
            if(cont.GetPosition(x,y) == null)
            {
                Vector2 pos = new Vector2(x,y);
                movesPossible.Add(pos); 
            }
            if(cont.GetPosition(x,y+which_player) == null && cont.GetPosition(x,y) == null)
            {
                Vector2 pos = new Vector2(x,y+which_player);
                movesPossible.Add(pos); 
            }

            if(cont.PositionOnBoard(x+1,y) && cont.GetPosition(x+1,y) != null && cont.GetPosition(x+1,y).GetComponent<Chessman>().player != piece.GetComponent<Chessman>().player)
            {
                Vector2 pos = new Vector2(x+1,y);
                movesPossible.Add(pos); 
            }

            if(cont.PositionOnBoard(x-1,y) && cont.GetPosition(x-1,y) != null && cont.GetPosition(x-1,y).GetComponent<Chessman>().player != piece.GetComponent<Chessman>().player)
            {
                Vector2 pos = new Vector2(x-1,y);
                movesPossible.Add(pos); 
            }
        }
    }

    private void PointCompute(int x, int y)
    {
        Controller cont = controller.GetComponent<Controller>();

        if(cont.PositionOnBoard(x,y))
        {
            Vector2 pos = new Vector2(x,y);
            movesPossible.Add(pos);
        }
    }

    //Vérifie si le roi est en échec
    public bool isCheck()
    {
        for (int i = 0; i < movesPossible.Count; i++)
        {
            if(controller.GetComponent<Controller>().currentPlayer == "p1")
            {
                float x = kingp1.GetComponent<Chessman>().xBoard;
                float y = kingp1.GetComponent<Chessman>().yBoard;
                Vector2 pos = new Vector2(x,y);
                if(pos == movesPossible[i])
                {
                    check = true;
                }
            }else{
                float x = kingp2.GetComponent<Chessman>().xBoard;
                float y = kingp2.GetComponent<Chessman>().yBoard;
                Vector2 pos = new Vector2(x,y);
                if(pos == movesPossible[i])
                {
                    check = true;
                }
                Debug.Log("Pos" + pos);
                Debug.Log("Move" + movesPossible[i]);
            }
        }
        return false;
    }

    void Update()
    {
        if(playerInstantiated)
        {
        //On récupère les deux rois
        for(int i=0; i<controller.GetComponent<Controller>().player1.Length;i++)
        {
            if(controller.GetComponent<Controller>().player1[i].name == "king_p1")
                kingp1 = controller.GetComponent<Controller>().player1[i];
    
            if(controller.GetComponent<Controller>().player2[i].name == "king_p2")  
                kingp2 = controller.GetComponent<Controller>().player2[i];
        }
        Debug.Log(kingp1.GetComponent<Chessman>().xBoard);
        Debug.Log(kingp1.GetComponent<Chessman>().yBoard);
        playerInstantiated = false;
        }

        if(check)
        {
            //Gestion des éléments liés à cette situation(musique, surbrillance du roi, restriction de mouvement de toutes les pièces(PROCHAINE CHOSE A FAIRE)...)
            if(controller.GetComponent<Controller>().currentPlayer == "p1")
            {
                kingp1.GetComponent<SpriteRenderer>().color = Color.red;
            }else{
                kingp2.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
