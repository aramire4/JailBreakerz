using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public static State currentPlayer;
    public static int numberOfPlayers;

    public enum State
    {
        Player1,
        Player2,
        Player3,
        Player4,
        Player5,
        Player6
    }

    public static State GetCurrentState(){
        return currentPlayer;
    }

    public static void NextPlayer()
    {
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
    }
        // Use this for initialization
    void Start () {
        currentPlayer = State.Player1;
        //TODO make this process randomized based on the number of players
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
