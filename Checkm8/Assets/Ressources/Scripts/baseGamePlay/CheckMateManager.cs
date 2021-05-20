using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMateManager : MonoBehaviour
{
    public GameObject controller;
    public static bool playerInstantiated = false;
    public bool check = false;
    public bool stillCheck = false;
    private bool isFoe = false;
    private bool isLastPiece = false;

    //Musiques à jouer sur la scène
    public GameObject inGameTheme, kingInDanger;

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
                if(piece.GetComponent<Chessman>().hasMoved == 0)
                {
                    PawnFirstTurnCompute(piece,piece.GetComponent<Chessman>().xBoard,piece.GetComponent<Chessman>().yBoard-1,-1);
                }else{
                    PawnCompute(piece,piece.GetComponent<Chessman>().xBoard, piece.GetComponent<Chessman>().yBoard - 1);
                }
                break;
            case "pawn_p1":
                if(piece.GetComponent<Chessman>().hasMoved == 0)
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
            if(cont.PositionOnBoard(x,y+which_player) && cont.GetPosition(x,y+which_player) == null && cont.GetPosition(x,y) == null)
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
    public void isCheck()
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
            }
        }
    }

    public bool StillCheck()//Appelé par SimulateMove pour tester si un déplacement annulerai la situation d'échec ou non
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
                    return true;
                }
            }else{
                float x = kingp2.GetComponent<Chessman>().xBoard;
                float y = kingp2.GetComponent<Chessman>().yBoard;
                Vector2 pos = new Vector2(x,y);
                if(pos == movesPossible[i])
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool SimulateMove(GameObject piece, int x, int y)//Simule un déplacement associé à un moveplate et regarde si ce dernier permet de sortir de l'echec
    {
        //Créer un faux pion afin de simuler un coup
        GameObject token = null;
        if(controller.GetComponent<Controller>().PositionOnBoard(x,y))//Prendre la bonne pièce pour le token
        {
            token = controller.GetComponent<Controller>().Create(piece.GetComponent<Chessman>().name, piece.GetComponent<Chessman>().xBoard, piece.GetComponent<Chessman>().yBoard);
        }

        //Positionnement du pion au lieu du moveplate seulement en mémoire pas visuellement(si ennemi on le mange)
        GameObject foe = null;
        string foeType = "";
        int foeIndex = -1;
        if(controller.GetComponent<Controller>().PositionOnBoard(x,y))
        {
            foe = controller.GetComponent<Controller>().GetPosition(x,y);
        }
        
        if(foe != null && foe.GetComponent<Chessman>().player != controller.GetComponent<Controller>().currentPlayer)
        {
            foeType = foe.GetComponent<Chessman>().name;
            if(controller.GetComponent<Controller>().currentPlayer == "p1")
            {
                foeIndex = System.Array.IndexOf(controller.GetComponent<Controller>().player2,foe);
                controller.GetComponent<Controller>().player2[foeIndex] = null;
            }else{
                foeIndex = System.Array.IndexOf(controller.GetComponent<Controller>().player1,foe);
                Debug.Log(foeIndex);
                controller.GetComponent<Controller>().player1[foeIndex] = null;
            }
            isFoe = true;
            if(foe == SpecialActions.lastPiece)
                isLastPiece = true;
            
            controller.GetComponent<Controller>().SetPositionEmpty(x,y);//Simulation de la mort de la pièce ennemi
            Destroy(foe);
        }
        if(controller.GetComponent<Controller>().PositionOnBoard(x,y))//Déplacement du token
        {
            controller.GetComponent<Controller>().SetPositionEmpty(token.GetComponent<Chessman>().xBoard,token.GetComponent<Chessman>().yBoard);
            token.GetComponent<Chessman>().xBoard = x;
            token.GetComponent<Chessman>().yBoard = y;
        }

        controller.GetComponent<Controller>().SetPosition(token);

        //Mise à jour de la liste des moves disponibles
        movesPossible.Clear();
        if(controller.GetComponent<Controller>().currentPlayer == "p1")
        {
            PredictAllMoves("p2");
        }else{
            PredictAllMoves("p1");
        }

        //Appelle de StillCheck(si true on ressort false et inversement)
        if(StillCheck())
        {
            stillCheck =  false;
        }else{
            stillCheck =  true;
        }

        //Annulation des déplacements et remise à zéro de la logique
        Destroy(token);
        if(isFoe)
        {
            GameObject restauredFoe = controller.GetComponent<Controller>().Create(foeType,x,y);
            if(isLastPiece)
                SpecialActions.lastPiece = restauredFoe;
            
            if(controller.GetComponent<Controller>().currentPlayer == "p1")
            {
                controller.GetComponent<Controller>().player2[foeIndex] = restauredFoe;
            }else{
                controller.GetComponent<Controller>().player1[foeIndex] = restauredFoe;
            }
            controller.GetComponent<Controller>().SetPosition(restauredFoe);//On remet l'ennemi dans la logique du jeu
            isFoe = false;
            isLastPiece = false;
        }else{
            if(controller.GetComponent<Controller>().PositionOnBoard(x,y))
                controller.GetComponent<Controller>().SetPositionEmpty(x,y);
        }
        if(controller.GetComponent<Controller>().PositionOnBoard(x,y))//Replacement de la position de notre pièce de base
        {
            controller.GetComponent<Controller>().SetPosition(piece);
        }
        movesPossible.Clear();

        return stillCheck;
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
        playerInstantiated = false;
        }

        if(check)
        {
            if (!kingInDanger.GetComponent<AudioSource>().isPlaying)
            {
                inGameTheme.GetComponent<AudioSource>().Stop();
                kingInDanger.GetComponent<AudioSource>().Play(0);
            }
            //Gestion des éléments liés à cette situation(restriction de mouvement de toutes les pièces(PROCHAINE CHOSE A FAIRE)...)
            if(controller.GetComponent<Controller>().currentPlayer == "p1")
            {
                if(kingp1)
                    kingp1.GetComponent<SpriteRenderer>().color = Color.red;
            }else{
                if(kingp2)
                    kingp2.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }else{
            kingp1.GetComponent<SpriteRenderer>().color = kingp1.GetComponent<Chessman>().pieceColor;
            kingp2.GetComponent<SpriteRenderer>().color = kingp2.GetComponent<Chessman>().pieceColor;
            if (!inGameTheme.GetComponent<AudioSource>().isPlaying)
            {
                inGameTheme.GetComponent<AudioSource>().Play(0);
                kingInDanger.GetComponent<AudioSource>().Stop();
            }
        }
    }
}
