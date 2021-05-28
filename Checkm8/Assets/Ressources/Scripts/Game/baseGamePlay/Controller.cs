using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject chesspiece;
    public GameObject lighting;
    public GameObject winnerText;
    public GameObject glowEffect;
    public GameObject buttonRestart, buttonNext;
    public GameObject p1Win,p2Win;//Les portraits des joueurs(A modif)
    public GameObject promotePanel;
    public GameObject quitPanel;
    public GameObject pauseButton, pRoque, gRoque, roqueText;
    public Text winnerName;
    public Text currentPlayerDisplay;
    public GameObject cmManager;
    public static float timeBeforeNextTurn = 0.3f;//En secondes
    public static bool canPlay = true;
    public static int size = 8;//Taille du plateau de jeu, changeant en fonction du nombre de joueur

    private GameObject[,] positions = new GameObject[size,size];//Ensemble des positions sur le board
    //Ensemble des joueurs(que 2 pour l'instant)
    public GameObject[] player1 = new GameObject[16];//(car 16 pièces)
    public GameObject[] player2 = new GameObject[16];
    //Les couleurs des pièces des joueurs
    public static Color p1Color;
    public static Color p2Color;

    public string currentPlayer = "p1";

    public bool promotingPanelUp = false;//True lorsque l'on effectue une promotion
    public GameObject pieceToPromote;

    private bool gameOver = false;

    void Start()
    {
        //On se met à jour avec le ruleset actuel
        GameSettings.UpdateProba();

        //Création des joueurs (2 pour l'instant)
        player1 = new GameObject[]
        {
            Create("rook_p1",0,0), Create("rook_p1",7,0), Create("knight_p1",1,0), Create("bishop_p1",2,0),
            Create("queen_p1",3,0), Create("king_p1",4,0), Create("bishop_p1",5,0), Create("knight_p1",6,0),
            Create("pawn_p1",0,1), Create("pawn_p1",1,1), Create("pawn_p1",2,1), Create("pawn_p1",3,1),
            Create("pawn_p1",4,1), Create("pawn_p1",5,1), Create("pawn_p1",6,1), Create("pawn_p1",7,1)
        };

        player2 = new GameObject[]
        {
            Create("rook_p2",0,7), Create("rook_p2",7,7), Create("knight_p2",1,7), Create("bishop_p2",2,7),
            Create("queen_p2",3,7), Create("king_p2",4,7), Create("bishop_p2",5,7), Create("knight_p2",6,7),
            Create("pawn_p2",0,6), Create("pawn_p2",1,6), Create("pawn_p2",2,6), Create("pawn_p2",3,6),
            Create("pawn_p2",4,6), Create("pawn_p2",5,6), Create("pawn_p2",6,6), Create("pawn_p2",7,6)
        };

        //Mettons chaque pièce à leur positions
        for(int i=0; i<player1.Length;i++)
        {
            SetPosition(player1[i]);
            SetPosition(player2[i]);
        }
        CheckMateManager.playerInstantiated = true;
    }

    
    public GameObject Create(string pieceName, int posX, int posY)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0,0,0), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>();
        cm.name = pieceName;
        cm.xBoard = posX;
        cm.yBoard = posY;
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();

        positions[cm.xBoard,cm.yBoard] = obj;
    }

    public void SetPositionEmpty(int posX, int posY)
    {
        positions[posX, posY] = null;
    }

    public GameObject GetPosition(int posX, int posY)//Avoir une pièce à une position donnée
    {
        return positions[posX, posY];
    }

    public bool PositionOnBoard(int posX, int posY)//La position est-elle sur le board
    {
        if(posX < 0 || posY<0 || posX >= positions.GetLength(0) || posY >= positions.GetLength(1))
            return false;
        else
            return true;
    }

    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool isGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {
        if(currentPlayer == "p1")
        {
            currentPlayer = "p2";
            if(SpecialActions.which_player_roqued == currentPlayer)
            {
                SpecialActions.petitRoque = false;
                SpecialActions.grandRoque = false;
            }

            cmManager.GetComponent<CheckMateManager>().isCheck();
        }else{
            currentPlayer = "p1";
            if(SpecialActions.which_player_roqued == currentPlayer)
            {
                SpecialActions.petitRoque = false;
                SpecialActions.grandRoque = false;
            }
            cmManager.GetComponent<CheckMateManager>().isCheck();
        }
        canPlay = true;
        GameSettings.turnBtwnEvent--;
    }

    public void Winner(string winnerPlayer)
    {
        gameOver = true;
        if(winnerPlayer == "p1")
        {
            winnerName.text = "Player 1 won !";
            p1Win.SetActive(true);
            Debug.Log(p1Color);
            p1Win.GetComponent<Image>().color = GameSettings.colorP1;
        }else{
            winnerName.text = "Player 2 won !";
            p1Win.SetActive(true);
            p1Win.GetComponent<Image>().color = GameSettings.colorP2;
        }
        glowEffect.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("1v1_game");
    }

    public void NextGame()
    {
        SceneManager.LoadScene("SelectionScene");
    }

    public void QuitGame()
    {
        quitPanel.SetActive(true);
    }

    public void CloseQuitPanel()
    {
        quitPanel.SetActive(false);
    }

    public void Update()
    {
        //Gestion d'events
        if(GameSettings.turnBtwnEvent == 0)
        {
            //On effectue un event
            EventsManager.chooseEvent();
            //On reset le nb d'event
            GameSettings.turnBtwnEvent = Rulesets.NbTurnEvent;
        }

        if(gameOver)
        {
            currentPlayerDisplay.text = " ";
            buttonNext.SetActive(true);
            buttonRestart.SetActive(true);
            lighting.GetComponent<Animator>().SetBool("gameOver",true);
            winnerText.SetActive(true);
            pauseButton.SetActive(false);
            pRoque.SetActive(false);
            gRoque.SetActive(false);
            roqueText.SetActive(false);
        }else{
            if(currentPlayer == "p1")
                currentPlayerDisplay.text = "Player 1 turn";
            else   
                currentPlayerDisplay.text = "Player 2 turn";
        }
        if(timeBeforeNextTurn < 0.3f)
        {
            timeBeforeNextTurn -= Time.deltaTime;
        }
        if(timeBeforeNextTurn <= 0)
        {
            NextTurn();
            Debug.Log(GameSettings.turnBtwnEvent);
            timeBeforeNextTurn = 0.3f;
        }
    }
}
