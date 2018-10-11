using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionCanvas : MonoBehaviour
{
    public GameObject inventoryCanvas;
    public GameObject selection;

    public Vector3 pos;
    public float moveAmount = 1.5f;

    public Text slot1;
    public Text slot2;
    public Text slot3;

    public Text cond1;
    public Text cond2;
    public Text cond3;
    public Text cond4;
    public Text cond5;

    public int place;
    public bool usingInventory;
    public bool checkingInstructions;

    private GameObject current;
    private int inputAvailable = 0;

    public void ShowInstructions()
    {
        gameObject.SetActive(true);
        pos = slot1.transform.position;
        selection.transform.position = pos;
        place = 0;
        cond1.text = "";
        cond2.text = "";
        cond3.text = "";
        cond4.text = "";
        cond5.text = "";
        current = GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState();
        checkingInstructions = true;
    }

    public void HideInstructions()
    {
        gameObject.SetActive(false);
        checkingInstructions = false;
        //TODO more
    }

    public bool IsCanvasActive()
    {
        return gameObject.activeSelf;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        usingInventory = inventoryCanvas.GetComponent<CanvasBahavior>().usingInventory;
        if (current != null)
        {
            inputAvailable--;

            UpdateText();

            if (IsCanvasActive() && checkingInstructions)
            {
                if (inputAvailable <= 0)
                {
                    if (Input.GetAxis("Vertical") > .5 && place > 0)
                    {
                        pos.y += moveAmount;
                        inputAvailable = 20;
                        place--;
                    }

                    else if (Input.GetAxis("Vertical") < -.5 && place < 2)
                    {
                        pos.y -= moveAmount;
                        inputAvailable = 20;
                        place++;
                    }
                    /*
                    else if (Input.GetAxis("Horizontal") < -.5)
                    {
                        //Change to inventory canvas
                        HideInstructions();
                    }*/
                }
            }
        }
        selection.transform.position = pos;
        transform.position = current.GetComponent<Player>().transform.position;
    }

    void UpdateText()
    {
        if(place == 0)
        {
            //hole
            cond1.text = "3 Strength";
            cond2.text = "1 Smarts";
            cond3.text = "Spoon";
            cond4.text = "Flashlight";
            cond5.text = "Food";
            if (current.GetComponent<Player>().strength >= 3 && place == 0) 
                cond1.color = Color.green;
            else cond1.color = Color.white;
            if (current.GetComponent<Player>().intelligence >= 1 && place == 0) 
                cond2.color = Color.green;
            else cond2.color = Color.white;
            if (GameObject.Find("Items").GetComponent<UseItems>().HasCertainItem(current, 18) && place == 0) 
                cond3.color = Color.green;
            else cond3.color = Color.white;
            if (GameObject.Find("Items").GetComponent<UseItems>().HasCertainItem(current, 5) && place == 0) 
                cond4.color = Color.green;
            else cond4.color = Color.white;
            if (GameObject.Find("Items").GetComponent<UseItems>().HasItemType(current, "food") && place == 0) 
                cond5.color = Color.green;
            else cond5.color = Color.white;
        }
        else if (place == 1)
        {
            //door
            cond1.text = "3 Smarts";
            cond2.text = "1 Looks";
            cond3.text = "Distraction";
            cond4.text = "Key";
            cond5.text = "Weapon";
            if (current.GetComponent<Player>().intelligence >= 3 && place == 1)
                cond1.color = Color.green;
            else cond1.color = Color.white;
            if (current.GetComponent<Player>().looks >= 1 && place == 1)
                cond2.color = Color.green;
            else cond2.color = Color.white;
            if (GameObject.Find("Items").GetComponent<UseItems>().HasItemType(current, "distraction") && place == 1)
                cond3.color = Color.green;
            else cond3.color = Color.white;
            if (GameObject.Find("Items").GetComponent<UseItems>().HasCertainItem(current, 8) && place == 1)
                cond4.color = Color.green;
            else cond4.color = Color.white;
            if (GameObject.Find("Items").GetComponent<UseItems>().HasItemType(current, "weapon") && place == 1)
                cond5.color = Color.green;
            else cond5.color = Color.white;
        }

        else if (place == 2)
        {
            //secretary
            cond1.text = "3 Looks";
            cond2.text = "1 Strength";
            cond3.text = "Flowers";
            cond4.text = "Book";
            cond5.text = "Food";
            if (current.GetComponent<Player>().looks >= 3 && place == 2)
                cond1.color = Color.green;
            else cond1.color = Color.white;
            if (current.GetComponent<Player>().strength >= 1 && place == 2)
                cond2.color = Color.green;
            else cond2.color = Color.white;
            if (GameObject.Find("Items").GetComponent<UseItems>().HasCertainItem(current, 6) && place == 2) 
                cond3.color = Color.green;
            else cond3.color = Color.white;
            if (GameObject.Find("Items").GetComponent<UseItems>().HasCertainItem(current, 3) && place == 2) 
                cond4.color = Color.green;
            else cond4.color = Color.white;
            if (GameObject.Find("Items").GetComponent<UseItems>().HasItemType(current, "food") && place == 2) 
                cond5.color = Color.green;
            else cond5.color = Color.white;
        }

    }

}