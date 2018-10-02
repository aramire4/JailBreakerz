using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour {

    public GameObject selection;
    public Vector3 pos;
    public float moveAmount = 2.6f;
    public int numberOfPlayers;
    public int playersSelected;
    public float lockPos = 3.36f;
    public GameObject lockPrefab;

    public List<string> all = new List<string>(new string[] { 
        "red", "green", "yellow", "brown", "purple", "blue" 
    });

    public float xValue = -3.14f;

    public List<float> lockPositions = new List<float>(new float[]{
        -6.6f, -4.01f, -1.33f, 1.33f, 4f, 6.62f
    });
    //red green yellow brown purple blue

    public List<string> selected = new List<string>();
    public List<float> positions = new List<float>();

    private int place;
    private int inputAvailable = 0;

    // Use this for initialization
    void Start () {
        numberOfPlayers = PlayerPrefs.GetInt("NumberOfPlayers");
        place = 0;
        pos = selection.transform.position;
        playersSelected = 0;
    }

    void setPrefs(List<string> lst){
        //TODO-fixsetP
        PlayerPrefs.SetString("player1", lst[0]);
        PlayerPrefs.SetString("player2", lst[1]);
        
        if (numberOfPlayers >= 3){
            PlayerPrefs.SetString("player3", lst[2]);
        }
        if(numberOfPlayers >= 4)
        {
            PlayerPrefs.SetString("player4", lst[3]);
        }
        if(numberOfPlayers >= 5)
        {
            PlayerPrefs.SetString("player5", lst[4]);
        }
        if(numberOfPlayers == 6)
        {
            PlayerPrefs.SetString("player6", lst[5]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playersSelected == numberOfPlayers){
            //PlayerPrefs.SetString("Player1", );
            setPrefs(selected);
            SceneManager.LoadScene("MainGame");
        }
        inputAvailable--;

        if (inputAvailable <= 0)
        {
            if (Input.GetAxis("Horizontal") > .5 && place < 5)
            {
                    pos.x += moveAmount;
                    inputAvailable = 20;
                    place++;
            }

            else if (Input.GetAxis("Horizontal") < -.5 && place > 0)
            {
                    pos.x -= moveAmount;
                    inputAvailable = 20;
                    place--;
            }
        }
        selection.transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Player selected
            if (selected.Contains(all[place]))
            {
                print("This player has already been selected");
            }
            else
            {
                playersSelected++;
                selected.Add(all[place]);
                //Instantiate(lockPrefab, barrelEnd.position, barrelEnd.rotation);
                GameObject lockP = Instantiate(lockPrefab, 
                                               new Vector3(lockPositions[place], xValue, 0), 
                                               Quaternion.identity) as GameObject;
                //Instantiate the lock
                //x = xValue;
                //y = lockPositions[place]
            }
        }
    }
}
