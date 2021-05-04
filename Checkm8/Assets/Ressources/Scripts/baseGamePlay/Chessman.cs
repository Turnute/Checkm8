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

        //Pour placer cchaque pièce à la bonne place
        setCoords();

        //On donne le bon sprite à chaque pièce (et la bonne couleur -> A faire plus tard)
        switch(this.name)
        {
            case "queen_p1":
                this.GetComponent<SpriteRenderer>().sprite = queen;
                break;
            case "king_p1":
                this.GetComponent<SpriteRenderer>().sprite = king;
                break;
            case "bishop_p1":
                this.GetComponent<SpriteRenderer>().sprite = bishop;
                break;
            case "knight_p1":
                this.GetComponent<SpriteRenderer>().sprite = knight;
                break;
            case "rook_p1":
                this.GetComponent<SpriteRenderer>().sprite = rook;
                break;
            case "pawn_p1":
                this.GetComponent<SpriteRenderer>().sprite = pawn;
                break;

            case "queen_p2":
                this.GetComponent<SpriteRenderer>().sprite = queen;
                break;
            case "king_p2":
                this.GetComponent<SpriteRenderer>().sprite = king;
                break;
            case "bishop_p2":
                this.GetComponent<SpriteRenderer>().sprite = bishop;
                break;
            case "knight_p2":
                this.GetComponent<SpriteRenderer>().sprite = knight;
                break;
            case "rook_p2":
                this.GetComponent<SpriteRenderer>().sprite = rook;
                break;
            case "pawn_p2":
                this.GetComponent<SpriteRenderer>().sprite = pawn;
                break;
        }
    }

    public void setCoords()
    {
        float x = xBoard;
        float y = yBoard;

        //Valeurs à tester (celles ci ne sont pas bonnes)
        x *= 0.12f;
        y *= 0.12f;

        x += -0.415f;
        y += -0.415f;

        this.transform.position = new Vector3(x,y,0);
    }
}
