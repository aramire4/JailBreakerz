using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingCanvas : MonoBehaviour {

    public bool fighting;

    private GameObject attacker;
    private GameObject defender;

    public void ActivateFight()
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
        attacker = GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState();
        fighting = true;
        //TODO get defender
    }

    public void DeactivateFight()
    {
        fighting = false;
        gameObject.SetActive(false);
        //selection.transform.position = tempPosition;
    }

    public bool isCanvasActive()
    {
        return gameObject.activeSelf;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = attacker.GetComponent<Player>().transform.position;

        if (fighting && isCanvasActive())
        {
            //conduct fight
        }

    }
}
