using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float boundary;
    public Vector2 originalCameraPosition;

    public float screenWidth;
    public float screenHeight;
    public Vector3 pos;

    public GameObject currentPlayer;

	// Use this for initialization
	void Start () {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        boundary = 20;
        pos = transform.position;
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
            pos.x += (screenWidth / 2);
        }

        if (currentPlayer.transform.position.x < 0 + boundary)
        {
            pos.x -= (screenWidth / 2);
        }

        if (currentPlayer.transform.position.x > screenHeight - boundary)
        {
            pos.y += (screenHeight / 2);
        }

        if (currentPlayer.transform.position.x < 0 + boundary)
        {
            pos.x -= (screenHeight / 2);
        }

        transform.position = pos;
        */
        transform.position = currentPlayer.transform.position;
    }
}
