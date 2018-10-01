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

    public List<string> all = new List<string>(new string[] { 
        "red", "green", "yellow", "brown", "purple", "blue" 
    });

    public float xValue = -3.14f;

    public List<float> lockPositions = new List<float>(new float[]{
        -6.6f, -4.01f, -1.33f, 3.35f, 4f, 6.62f
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

    // Update is called once per frame
    void Update()
    {
        if(playersSelected == numberOfPlayers){
            //PlayerPrefs.SetString("Player1", );
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
                //Instantiate the lock
                //x = xValue;
                //y = lockPositions[place]
            }
        }
    }
}
