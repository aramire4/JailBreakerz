using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberOfPlayers : MonoBehaviour {
    public GameObject selection;
    public bool pickingNumber;
    public Vector3 pos;
    public float moveAmount = 1.62f;

    //private Vector3 tempPosition;
    private int place;
    private int inputAvailable = 0;

    // Use this for initialization
    void Start () {
        //pickingNumber = false;
	}

    public void Activate()
    {
        //tempPosition = pos;
        gameObject.SetActive(true);
        pickingNumber = true;
        place = 0;
        pos = selection.transform.position;

    }
    // Update is called once per frame
    void Update () {
        inputAvailable--;

        if (inputAvailable <= 0 && pickingNumber == true)
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

        if(Input.GetKeyDown(KeyCode.Return)){
            PlayerPrefs.SetInt("NumberOfPlayers", place + 2);
            pickingNumber = false;
            SceneManager.LoadScene("CharacterSelect");
            //TODO-change scene
        }
    }
}
