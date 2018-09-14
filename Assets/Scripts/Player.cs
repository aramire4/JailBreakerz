using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool active;
    public GameState.State playerState;

    private int strength;
    private int intelligence;
    private int looks;
    //TODO-container of Items

    //private StateMachine stateMachine = new StateMachine();


	// Use this for initialization
	void Start () {
       //TODO-Instantiate PlayerState somehow
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
