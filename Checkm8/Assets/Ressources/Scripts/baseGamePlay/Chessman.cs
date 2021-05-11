using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;//Partie en surbrillance permettant de déplacer nos pièces
    public GameObject beginnerHelp;
    public GameObject moveSFX;

    //Position du board
    public int xBoard = -1;
    public int yBoard = -1;

    //Quel joueur joue
    public string player;

    //Tous les sprites possibles(Rajouter les différents sets)
    public Sprite queen, king, bishop, knight, rook, pawn;

    //True dès lors qu'une pièce bouge
    public bool hasMoved = false;

    public bool selected;//true quand on a cliqué sur la pièce

    public Color pieceColor;

    public void Activate()
    {
        controller = GameObject.FindWithTag("GameController");

        //Pour placer chaque pièce à la bonne place
        setCoords(false);

        //On donne le bon sprite à chaque pièce (et la bonne couleur -> A faire plus tard)
        switch(this.name)
        {
            case "queen_p1":
                this.GetComponent<SpriteRenderer>().sprite = queen;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                pieceColor = Color.white;
                player = "p1";
                break;
            case "king_p1":
                this.GetComponent<SpriteRenderer>().sprite = king;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                pieceColor = Color.white;
                player = "p1";
                break;
            case "bishop_p1":
                this.GetComponent<SpriteRenderer>().sprite = bishop;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                pieceColor = Color.white;
                player = "p1";
                break;
            case "knight_p1":
                this.GetComponent<SpriteRenderer>().sprite = knight;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                pieceColor = Color.white;
                player = "p1";
                break;
            case "rook_p1":
                this.GetComponent<SpriteRenderer>().sprite = rook;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                pieceColor = Color.white;
                player = "p1";
                break;
            case "pawn_p1":
                this.GetComponent<SpriteRenderer>().sprite = pawn;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                pieceColor = Color.white;
                player = "p1";
                break;

            case "queen_p2":
                this.GetComponent<SpriteRenderer>().sprite = queen;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                pieceColor = Color.black;
                player = "p2";
                break;
            case "king_p2":
                this.GetComponent<SpriteRenderer>().sprite = king;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                pieceColor = Color.black;
                player = "p2";
                break;
            case "bishop_p2":
                this.GetComponent<SpriteRenderer>().sprite = bishop;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                pieceColor = Color.black;
                player = "p2";
                break;
            case "knight_p2":
                this.GetComponent<SpriteRenderer>().sprite = knight;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                pieceColor = Color.black;
                player = "p2";
                break;
            case "rook_p2":
                this.GetComponent<SpriteRenderer>().sprite = rook;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                pieceColor = Color.black;
                player = "p2";
                break;
            case "pawn_p2":
                this.GetComponent<SpriteRenderer>().sprite = pawn;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                pieceColor = Color.black;
                player = "p2";
                break;
        }
    }

    public void setCoords(bool shouldPlay)
    {
        float x = xBoard;
        float y = yBoard;

        //Valeurs à tester (valeures temporaires)
        x *= 0.125f;
        y *= 0.125f;

        x += -0.435f;
        y += -0.413f;

        this.transform.position = new Vector3(x,y,0);

        if(shouldPlay)
        moveSFX.GetComponent<AudioSource>().Play(0);
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");

        for(int i=0; i< movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void DestroyBeginnerHelp()
    {
        GameObject[] bhelps = GameObject.FindGameObjectsWithTag("MovePlateBeginner");

        for(int i=0; i< bhelps.Length; i++)
        {
            Destroy(bhelps[i]);
        }
    }

    public void InitiateMovePlates()
    {
        if(!controller.GetComponent<Controller>().promotingPanelUp)
        {
           //On créé des paternes de surbrillance différents en fonction de la pièce active
        switch(this.name)
        {
            case "queen_p1":
            case "queen_p2":
                LineMovePlate(1,0);
                LineMovePlate(0,1);
                LineMovePlate(1,1);
                LineMovePlate(-1,0);
                LineMovePlate(-1,1);
                LineMovePlate(1,-1);
                LineMovePlate(0,-1);
                LineMovePlate(-1,-1);
                break;
            case "knight_p1" :
            case "knight_p2" :
                LMovePlate();
                break;
            case "bishop_p1":
            case "bishop_p2":
                LineMovePlate(1,1);
                LineMovePlate(1,-1);
                LineMovePlate(-1,1);
                LineMovePlate(-1,-1);
                break;
            case "king_p1":
            case "king_p2":
                SurroundMovePlate();
                break;
            case "rook_p1":
            case "rook_p2":
                LineMovePlate(1,0);
                LineMovePlate(0,1);
                LineMovePlate(-1,0);
                LineMovePlate(0,-1);
                break;
            case "pawn_p2":
                if(!hasMoved)
                {
                    PawnMovePlateFirstTurn(xBoard,yBoard-1,-1);
                }else{
                    PawnMovePlate(xBoard, yBoard - 1);
                }
                break;
            case "pawn_p1":
                if(!hasMoved)
                {
                    PawnMovePlateFirstTurn(xBoard, yBoard + 1,1);
                }else{
                    PawnMovePlate(xBoard, yBoard + 1);
                }
                break;
        } 
        }
    }

    void InitiateBeginnerHelp()
    {
        if(!controller.GetComponent<Controller>().promotingPanelUp)
        {
        //On créé des paternes de surbrillance différents en fonction de la pièce active
        switch(this.name)
        {
            case "queen_p1":
            case "queen_p2":
                LineBegHelp(1,0);
                LineBegHelp(0,1);
                LineBegHelp(1,1);
                LineBegHelp(-1,0);
                LineBegHelp(-1,1);
                LineBegHelp(1,-1);
                LineBegHelp(0,-1);
                LineBegHelp(-1,-1);
                break;
            case "knight_p1" :
            case "knight_p2" :
                LBegHelp();
                break;
            case "bishop_p1":
            case "bishop_p2":
                LineBegHelp(1,1);
                LineBegHelp(1,-1);
                LineBegHelp(-1,1);
                LineBegHelp(-1,-1);
                break;
            case "king_p1":
            case "king_p2":
                SurroundBegHelp();
                break;
            case "rook_p1":
            case "rook_p2":
                LineBegHelp(1,0);
                LineBegHelp(0,1);
                LineBegHelp(-1,0);
                LineBegHelp(0,-1);
                break;
            case "pawn_p2":
                if(!hasMoved)
                {
                    PawnBegHelpFirstTurn(xBoard,yBoard-1,-1);
                }else{
                    PawnBegHelp(xBoard, yBoard - 1);
                }
                break;
            case "pawn_p1":
                if(!hasMoved)
                {
                    PawnBegHelpFirstTurn(xBoard, yBoard + 1,1);
                }else{
                    PawnBegHelp(xBoard, yBoard + 1);
                }
                break;
        }
        }
    }

    public void LineMovePlate(int xIncrement, int yIncrement)
    {
        Controller cont = controller.GetComponent<Controller>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        while(cont.PositionOnBoard(x,y) && cont.GetPosition(x,y) == null)
        {
            MovePlateSpawn(x,y);
            x += xIncrement;
            y += yIncrement;
        }

        if(cont.PositionOnBoard(x,y) && cont.GetPosition(x,y).GetComponent<Chessman>().player != player)
        {
            MovePlateAttackSpawn(x,y);
        }
    }

    public void LineBegHelp(int xIncrement, int yIncrement)
    {
        Controller cont = controller.GetComponent<Controller>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        while(cont.PositionOnBoard(x,y) && cont.GetPosition(x,y) == null)
        {
            BegHelpSpawn(x,y);
            x += xIncrement;
            y += yIncrement;
        }

        if(cont.PositionOnBoard(x,y) && cont.GetPosition(x,y).GetComponent<Chessman>().player != player)
        {
            BegHelpAttackSpawn(x,y);
        }
    }

    public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard -2, yBoard -1);
        PointMovePlate(xBoard -2, yBoard + 1);
    }

    public void LBegHelp()
    {
        PointBegHelp(xBoard + 1, yBoard + 2);
        PointBegHelp(xBoard - 1, yBoard + 2);
        PointBegHelp(xBoard + 2, yBoard + 1);
        PointBegHelp(xBoard + 2, yBoard - 1);
        PointBegHelp(xBoard + 1, yBoard - 2);
        PointBegHelp(xBoard - 1, yBoard - 2);
        PointBegHelp(xBoard -2, yBoard -1);
        PointBegHelp(xBoard -2, yBoard + 1);
    }

    public void SurroundMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard);
        PointMovePlate(xBoard -1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard +1);
        PointMovePlate(xBoard + 1, yBoard + 1);
        PointMovePlate(xBoard -1, yBoard);
        PointMovePlate(xBoard + 1, yBoard -1);
    }

    public void SurroundBegHelp()
    {
        PointBegHelp(xBoard, yBoard + 1);
        PointBegHelp(xBoard, yBoard - 1);
        PointBegHelp(xBoard + 1, yBoard);
        PointBegHelp(xBoard -1, yBoard - 1);
        PointBegHelp(xBoard - 1, yBoard +1);
        PointBegHelp(xBoard + 1, yBoard + 1);
        PointBegHelp(xBoard -1, yBoard);
        PointBegHelp(xBoard + 1, yBoard -1);
    }

    public void PointMovePlate(int x, int y)
    {
        Controller cont = controller.GetComponent<Controller>();

        if(cont.PositionOnBoard(x,y))
        {
            GameObject piece = cont.GetPosition(x,y);

            if(piece == null)
            {
                MovePlateSpawn(x,y);
            }else if(cont.GetPosition(x,y).GetComponent<Chessman>().player != player)
                {
                    MovePlateAttackSpawn(x,y);
                }
        }
    }

    public void PointBegHelp(int x, int y)
    {
        Controller cont = controller.GetComponent<Controller>();

        if(cont.PositionOnBoard(x,y))
        {
            GameObject piece = cont.GetPosition(x,y);

            if(piece == null)
            {
                BegHelpSpawn(x,y);
            }else if(cont.GetPosition(x,y).GetComponent<Chessman>().player != player)
                {
                    BegHelpAttackSpawn(x,y);
                }
        }
    }

    public void PawnMovePlate(int x, int y)
    {
        Controller cont = controller.GetComponent<Controller>();

        if(cont.PositionOnBoard(x,y))
        {
            if(cont.GetPosition(x,y) == null)
            {
                MovePlateSpawn(x,y);
            }

            if(cont.PositionOnBoard(x+1,y) && cont.GetPosition(x+1,y) != null && cont.GetPosition(x+1,y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x+1,y);
            }

            if(cont.PositionOnBoard(x-1,y) && cont.GetPosition(x-1,y) != null && cont.GetPosition(x-1,y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x-1,y);
            }
        }

    }

    public void PawnBegHelp(int x, int y)
    {
        Controller cont = controller.GetComponent<Controller>();

        if(cont.PositionOnBoard(x,y))
        {
            if(cont.GetPosition(x,y) == null)
            {
                BegHelpSpawn(x,y);
            }

            if(cont.PositionOnBoard(x+1,y) && cont.GetPosition(x+1,y) != null && cont.GetPosition(x+1,y).GetComponent<Chessman>().player != player)
            {
                BegHelpAttackSpawn(x+1,y);
            }

            if(cont.PositionOnBoard(x-1,y) && cont.GetPosition(x-1,y) != null && cont.GetPosition(x-1,y).GetComponent<Chessman>().player != player)
            {
                BegHelpAttackSpawn(x-1,y);
            }
        }

    }

    public void PawnMovePlateFirstTurn(int x, int y,int which_player)
    {
        Controller cont = controller.GetComponent<Controller>();

        if(cont.PositionOnBoard(x,y))
        {
            if(cont.GetPosition(x,y) == null)
            {
                MovePlateSpawn(x,y);
            }
            if(cont.GetPosition(x,y+which_player) == null && cont.GetPosition(x,y) == null)
            {
                MovePlateSpawn(x,y+which_player);
            }

            if(cont.PositionOnBoard(x+1,y) && cont.GetPosition(x+1,y) != null && cont.GetPosition(x+1,y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x+1,y);
            }

            if(cont.PositionOnBoard(x-1,y) && cont.GetPosition(x-1,y) != null && cont.GetPosition(x-1,y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x-1,y);
            }
        }
    }

    public void PawnBegHelpFirstTurn(int x, int y,int which_player)
    {
        Controller cont = controller.GetComponent<Controller>();

        if(cont.PositionOnBoard(x,y))
        {
            if(cont.GetPosition(x,y) == null)
            {
                BegHelpSpawn(x,y);
            }
            if(cont.GetPosition(x,y+which_player) == null && cont.GetPosition(x,y) == null)
            {
                BegHelpSpawn(x,y+which_player);
            }

            if(cont.PositionOnBoard(x+1,y) && cont.GetPosition(x+1,y) != null && cont.GetPosition(x+1,y).GetComponent<Chessman>().player != player)
            {
                BegHelpAttackSpawn(x+1,y);
            }

            if(cont.PositionOnBoard(x-1,y) && cont.GetPosition(x-1,y) != null && cont.GetPosition(x-1,y).GetComponent<Chessman>().player != player)
            {
                BegHelpAttackSpawn(x-1,y);
            }
        }
    }

    public void MovePlateSpawn(int posX, int posY)
    {
        float x = posX;
        float y = posY;

        x *= 0.125f;
        y *= 0.125f;

        x += -0.438f;
        y += -0.438f;

        GameObject mp = Instantiate(movePlate, new Vector3(x,y,0), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();

        mpScript.setPieceClicked(gameObject);
        mpScript.SetCoords(posX,posY);
    }

    public void BegHelpSpawn(int posX, int posY)
    {
        float x = posX;
        float y = posY;

        x *= 0.125f;
        y *= 0.125f;

        x += -0.438f;
        y += -0.438f;

        GameObject mp = Instantiate(beginnerHelp, new Vector3(x,y,0), Quaternion.identity);
    }

    public void MovePlateAttackSpawn(int posX, int posY)
    {
        float x = posX;
        float y = posY;

        x *= 0.125f;
        y *= 0.125f;

        x += -0.438f;
        y += -0.438f;

        GameObject mp = Instantiate(movePlate, new Vector3(x,y,0), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();

        mpScript.isAttacking = true;
        mpScript.setPieceClicked(gameObject);
        mpScript.SetCoords(posX,posY);
    }

    public void BegHelpAttackSpawn(int posX, int posY)
    {
        float x = posX;
        float y = posY;

        x *= 0.125f;
        y *= 0.125f;

        x += -0.438f;
        y += -0.438f;

        GameObject mp = Instantiate(beginnerHelp, new Vector3(x,y,0), Quaternion.identity);

        mp.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        if(!controller.GetComponent<Controller>().isGameOver() && controller.GetComponent<Controller>().GetCurrentPlayer() == player)
        {
            //On enlève la surbrillance de toutes les pièces
            if(player == "p1")
            {
                for(int i=0; i<controller.GetComponent<Controller>().player1.Length;i++)
                {
                    if(controller.GetComponent<Controller>().player1[i])
                        controller.GetComponent<Controller>().player1[i].GetComponent<SpriteRenderer>().color = pieceColor;
                }
            }else{
                for(int i=0; i<controller.GetComponent<Controller>().player2.Length;i++)
                {
                    if(controller.GetComponent<Controller>().player2[i])
                        controller.GetComponent<Controller>().player2[i].GetComponent<SpriteRenderer>().color = pieceColor;
                }
            }
            selected = true;

            DestroyBeginnerHelp();
            
            DestroyMovePlates();

            InitiateMovePlates();

            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }


    //Actions spéciales
    public void callPromote(string which_player)
    {
        if(which_player == "p1")
        {
            if(yBoard == 7 && this.name == "pawn_p1")
            {
                //On ouvre le panneau de promotion
                controller.GetComponent<Controller>().promotePanel.SetActive(true);
                controller.GetComponent<Controller>().promotingPanelUp = true;
                controller.GetComponent<Controller>().pieceToPromote = gameObject;
            }
        }else{
            if(yBoard == 0 && this.name == "pawn_p2")
            {
                //On ouvre le panneau de promotion
                controller.GetComponent<Controller>().promotePanel.SetActive(true);
                controller.GetComponent<Controller>().promotingPanelUp = true;
                controller.GetComponent<Controller>().pieceToPromote = gameObject;
            }
        }
    }

    void OnMouseOver()
    {
        if(!selected)
        InitiateBeginnerHelp();
    }


    private void OnMouseExit()
    {
        if(!selected)
        DestroyBeginnerHelp();
    }
}
