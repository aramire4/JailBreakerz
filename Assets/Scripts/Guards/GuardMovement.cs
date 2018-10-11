using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour {
    // Use this for initialization
    public float moveSize = 1.28f;
    public Vector3 pos;
    public bool selected;
    public int moveAmount;
    public Vector3 resetPosition;

    private int inputAvailable = 0;
    private int movesMade = 0;

    void Start()
    {
        pos = transform.position;
        resetPosition = transform.position;
    }

    void EndTurn()
    {
        pos = transform.position;
        resetPosition = transform.position;
        inputAvailable = 0;
        movesMade = 0;
        moveAmount = 0;
        GameObject.Find("GuardState").GetComponent<GuardStates>().PlayerState();
        GameObject currentPlayer = GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState();
        currentPlayer.GetComponent<PlayerMovement>().EndTurn();
    }

    // Update is called once per frame
    void Update()
    {
        moveAmount = DiceRoll.movement;
        if (GuardStates.current == GetComponent<Guard>().guardState)
        {
            selected = true;
        }
        else selected = false;

        moveAmount = DiceRoll.movement;

        if (selected)
        {
            inputAvailable--;
            if (inputAvailable <= 0 && movesMade < moveAmount && moveAmount > 0)
            {
                if (Input.GetAxis("Vertical") > .5)
                {
                    if (GameController.CheckForWalls(pos.x, (pos.y + moveSize)) == false
                            && GameController.CheckForGuard(pos.x, (pos.y + moveSize)) == false
                            && GameController.CheckForGWalls(pos.x, (pos.y+moveSize))== false)
                    {
                        if (GameController.CheckForPlayer(pos.x, (pos.y + moveSize)) == true)
                        {
                            GameObject.Find("Items").GetComponent<UseItems>().EncounterWarden(pos.x, pos.y + moveSize);
                            EndTurn();
                        }
                        else
                        {
                            pos.y += moveSize;
                            inputAvailable = 20;
                            movesMade++;
                        }
                    }

                        //transform.localPosition
                 }

                 else if (Input.GetAxis("Vertical") < -.5)
                 {
                    if (GameController.CheckForWalls(pos.x, (pos.y - moveSize)) == false
                            && GameController.CheckForGuard(pos.x, (pos.y - moveSize)) == false
                            && GameController.CheckForGWalls(pos.x, (pos.y - moveSize)) == false)
                     {
                        if (GameController.CheckForPlayer(pos.x, (pos.y - moveSize)) == true)
                        {
                            GameObject.Find("Items").GetComponent<UseItems>().EncounterWarden(pos.x, pos.y - moveSize);
                            EndTurn();
                        }
                        else
                        {
                            pos.y -= moveSize;
                            inputAvailable = 20;
                            movesMade++;
                        }
                    }
                 }

                 else if (Input.GetAxis("Horizontal") > .5)
                 {
                    if (GameController.CheckForWalls((pos.x + moveSize), pos.y) == false
                            && GameController.CheckForGuard((pos.x + moveSize), pos.y) == false
                            && GameController.CheckForGWalls((pos.x + moveSize), pos.y) == false)
                    {
                        if (GameController.CheckForPlayer((pos.x + moveSize), pos.y) == true)
                        {
                            GameObject.Find("Items").GetComponent<UseItems>().EncounterWarden(pos.x + moveSize, pos.y);
                            EndTurn();
                        }
                        else
                        {
                            pos.x += moveSize;
                            inputAvailable = 20;
                            movesMade++;
                        }
                    }
                 }

                 else if (Input.GetAxis("Horizontal") < -.5)
                 {
                    if (GameController.CheckForWalls((pos.x - moveSize), pos.y) == false
                             && GameController.CheckForGuard((pos.x - moveSize), pos.y) == false
                             && GameController.CheckForGWalls((pos.x - moveSize), pos.y) == false)
                    {
                        if (GameController.CheckForPlayer((pos.x - moveSize), pos.y) == true)
                        {
                            GameObject.Find("Items").GetComponent<UseItems>().EncounterWarden(pos.x - moveSize, pos.y);
                            EndTurn();
                        }
                        else
                        {
                            pos.x -= moveSize;
                            inputAvailable = 20;
                            movesMade++;
                        }
                    }
                 }
                transform.position = pos;
                

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                pos = resetPosition;
                transform.position = pos;
                movesMade = 0;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {

                print("end turn");
                //TODO
                pos = transform.position;
                resetPosition = transform.position;
                inputAvailable = 0;
                movesMade = 0;
                moveAmount = 0;
                GameObject.Find("GuardState").GetComponent<GuardStates>().PlayerState();
                GameObject currentPlayer = GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState();
                currentPlayer.GetComponent<PlayerMovement>().EndTurn();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                print("Switch guard");
                pos = resetPosition;
                transform.position = pos;
                inputAvailable = 0;
                movesMade = 0;
                GameObject.Find("GuardState").GetComponent<GuardStates>().NextState();
            }
        }
    }
}
