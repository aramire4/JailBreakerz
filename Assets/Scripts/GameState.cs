using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameState : MonoBehaviour {
    public static State currentPlayer;
    public static State nextPlayer;
    public static int numberOfPlayers = 6;//GameController.players.Length; //TODO-change to be what the player puts in

    public GameObject[] playerlist;
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

    public GameObject GetObjectFromState(){
        foreach (GameObject play in playerlist)
        {
            if (play.GetComponent<Player>().playerState == currentPlayer)
            {
                return play;
            }
        }
        return null;
    }

    public static State GetCurrentState(){
        return currentPlayer;
    }

    public void NextPlayer()
    {
        if (currentPlayer == State.Player1)
        {
            nextPlayer = State.Player2;
        }
        else if (currentPlayer == State.Player2)
        {
            if (numberOfPlayers > 2)
            {
                nextPlayer = State.Player3;
            }
            else nextPlayer = State.Player1;
        }
        else if (currentPlayer == State.Player3)
        {
            if (numberOfPlayers > 3)
            {
                nextPlayer = State.Player4;
            }
            else nextPlayer = State.Player1;
        }
        else if (currentPlayer == State.Player4)
        {
            if (numberOfPlayers > 4)
            {
                nextPlayer = State.Player5;
            }
            else nextPlayer = State.Player1;
        }
        else if (currentPlayer == State.Player5)
        {
            if (numberOfPlayers > 5)
            {
                nextPlayer = State.Player6;
            }
            else nextPlayer = State.Player1;
        }
        else if (currentPlayer == State.Player6)
        {
            nextPlayer = State.Player1;
        }
        //Debug.Log(currentPlayer);
        Invoke("UpdateState", 0.1f);
    }
        // Use this for initialization
    void Start () {
        playerlist = GameController.players;
        currentPlayer = State.Player1;
        nextPlayer = State.Player1;

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
	void UpdateState () {
        //Debug.Log(currentPlayer);
        currentPlayer = nextPlayer;
    }
}
