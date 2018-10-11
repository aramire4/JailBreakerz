using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBahavior : MonoBehaviour {

    // Use this for initialization

    public GameObject selection;
    public GameObject instructionCanvas;
    public bool usingInventory;
    public Vector3 pos;
    public float moveAmount = 1.5f;

    public Text slot1;
    public Text slot2;
    public Text slot3;
    public Text slot4;
    public Text slot5;

    public Text str;
    public Text look;
    public Text intell;
    public Text luck;
    public Text itemDescription;

    public bool checkingInstructions;
    public Item counterItem;

    private int itemLength;
    private GameObject current;
    private Vector3 tempPosition;
    private int place;
    private int inputAvailable = 0;
    private bool countering;

    public void ActivateInventory()
    {
        //TODO-fix box selector position
        /*
        transform.position = current.GetComponent<Player>().transform.position;
        tempPosition.x = transform.position.x - 3f;
        tempPosition.y = transform.position.y + 2f;
        */
        //tempPosition = new Vector3(transform.position.x - 3.65f, transform.position.y + 2.75f, 0f);
        //tempPosition = pos;
        gameObject.SetActive(true);
        usingInventory = true;
        //pos = tempPosition;
        //pos = new Vector3(transform.position.x - 3.65f, transform.position.y + 2.75f, 0f);
        pos = slot1.transform.position;
        selection.transform.position = pos;
        //pos = selection.transform.position;
        place = 0;
        current = GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState();
        slot1.text = "Slot Empty";
        slot2.text = "Slot Empty";
        slot3.text = "Slot Empty";
        slot4.text = "Slot Empty";
        slot5.text = "Slot Empty";
        str.text = "Strength: 0";
        look.text = "Looks: 0";
        intell.text = "Intelligence: 0";
        luck.text = "Luck: 0";
        itemDescription.text = "";
        itemLength = current.GetComponent<Player>().heldItems.Count;
        countering = false;
        counterItem = null;
        checkingInstructions = false;
    }

    public void ActivateOtherInventory(GameObject otherPlayer)
    {
        gameObject.SetActive(true);
        usingInventory = true;
        //pos = tempPosition;
        //pos = new Vector3(transform.position.x - 3.65f, transform.position.y + 2.75f, 0f);
        pos = slot1.transform.position;
        selection.transform.position = pos;
        //pos = selection.transform.position;
        place = 0;
        current = otherPlayer;
        slot1.text = "Slot Empty";
        slot2.text = "Slot Empty";
        slot3.text = "Slot Empty";
        slot4.text = "Slot Empty";
        slot5.text = "Slot Empty";
        str.text = "Strength: 0";
        look.text = "Looks: 0";
        intell.text = "Intelligence: 0";
        luck.text = "Luck: 0";
        itemDescription.text = "";
        itemLength = otherPlayer.GetComponent<Player>().heldItems.Count;
        countering = true;
    }

    public void DeactivateInventory()
    {
        usingInventory = false;
        gameObject.SetActive(false);
        checkingInstructions = false;
        //selection.transform.position = tempPosition;
    }

    public void DeactivateForItemUse()
    {
        gameObject.SetActive(false);
    }

    public bool IsCanvasActive()
    {
        return gameObject.activeSelf;
    }

	void Start () {
        //usingInventory = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (current != null)
        {
            inputAvailable--;

            UpdateText();

            if (usingInventory && IsCanvasActive() && checkingInstructions == false)
            {
                if (inputAvailable <= 0)
                {
                    if (Input.GetAxis("Vertical") > .5 && place > 0)
                    {
                        pos.y += moveAmount;
                        inputAvailable = 20;
                        place--;
                    }

                    else if (Input.GetAxis("Vertical") < -.5 && place < 4)
                    {
                        pos.y -= moveAmount;
                        inputAvailable = 20;
                        place++;
                    }
                    /*
                    else if (Input.GetAxis("Horizontal") > -.5)
                    {
                        //Change to instruction canvas
                        checkingInstructions = true;
                        instructionCanvas.GetComponent<InstructionCanvas>().ShowInstructions();
                    }*/
                }


                if (Input.GetKeyDown(KeyCode.X))
                {
                    Item itm = current.GetComponent<Player>().heldItems[place];
                    current.GetComponent<Player>().heldItems.Remove(itm);
                    GameObject.Find("Items").GetComponent<ItemDatabase>().ReturnItem(itm);
                    /*
                    usingInventory = false;
                    current.GetComponent<PlayerMovement>().
                           inventoryCanvas.GetComponent<CanvasBahavior>().DeactivateInventory();
                    current.GetComponent<PlayerMovement>().usingInventory = false;
                    */
                    print("Item was removed");
                }


                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Item itm = current.GetComponent<Player>().heldItems[place];
                    if (countering == false)
                    {
                        if (GameObject.Find("Items").GetComponent<UseItems>().
                                CanUseItem(itm, current.GetComponent<Player>().transform.position))
                        {
                            DeactivateForItemUse();
                            GameObject.Find("Items").GetComponent<UseItems>().
                                      UseItem(itm, current.GetComponent<Player>().transform.position);
                            //TODO Don't return unless the item is usable
                            //GameObject.Find("Items").GetComponent<ItemDatabase>().ReturnItem(itm);
                            //GameObject.Find("Items").GetComponent<ItemDatabase>().RemoveItemPosFromInventory(place);
                            //TODO check if item is being removed
                            ActivateInventory();
                            print("Used item");

                        }
                        else
                        {
                            print("you cannot use this item yet");
                            //TODO-print this message to the screen
                        }
                    }
                    else 
                    {
                        if(GameObject.Find("Items").GetComponent<UseItems>().CanUseCounterItem(itm))
                        {
                            counterItem = itm;
                            DeactivateForItemUse();
                            //TODO Don't return unless the item is usable
                            //GameObject.Find("Items").GetComponent<ItemDatabase>().ReturnItem(itm);
                            //GameObject.Find("Items").GetComponent<ItemDatabase>().RemoveItemPosFromInventory(place);
                            //TODO check if item is being removed
                        }
                        //TODO do something else if you cannot use counter item
                    }
                }
            }
            selection.transform.position = pos;
            transform.position = current.GetComponent<Player>().transform.position;
        }
    }

    public void UpdateText(){
        if (itemLength > 0)
        {
            slot1.text = current.GetComponent<Player>().heldItems[0].itemName;
            if (itemLength > 1)
            {
                slot2.text = current.GetComponent<Player>().heldItems[1].itemName;
                if (itemLength > 2)
                {
                    slot3.text = current.GetComponent<Player>().heldItems[2].itemName;
                    if (itemLength > 3)
                    {
                        slot4.text = current.GetComponent<Player>().heldItems[3].itemName;
                        if (itemLength > 4)
                        {
                            slot5.text = current.GetComponent<Player>().heldItems[4].itemName;
                        }
                        else
                        {
                            slot5.text = "Slot Empty";
                        }
                    }
                    else
                    {
                        slot4.text = "Slot Empty";
                    }
                }
                else
                {
                    slot3.text = "Slot Empty";
                }
            }
            else
            {
                slot2.text = "Slot Empty";
            }
        }
        else
        {
            slot1.text = "Slot Empty";
        }

        str.text = "Strength: " + current.GetComponent<Player>().strength;
        look.text = "Looks: " + current.GetComponent<Player>().looks;
        intell.text = "Intelligence: " + current.GetComponent<Player>().intelligence;
        luck.text = "Luck: " + current.GetComponent<Player>().luck;
        if (place < current.GetComponent<Player>().heldItems.Count)
        {
            itemDescription.text = current.GetComponent<Player>().heldItems[place].description;
        }
        else itemDescription.text = "";
    }
}
