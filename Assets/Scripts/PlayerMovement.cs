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
    private int interractionCheck;

    // Use this for initialization
    void Start () {
        pos = transform.position;
        resetPosition = transform.position;
        interractionCheck = 0;
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
                    if(GameController.CheckForWalls(pos.x, (pos.y+moveSize)) == false
                       && GameController.CheckForPlayer(pos.x,(pos.y+moveSize)) == false)
                    {
                        pos.y += moveSize;
                        inputAvailable = 20;
                        movesMade++;
                    }

                    //transform.localPosition
                }

                else if (Input.GetAxis("Vertical") < -.5)
                {
                    if (GameController.CheckForWalls(pos.x, (pos.y - moveSize)) == false
                        && GameController.CheckForPlayer(pos.x, (pos.y - moveSize)) == false)

                    {
                        pos.y -= moveSize;
                        inputAvailable = 20;
                        movesMade++;
                    }
                }

                else if (Input.GetAxis("Horizontal") > .5)
                {
                    if (GameController.CheckForWalls((pos.x + moveSize), pos.y) == false
                        && GameController.CheckForPlayer((pos.x + moveSize), pos.y) == false)
                    {
                        pos.x += moveSize;
                        inputAvailable = 20;
                        movesMade++;
                    }
                }

                else if (Input.GetAxis("Horizontal") < -.5)
                {
                    if (GameController.CheckForWalls((pos.x - moveSize), pos.y) == false
                        && GameController.CheckForPlayer((pos.x - moveSize), pos.y) == false)
                    {
                        pos.x -= moveSize;
                        inputAvailable = 20;
                        movesMade++;
                    }
                }
                transform.position = pos;

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (interractionCheck != 0)
                {
                    print("you cannot reset your action");
                    //TODO
                }
                else
                {
                    pos = resetPosition;
                    transform.position = pos;
                    movesMade = 0;
                }
            }

            if(Input.GetKeyDown(KeyCode.E)){
                print("end turn");
                //TODO
                GameState.NextPlayer();
            }

            if (GameController.CheckForInterractions(pos.x, pos.y) == true)
            {
                //Check which room
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    //TODO get item based on position
                    if (interractionCheck != 0)
                    {
                        print("you can only do that once per turn");
                        //TODO
                    }
                    else
                    {
                        print("item added to inventory");
                        interractionCheck++;
                        movesMade = moveAmount;
                    }

                }

            }

            //TODO-win conditions based on exit
            if (GameController.CheckForExits(pos.x, pos.y) == true)
            {
                //Check which room & check for win condition

            }

        }
    }

}
