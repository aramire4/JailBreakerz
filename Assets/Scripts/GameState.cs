using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameState : MonoBehaviour {
    public static State currentPlayer;
    public static int numberOfPlayers = 6;//GameController.players.Length; //TODO-change to be what the player puts in

    public GameObject[] playerlist = GameController.players;
    //public Player[] playerorder = null;


    public enum State
    {
        Player1,
        Player2,
        Player3,
        Player4,
        Player5,
        Player6
    }

    public State[] stateOrder = {State.Player1, State.Player2, State.Player3,
        State.Player4, State.Player5, State.Player6};


    public static State GetCurrentState(){
        return currentPlayer;
    }

    public static void NextPlayer()
    {
        //Debug.Log(numberOfPlayers);
        if (currentPlayer == State.Player1)
        {
            currentPlayer = State.Player2;
        }
        else if (currentPlayer == State.Player2)
        {
            currentPlayer = State.Player3;
        }
        else if (currentPlayer == State.Player3)
        {
            currentPlayer = State.Player4;
        }
        else if (currentPlayer == State.Player4)
        {
            currentPlayer = State.Player5;
        }
        else if (currentPlayer == State.Player5)
        {
            currentPlayer = State.Player6;
        }
        else if (currentPlayer == State.Player6)
        {
            currentPlayer = State.Player1;
        }
        /*
        if (currentPlayer == State.Player1)
        {
            currentPlayer = State.Player2;
        }
        else if (currentPlayer == State.Player2)
        {
            if (numberOfPlayers > 2)
            {
                currentPlayer = State.Player3;
            }
            else currentPlayer = State.Player1;
        }
        else if (currentPlayer == State.Player3)
        {
            if (numberOfPlayers > 3)
            {
                currentPlayer = State.Player4;
            }
            else currentPlayer = State.Player1;
        }
        else if (currentPlayer == State.Player4)
        {
            if (numberOfPlayers > 4)
            {
                currentPlayer = State.Player5;
            }
            else currentPlayer = State.Player1;
        }
        else if (currentPlayer == State.Player5)
        {
            if (numberOfPlayers > 5)
            {
                currentPlayer = State.Player6;
            }
            else currentPlayer = State.Player1;
        }
        else if (currentPlayer == State.Player6)
        {
            currentPlayer = State.Player1;
        }
        */
    }
        // Use this for initialization
    void Start () {
        currentPlayer = State.Player1;
    
        System.Random rnd = new System.Random();
        playerlist = playerlist.OrderBy(x => rnd.Next()).ToArray();
        //stateOrder = stateOrder.OrderBy(x => rnd.Next()).ToArray();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            playerlist[i].GetComponent<Player>().playerState = stateOrder[i];
            //TODO-assign state to players
        }

    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(currentPlayer);
    }
}
