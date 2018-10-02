using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameController : MonoBehaviour {

    //TODO-for instructions on screen

    public static GameObject[] walls;
    public static int wallLen;
    public static Vector2[] wallArray;

    public static GameObject[] interractions;
    public static int interLen;
    public static Vector2[] interArray;

    public static GameObject[] exits;
    public static int exitLen;
    public static Vector2[] exitArray;

    public static GameObject[] players;
    public static int playerLen;
    public static Vector2[] playerArray;
    // Use this for initialization
    void Start () {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        wallLen = walls.Length;
        wallArray = new Vector2[wallLen];

        for (int i = 0; i < wallLen; i++)
        {
            wallArray[i] = new Vector2(walls[i].transform.position.x, walls[i].transform.position.y);
        }


        interractions = GameObject.FindGameObjectsWithTag("Interraction");
        interLen = interractions.Length;
        interArray = new Vector2[interLen];

        for (int i = 0; i < interLen; i++)
        {
            interArray[i] = new Vector2(interractions[i].transform.position.x, interractions[i].transform.position.y);
            //TODO keep track of what rooms the interractables are located
        }

        exits = GameObject.FindGameObjectsWithTag("Exit");
        exitLen = exits.Length;
        exitArray = new Vector2[exitLen];

        for (int i = 0; i < exitLen; i++)
        {
            exitArray[i] = new Vector2(exits[i].transform.position.x, exits[i].transform.position.y);
            //TODO keep track of what rooms the interractables are located
        }

        if (players == null) { InitPlayers(); }

        /*
        players = GameObject.FindGameObjectsWithTag("Player");
        playerLen = players.Length;
        playerArray = new Vector2[playerLen];

        for (int i = 0; i < playerLen; i++)
        {
            //Debug.Log(players[i]);
            playerArray[i] = new Vector2(players[i].transform.position.x, players[i].transform.position.y);
        }
        */
    }

    public static void InitPlayers() {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerLen = players.Length;
        playerArray = new Vector2[playerLen];

        for (int i = 0; i < playerLen; i++)
        {
            playerArray[i] = new Vector2(players[i].transform.position.x, players[i].transform.position.y);
        }
    }


    public void Awake()
    {

    }


    public static bool CheckForWalls(float x, float y){
        for (int i = 0; i < wallLen; i++)
        {
            if (Math.Abs(wallArray[i].x - x) <= 0.5 
                && Math.Abs(wallArray[i].y - y) <= 0.5)
            {
                return true;
            }
        }
        return false;
    }

    public static bool CheckForInterractions(float x, float y)
    {
        //TODO-need to keep track of which interractable is where
        for (int i = 0; i < interLen; i++)
        {
            if (Math.Abs(interArray[i].x - x) <= 0.5
                && Math.Abs(interArray[i].y - y) <= 0.5)
            {
                return true;
            }
        }
        return false;
    }

    public static bool CheckForExits(float x, float y)
    {
        //TODO-need to keep track of which interractable is where
        for (int i = 0; i < exitLen; i++)
        {
            if (Math.Abs(exitArray[i].x - x) <= 0.5
                && Math.Abs(exitArray[i].y - y) <= 0.5)
            {
                return true;
            }
        }
        return false;
    }

    public static bool CheckForPlayer(float x, float y)
    {
        //TODO-need to keep track of which interractable is where
        for (int i = 0; i < playerLen; i++)
        {
            if (Math.Abs(playerArray[i].x - x) <= 0.5
                && Math.Abs(playerArray[i].y - y) <= 0.5)
            {
                return true;
            }
        }
        return false;
    }


    // Update is called once per frame
    void Update () {
        //TODO-fix this so it only uses player positions

        players = GameObject.FindGameObjectsWithTag("Player");
        playerLen = players.Length;
        playerArray = new Vector2[playerLen];

        for (int i = 0; i < playerLen; i++)
        {
            playerArray[i] = new Vector2(players[i].transform.position.x, players[i].transform.position.y);
        }

    }
}
