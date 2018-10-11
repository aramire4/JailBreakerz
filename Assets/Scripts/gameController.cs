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

    public static GameObject[] gWalls;
    public static int gWallLen;
    public static Vector2[] gWallArray;


    public static GameObject[] players;
    public static int playerLen;
    public static Vector2[] playerArray;

    public static GameObject[] guards;
    public static int guardLen;
    public static Vector2[] guardArray;
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

        guards = GameObject.FindGameObjectsWithTag("Guard");
        guardLen = guards.Length;
        guardArray = new Vector2[guardLen];

        for (int i = 0; i < guardLen; i++)
        {
            guardArray[i] = new Vector2(guards[i].transform.position.x, guards[i].transform.position.y);
        }

        gWalls = GameObject.FindGameObjectsWithTag("GuardWall");
        gWallLen = walls.Length;
        gWallArray = new Vector2[wallLen];

        for (int i = 0; i < 2; i++)
        {
            gWallArray[i] = new Vector2(gWalls[i].transform.position.x, gWalls[i].transform.position.y);
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

    public static bool CheckForGWalls(float x, float y)
    {
        for (int i = 0; i < gWallLen; i++)
        {
            if (Math.Abs(gWallArray[i].x - x) <= 0.5
                && Math.Abs(gWallArray[i].y - y) <= 0.5)
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

    public static bool CheckForGuard(float x, float y)
    {
        //TODO-need to keep track of which interractable is where
        for (int i = 0; i < guardLen; i++)
        {
            if (Math.Abs(guardArray[i].x - x) <= 0.5
                && Math.Abs(guardArray[i].y - y) <= 0.5)
            {
                return true;
            }
        }
        return false;
    }

    public static GameObject ReturnPlayer(float x, float y)
    {
        //TODO-need to keep track of which interractable is where
        for (int i = 0; i < playerLen; i++)
        {
            if (Math.Abs(playerArray[i].x - x) <= 0.5
                && Math.Abs(playerArray[i].y - y) <= 0.5)
            {
                return players[i];
            }
        }
        return null;
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

        guards = GameObject.FindGameObjectsWithTag("Guard");
        guardLen = guards.Length;
        guardArray = new Vector2[guardLen];

        for (int i = 0; i < guardLen; i++)
        {
            guardArray[i] = new Vector2(guards[i].transform.position.x, guards[i].transform.position.y);
        }

    }
}
