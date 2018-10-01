using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBahavior : MonoBehaviour {

    // Use this for initialization

    public GameObject selection;
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
    public Text itemDescription;

    private int itemLength;
    private GameObject current;
    private Vector3 tempPosition;
    private int place;
    private int inputAvailable = 0;

    public void ActivateInventory()
    {
        tempPosition = pos;
        gameObject.SetActive(true);
        usingInventory = true;
        pos = selection.transform.position;
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
        itemDescription.text = "";
        itemLength = current.GetComponent<Player>().heldItems.Count;
    }

    public void DeactivateInventory()
    {
        usingInventory = false;
        gameObject.SetActive(false);
        selection.transform.position = tempPosition;
    }

	void Start () {
        //usingInventory = false;
	}
	
	// Update is called once per frame
	void Update () {
        inputAvailable--;

        updateText();

        if (usingInventory && inputAvailable <= 0)
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
        }
        selection.transform.position = pos;
    }

    public void updateText(){
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
        if (place < current.GetComponent<Player>().heldItems.Count)
        {
            itemDescription.text = current.GetComponent<Player>().heldItems[place].description;
        }
        else itemDescription.text = "";
    }
}
