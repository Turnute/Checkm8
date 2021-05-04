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
}
