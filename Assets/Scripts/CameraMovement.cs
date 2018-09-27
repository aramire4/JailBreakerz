using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float boundary;
    public Vector2 originalCameraPosition;

    public float screenWidth;
    public float screenHeight;

    public GameObject currentPlayer;

	// Use this for initialization
	void Start () {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        boundary = 30;
        //set originalCameraPosition;
	}
	
	// Update is called once per frame
	void Update () {
        currentPlayer = GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState();
        //Debug.Log(screenWidth);
        //if(currentPlayer.transform.position.x)
        /*
        transform.position = new Vector3(currentPlayer.transform.position.x,
                                         currentPlayer.transform.position.y,
                                         transform.position.z);
        */
        /*
        if(currentPlayer.transform.position.x > screenWidth - boundary){
            transform.position.x += (screenWidth / 2);
        }
        */


    }
}
