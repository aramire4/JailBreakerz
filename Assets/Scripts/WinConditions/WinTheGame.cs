using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class WinTheGame : MonoBehaviour {

    public static List<Vector2> secretary = new List<Vector2>(new Vector2[] {
        new Vector2(-9.342001f, -14.825f)
    });

    public static List<Vector2> door = new List<Vector2>(new Vector2[] {
        new Vector2(-1.662002f, -17.385f), new Vector2(-0.3820021f, -17.385f)
    });

    public static List<Vector2> hole = new List<Vector2>(new Vector2[] {
        new Vector2(-6.782001f, 4.375f), new Vector2(-1.662002f, 4.375f),
        new Vector2(3.457998f, 4.375f), new Vector2(8.577997f, 4.375f)
    });


    public void CheckExit(GameObject player)
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        if (CheckHole(x, y))
        {
            //Check if player meets conditions for hole escape
            if (HasNecessaryItems(player, 1))
            {
                //do dice challenge
                GameObject.Find("DiceRoller").GetComponent<DiceRoll>().RollFinalDice();
                if (DiceRoll.movement + player.GetComponent<Player>().luck >= 6)
                {
                    print("you escaped!");
                    //win the game
                    //SceneManager.LoadScene("");
                    //PlayerPrefs.SetString("winner", __)
                }
                else
                {
                    //move to solitary and lose items & luck
                    EscapeFailed(player);
                    //end turn?
                }
            }
            else print("you do not have necessary items");
        }
        else if (Math.Abs(secretary[0].x - x) <= 0.5
                 && Math.Abs(secretary[0].y - y) <= 0.5)
        {
            //check if player meets conditions for secretary escape
            if (HasNecessaryItems(player, 2))
            {
                //do dice challenge
                GameObject.Find("DiceRoll").GetComponent<DiceRoll>().RollFinalDice();
                if (DiceRoll.movement + player.GetComponent<Player>().luck >= 6)
                {
                    print("you escaped!");
                    //win the game
                    //SceneManager.LoadScene("");
                    //PlayerPrefs.SetString("winner", __)
                }
                else
                {
                    //move to solitary and lose items & luck
                    EscapeFailed(player);
                    //end turn?
                }
            }
            else print("you do not have necessary items");
        }
        else if (CheckDoor(x, y))
        {
            //check if player meets conditions for door escape
            if (HasNecessaryItems(player, 3))
            {
                //do dice challenge
                GameObject.Find("DiceRoll").GetComponent<DiceRoll>().RollFinalDice();
                if (DiceRoll.movement + player.GetComponent<Player>().luck >= 6)
                {
                    print("you escaped!");
                    //win the game
                    //SceneManager.LoadScene("");
                    //PlayerPrefs.SetString("winner", __)
                }
                else
                {
                    //move to solitary and lose items & luck
                    EscapeFailed(player);
                    //end turn?
                }
            }
            else print("you do not have necessary items");
        }
    }

    public bool HasNecessaryItems(GameObject player, int exit)
    {
        if(exit == 1)
        {
            //hole
            if (player.GetComponent<Player>().strength >= 3
                && player.GetComponent<Player>().intelligence >= 1
                && GameObject.Find("Items").GetComponent<UseItems>().HasCertainItem(player, 18)
                && GameObject.Find("Items").GetComponent<UseItems>().HasCertainItem(player, 5)
                && GameObject.Find("Items").GetComponent<UseItems>().HasItemType(player, "food")) return true;

        }
        else if(exit == 2)
        {
            //secretary
            if (player.GetComponent<Player>().looks >= 3
                && player.GetComponent<Player>().strength >= 1
                && GameObject.Find("Items").GetComponent<UseItems>().HasCertainItem(player, 3)
                && GameObject.Find("Items").GetComponent<UseItems>().HasCertainItem(player, 6)
                && GameObject.Find("Items").GetComponent<UseItems>().HasItemType(player, "food")) return true;

        }
        else if(exit == 3)
        {
            //door
            if (player.GetComponent<Player>().intelligence >= 3 
                && player.GetComponent<Player>().looks >= 1
                && GameObject.Find("Items").GetComponent<UseItems>().HasItemType(player, "distraction")
                && GameObject.Find("Items").GetComponent<UseItems>().HasCertainItem(player, 8)
                && GameObject.Find("Items").GetComponent<UseItems>().HasItemType(player, "weapon")) return true;
        }
        return false;
    }

    public static bool CheckDoor(float x, float y)
    {
        for (int i = 0; i < door.Capacity; i++)
        {
            if (Math.Abs(door[i].x - x) <= 0.5
                && Math.Abs(door[i].y - y) <= 0.5)
            {
                return true;//Check if player has items for hole
            }
        }
        return false;
    }

    public static bool CheckHole(float x, float y)
    {
        for (int i = 0; i < hole.Capacity; i++)
        {
            if (Math.Abs(hole[i].x - x) <= 0.5
                && Math.Abs(hole[i].y - y) <= 0.5)
            {
                return true;//Check if player has items for hole
            }
        }
        return false;
    }

    public void EscapeFailed(GameObject player)
    {
        //move to solitary and lose items & luck
        player.transform.position = HazardMovement.getRandomSolitaryPoint();
        player.GetComponent<PlayerMovement>().pos = player.transform.position;
        player.GetComponent<PlayerMovement>().resetPosition = player.transform.position;

        GameObject.Find("Items").GetComponent<ItemDatabase>().totalLuck += player.GetComponent<Player>().luck;
        player.GetComponent<Player>().luck -= player.GetComponent<Player>().luck;
        GameObject.Find("Items").GetComponent<ItemDatabase>().PlayerLost(player);
        print("your items have been sent to the warden's office");
        //end turn?
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
