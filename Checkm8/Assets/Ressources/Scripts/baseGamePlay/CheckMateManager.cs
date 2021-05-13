﻿using System.Collections;
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
                    PawnFirstTurnCompute(piece.GetComponent<Chessman>().xBoard,piece.GetComponent<Chessman>().yBoard-1,-1);
                }else{
                    PawnCompute(piece.GetComponent<Chessman>().xBoard, piece.GetComponent<Chessman>().yBoard - 1);
                }
                break;
            case "pawn_p1":
                if(!piece.GetComponent<Chessman>().hasMoved)
                {
                    PawnFirstTurnCompute(piece.GetComponent<Chessman>().xBoard, piece.GetComponent<Chessman>().yBoard + 1,1);
                }else{
                    PawnCompute(piece.GetComponent<Chessman>().xBoard, piece.GetComponent<Chessman>().yBoard + 1);
                }
                break;
        } 
    }

    //Liste des fonctions individuelles de calcul de déplacements
    private void LineCompute(GameObject piece, int x, int y)
    {

    }

    private void LCompute(GameObject piece)
    {

    }

    private void SurroundCompute(GameObject piece)
    {

    }

    private void PawnCompute(int x, int y)
    {

    }

    private void PawnFirstTurnCompute(int x, int y, int which_player)
    {

    }

    //Vérifie si le roi est en échec
    public bool isCheck()
    {
        for (int i = 0; i < movesPossible.Count; i++)
        {
            if(controller.GetComponent<Controller>().currentPlayer == "p1")
            {
                float x = kingp2.GetComponent<Chessman>().xBoard;
                float y = kingp2.GetComponent<Chessman>().yBoard;
                Vector2 pos = new Vector2(x,y);
                if(pos == movesPossible[i])
                {
                    check = true;
                }
            }else{
                float x = kingp1.GetComponent<Chessman>().xBoard;
                float y = kingp1.GetComponent<Chessman>().yBoard;
                Vector2 pos = new Vector2(x,y);
                if(pos == movesPossible[i])
                {
                    check = true;
                }
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
        playerInstantiated = false;
        }

        if(check)
        {
            //Gestion des éléments liés à cette situation(musique, surbrillance du roi, restriction de mouvement de toutes les pièces...)
            Debug.Log("Echec");
        }
    }
}