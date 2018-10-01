using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSize = 1.28f;
    public Vector3 pos;
    public bool isMyTurn;
    public bool usingInventory;
    public GameObject inventoryCanvas;

    private Vector3 resetPosition;
    private int moveAmount;
    private int inputAvailable = 0;
    private int movesMade = 0;
    private int interractionCheck;
    private bool hasRolled;
    private GameObject current;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        resetPosition = transform.position;
        interractionCheck = 0;
        isMyTurn = false;
        usingInventory = false;
        //isMyTurn = GetComponent<Player>().playerState;
        //TODO-may have to go in update
    }


    // Update is called once per frame
    void Update()
    {
        current = GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState();
        if (GameState.currentPlayer == GetComponent<Player>().playerState)
        {
            isMyTurn = true;
        }
        else
        {
            isMyTurn = false;
        }

        inputAvailable--;
        moveAmount = DiceRoll.movement;
        if (isMyTurn && usingInventory != true)
        {
            if (inputAvailable <= 0 && moveAmount > 0 && movesMade < moveAmount)
            {
                if (Input.GetAxis("Vertical") > .5)
                {
                    if (GameController.CheckForWalls(pos.x, (pos.y + moveSize)) == false
                       && GameController.CheckForPlayer(pos.x, (pos.y + moveSize)) == false)
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

            if (Input.GetKeyDown(KeyCode.E))
            {
                print("end turn");
                //TODO
                pos = transform.position;
                resetPosition = transform.position;
                interractionCheck = 0;
                inputAvailable = 0;
                movesMade = 0;
                hasRolled = false;
                //GetComponent<DiceRoll>().coroutineAllowed = true;
                GameObject.Find("StateMachine").GetComponent<GameState>().NextPlayer();
                //GameObject.Find("DiceRoller").GetComponent<DiceRoll>().coroutineAllowed = true;
                //TODO-something with the dice
            }

            if (GameController.CheckForInterractions(pos.x, pos.y) == true)
            {
                //Check which room
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    //TODO get item based on position
                    if (interractionCheck != 0)
                    {
                        print("you can only do that once per turn");
                        //TODO
                    }
                    else
                    {
                        //TODO-change database
                        List<Item> db = GameObject.Find("Items").GetComponent<ItemDatabase>().getItemDatabase();
                        Item itm = GameObject.Find("Items").GetComponent<ItemDatabase>().drawAndRemove(db);
                        if (itm != null)
                        {

                            if ((current.GetComponent<Player>().heldItems.Count < 4) && itm.description != "stat")
                            {
                                print("item added to inventory");
                                current.GetComponent<Player>().heldItems.Add(itm);
                            }
                            else if(current.GetComponent<Player>().heldItems.Count == 4)
                            {
                                GameObject.Find("Items").GetComponent<ItemDatabase>().returnItem(itm);
                            }
                            //TODO draw item based on position
                            //add to player items

                            interractionCheck++;
                            movesMade = moveAmount;
                        }
                        else{
                            print("There are no items left here");
                        }
                    }

                }

            }

            //TODO-win conditions based on exit
            if (GameController.CheckForExits(pos.x, pos.y) == true)
            {
                //Check which room & check for win condition

            }

        }//end of isMyTurn
        if (Input.GetKeyDown(KeyCode.I))
        {
            //print("Inventory");
            if (usingInventory == false)
            {
                usingInventory = true;
                inventoryCanvas.GetComponent<CanvasBahavior>().ActivateInventory();
            }
            else
            {
                inventoryCanvas.GetComponent<CanvasBahavior>().DeactivateInventory();
                usingInventory = false;
            }
        }
    }
}
