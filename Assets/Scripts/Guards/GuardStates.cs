using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GuardStates : MonoBehaviour {
    public static State current;
    public static State next;
    public GameObject[] guardList;

    public enum State
    {
        None,
        Guard1,
        Guard2
    }
    public State[] stateOrder = { State.None, State.Guard1, State.Guard2 };

    public static bool IsGuardState()
    {
        if (current == State.None) return false;
        else return true;
    }

    public static State GetCurrentState()
    {
        return current;
    }

    public GameObject GetObjectFromState()
    {
        foreach (GameObject guard in guardList)
        {
            if (guard.GetComponent<Guard>().guardState == current)
            {
                return guard;
            }
        }
        return null;
    }

    public void NextState()
    {
        if(current == State.None)
        {
            next = State.Guard1;
        }
        else if (current == State.Guard1)
        {
            next = State.Guard2;
        }
        else if (current == State.Guard2)
        {
            next = State.None;
        }
        Invoke("UpdateState", 0.1f);
        UpdateCamera();
    }

    public void PlayerState()
    {
        if(current != State.None)
        {
            next = State.None;
        }
        Invoke("UpdateState", 0.1f);
        UpdateCamera();
    }

    public GameObject GetRandomGuard()
    {
        System.Random rand = new System.Random();
        int r = rand.Next(0, 2);
        if (r == 0)
        {
            return guardList[0];
        }
        else return guardList[1];
    }

    public void UpdateCamera()
    {
        if (next == State.None) GameObject.Find("MainCamera").GetComponent<CameraMovement>().playerFocus = true;
        else GameObject.Find("MainCamera").GetComponent<CameraMovement>().playerFocus = false;
    }

    // Use this for initialization
    void Start()
    {
        //numberOfPlayers = PlayerPrefs.GetInt("NumberOfPlayers");
        //if (GameController.players == null) { GameController.InitPlayers(); }
        guardList = GameObject.FindGameObjectsWithTag("Guard");//GameController.guards;

    }

    // Update is called once per frame
    void Update () {
		
	}

    void UpdateState()
    {
        //Debug.Log(currentPlayer);
        current = next;
    }
}
