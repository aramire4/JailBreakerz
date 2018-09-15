using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    public float moveSize = 1.28f;
    public Vector3 pos;
    public bool isMyTurn;

    private Vector3 resetPosition;
    private int moveAmount;
    private int inputAvailable = 0;
    private int movesMade = 0;


    // Use this for initialization
    void Start () {
        pos = transform.position;
        resetPosition = transform.position;
        //moveAmount = DiceRoll.movement;
    }
	

	// Update is called once per frame
	void Update () {
        inputAvailable--;
        moveAmount = DiceRoll.movement;
        if (isMyTurn)
        {
            if (inputAvailable <= 0 && moveAmount > 0 && movesMade < moveAmount)
            {
                if (Input.GetAxis("Vertical") > .5)
                {
                    pos.y += moveSize;
                    inputAvailable = 20;
                    movesMade++;
                    //transform.localPosition
                }

                else if (Input.GetAxis("Vertical") < -.5)
                {
                    pos.y -= moveSize;
                    inputAvailable = 20;
                    movesMade++;
                }

                else if (Input.GetAxis("Horizontal") > .5)
                {
                    pos.x += moveSize;
                    inputAvailable = 20;
                    movesMade++;
                }

                else if (Input.GetAxis("Horizontal") < -.5)
                {
                    pos.x -= moveSize;
                    inputAvailable = 20;
                    movesMade++;
                }
                transform.position = pos;

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                pos = resetPosition;
                transform.position = pos;
                movesMade = 0;
            }

        }
    }

}
