using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenScript : MonoBehaviour {

    public bool pickingNumber;
    public GameObject canvas;

    // Use this for initialization
    void Start () {
        pickingNumber = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Return) && pickingNumber == false){
            pickingNumber = true;
            canvas.GetComponent<NumberOfPlayers>().Activate();
        }
	}
}
