﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour {
    public static int movement;

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    //private int whosTurn = 1;
    public bool coroutineAllowed = true;
    public GameObject currentPlayer;

    // Use this for initialization
    void Start() 
    {
        movement = 0;
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
    }

    public void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine("RollTheDice");
        }
    }

    public void RollFinalDice()
    {
        StartCoroutine("RollTheDice");
    }

    public IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
            movement = randomDiceSide + 1;
        }
    }

    //GameControl.diceSideThrown = randomDiceSide+1;

    // Update is called once per frame
    void Update () {
        currentPlayer = GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState();

        transform.position = new Vector3(currentPlayer.transform.position.x - 5f,
                                         currentPlayer.transform.position.y + 3f,
                                         transform.position.z);
    }
}
