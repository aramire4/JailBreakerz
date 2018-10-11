using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour {
    public GameObject decisionCanvas;
    //TODO-check why canvas isn't working
    //GameObject.Find("InventoryCanvas");

    public void WhoWins(GameObject player1, Item item1, GameObject player2)
    {
        GameObject winner = null;
        GameObject loser = null;
        Item item2 = null;
        //TODO change to be simpler

        //see if player 2 wants to use an item
        //GameObject.Find("InventoryCanvas");
        //TODO change hasCounterItem to be applicable to a long ranged weapon
        if (item1.identifier == 21 || item1.identifier == 7)
        {
            if(item1.identifier == 21)
            {
                RemoveItemsUsed(player1, player2, item1, item2);
                MoveInfirmaryInstant(player2);
                WinnerReward(player1, player2);
            }
            else if (item1.identifier == 7)
            {
                RemoveItemsUsed(player1, player2, item1, item2);
                MoveToInfirmary(player2);
                WinnerReward(player1, player2);
            }
        }
        else
        {
            if (player2.GetComponent<Player>().heldItems.Count > 0 &&
                GameObject.Find("Items").GetComponent<UseItems>().HasCounterItem(player2))
            {
                item2 = GameObject.Find("Items").GetComponent<UseItems>().CounterWeapon1(player2);
            }
            //TODO-check for when player1 doesn't use an item and player2 does
            if (item2 != null)
            {
                if (item2.identifier == 6)
                {
                    RemoveItemsUsed(player1, player2, item1, item2);
                    return;
                    //end fight
                }
                else if (item2.identifier == 21)
                {
                    //send player1 to infirmary
                    RemoveItemsUsed(player1, player2, item1, item2);
                    MoveInfirmaryInstant(player1);
                }

                else if (item2.range == 2 && item1.range < 2)
                {
                    winner = player2;
                    loser = player1;
                    RemoveItemsUsed(player1, player2, item1, item2);
                    MoveToInfirmary(player1);
                    WinnerReward(player2, player1);
                }

                else if (item1.range == item2.range || (item1 != null && item2 != null))
                {
                    winner = CompareStrength(player1, player2);
                    RemoveItemsUsed(player1, player2, item1, item2);
                    if (winner == null)
                    {
                        MoveToInfirmary(player1);
                        MoveToInfirmary(player2);
                    }
                    else if (winner == player1)
                    {
                        loser = player2;
                        MoveToInfirmary(loser);
                        WinnerReward(winner, loser);
                    }
                    else if (winner == player2)
                    {
                        loser = player1;
                        MoveToInfirmary(loser);
                        WinnerReward(winner, loser);
                    }

                }

            }
            else if (item2 == null)
            {
                RemoveItemsUsed(player1, player2, item1, item2);
                MoveToInfirmary(player2);
                WinnerReward(player1, player2);
            }

        }
        //If neither player uses a weapon, compare strength
        //If one player uses a weapon and the other doesn't then the weapon-less player loses, unless the difference in strength is > 7
        //If both players use weapons of the same range, compare strength

    }


    public void MoveInfirmaryInstant(GameObject player)
    {
        player.transform.position = HazardMovement.getRandomInfirmaryPoint();
        player.GetComponent<PlayerMovement>().pos = player.transform.position;
        player.GetComponent<PlayerMovement>().resetPosition = player.transform.position;
    }

    public void MoveToInfirmary(GameObject player)
    {
        //TODO-check to see if the player has a usable item for this and then use it
        if (GameObject.Find("Items").GetComponent<UseItems>().HasHealthItem(player))
        {
            GameObject.Find("Items").GetComponent<UseItems>().UseHealthItem(player);
        }
        else
        {
            player.transform.position = HazardMovement.getRandomInfirmaryPoint();
            player.GetComponent<PlayerMovement>().pos = player.transform.position;
            player.GetComponent<PlayerMovement>().resetPosition = player.transform.position;
        }

    }

    public void RemoveItemsUsed(GameObject player1, GameObject player2, Item item1, Item item2)
    {
        if(item1 != null)
        {
            player1.GetComponent<Player>().heldItems.Remove(item1);
            GameObject.Find("Items").GetComponent<ItemDatabase>().ReturnItem(item1);
        }
        if(item2 != null){
            player2.GetComponent<Player>().heldItems.Remove(item2);
            GameObject.Find("Items").GetComponent<ItemDatabase>().ReturnItem(item2);
        }
    }

    public void TakeItem(GameObject winner, GameObject loser){
        //player2 takes an item from player1
        Item itm = GameObject.Find("Items").GetComponent<ItemDatabase>().drawAndRemove(
            loser.GetComponent<Player>().heldItems);
        if (winner.GetComponent<Player>().heldItems.Count < 4)
        {
            winner.GetComponent<Player>().heldItems.Add(itm);
        }
        else
        {
            GameObject.Find("Items").GetComponent<ItemDatabase>().PutItemInWardens(itm);
        }
    }

    public void WinnerReward(GameObject winner, GameObject loser)
    {
        //Check if you can take an item too
        if (CanTakeLuck(loser) && HasItems(loser))
        {
            //decisionCanvas.GetComponent<DecisionMakerBehavior>().ActivateDifferentChoice("Item", "Luck", "Which would you like?");
            System.Random rand = new System.Random();
            int r = rand.Next(0, 2);
            //if (decisionCanvas.GetComponent<DecisionMakerBehavior>().decision == 0)
            if (r == 0)
            {
                TakeItem(winner, loser);
            }
            else
            {
                TakeLuck(winner, loser);
            }
        }
        else
        {
            if (HasItems(loser)) TakeItem(winner, loser);
            else if (CanTakeLuck(loser)) TakeLuck(winner, loser);
            else return;
        }
    }

    public bool HasItems(GameObject player)
    {
        if (player.GetComponent<Player>().heldItems.Count > 0)
        {
            return true;
        }
        else return false;
    }

    public bool CanTakeLuck(GameObject player)
    {
        if (player.GetComponent<Player>().luck > 0) return true;
        else return false;
    }

    public void TakeLuck(GameObject winner, GameObject loser)
    {
        winner.GetComponent<Player>().luck += 1;
        loser.GetComponent<Player>().luck -= 1;
    }

    public GameObject CompareStrength(GameObject player1, GameObject player2)
    {
        if (player1.GetComponent<Player>().strength > player2.GetComponent<Player>().strength)
        {
            return player1;
        }
        else if (player1.GetComponent<Player>().strength < player2.GetComponent<Player>().strength)
        {
            return player2;
        }
        else return null;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
