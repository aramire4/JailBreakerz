using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float boundary;
    public Vector2 originalCameraPosition;

    public float screenWidth;
    public float screenHeight;
    public Vector3 pos;

    public bool playerFocus;

    public GameObject currentPlayer;
    public GameObject currentGuard;

	// Use this for initialization
	void Start () {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        boundary = 20;
        pos = transform.position;
        playerFocus = true;
        //set originalCameraPosition;
	}
	
	// Update is called once per frame
	void Update () {
        currentPlayer = GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState();
        currentGuard = GameObject.Find("GuardState").GetComponent<GuardStates>().GetObjectFromState();
        //Debug.Log(screenWidth);
        //if(currentPlayer.transform.position.x)
        if (playerFocus)
        {
            transform.position = new Vector3(currentPlayer.transform.position.x,
                                             currentPlayer.transform.position.y,
                                             transform.position.z);
        }

        else
        {
            transform.position = new Vector3(currentGuard.transform.position.x,
                                             currentGuard.transform.position.y,
                                             transform.position.z);
        }

    }
}
