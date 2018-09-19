using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static bool active;
    public GameState.State playerState;

    List<Item> heldItems = new List<Item>();
    private static int strength;
    private static int intelligence;
    private static int looks;
    //TODO-container of Items

    //private StateMachine stateMachine = new StateMachine();


	// Use this for initialization
	void Start () {
       //TODO-Instantiate PlayerState somehow

	}
	
	// Update is called once per frame
	void Update () {
        //if (GameState.GetCurrentState == playerState) { active = true; }

	}

}
