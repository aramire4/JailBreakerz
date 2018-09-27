using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //public bool active;
    public GameState.State playerState;

    public List<Item> heldItems = new List<Item>();
    public int strength;
    public int intelligence;
    public int looks;
    public Vector2 position;
    //TODO-container of Items

    //private StateMachine stateMachine = new StateMachine();


	// Use this for initialization
	void Start () {
       //TODO-Instantiate PlayerState somehow

	}
	
	// Update is called once per frame
	void Update () {
        //if (GameState.GetCurrentState == playerState) { active = true; }
        position = transform.position;
	}

}
