using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;//Partie en surbrillance permettant de déplacer nos pièces

    //Position du board
    public int xBoard = -1;
    public int yBoard = -1;

    //Quel joueur joue
    private string player;

    //Tous les sprites possibles
    public Sprite queen, king, bishop, knight, rook, pawn;

    public void Activate()
    {
        controller = GameObject.FindWithTag("GameController");

        //Pour placer chaque pièce à la bonne place
        setCoords();

        //On donne le bon sprite à chaque pièce (et la bonne couleur -> A faire plus tard)
        switch(this.name)
        {
            case "queen_p1":
                this.GetComponent<SpriteRenderer>().sprite = queen;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case "king_p1":
                this.GetComponent<SpriteRenderer>().sprite = king;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case "bishop_p1":
                this.GetComponent<SpriteRenderer>().sprite = bishop;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case "knight_p1":
                this.GetComponent<SpriteRenderer>().sprite = knight;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case "rook_p1":
                this.GetComponent<SpriteRenderer>().sprite = rook;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case "pawn_p1":
                this.GetComponent<SpriteRenderer>().sprite = pawn;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                break;

            case "queen_p2":
                this.GetComponent<SpriteRenderer>().sprite = queen;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case "king_p2":
                this.GetComponent<SpriteRenderer>().sprite = king;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case "bishop_p2":
                this.GetComponent<SpriteRenderer>().sprite = bishop;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case "knight_p2":
                this.GetComponent<SpriteRenderer>().sprite = knight;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case "rook_p2":
                this.GetComponent<SpriteRenderer>().sprite = rook;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case "pawn_p2":
                this.GetComponent<SpriteRenderer>().sprite = pawn;
                this.GetComponent<SpriteRenderer>().color = Color.black;
                break;
        }
    }

    public void setCoords()
    {
        float x = xBoard;
        float y = yBoard;

        //Valeurs à tester (valeures temporaires)
        x *= 0.12f;
        y *= 0.125f;

        x += -0.417f;
        y += -0.413f;

        this.transform.position = new Vector3(x,y,0);
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");

        for(int i=0; i< movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMovePlates()
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
                PawnMovePlate(xBoard, yBoard - 1);
                break;
            case "pawn_p1":
                PawnMovePlate(xBoard, yBoard + 1);
                break;
        }
    }

    public void LineMovePlate(int xIncrement, int yIncrement)
    {

    }

    public void LMovePlate()
    {

    }

    public void SurroundMovePlate()
    {

    }

    public void PawnMovePlate(int xBoard, int yBoard)
    {

    }

    private void OnMouseUp()
    {
        DestroyMovePlates();

        InitiateMovePlates();
    }
}
