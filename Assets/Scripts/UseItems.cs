using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItems : MonoBehaviour {

    public bool CanUseItem(Item item, Vector2 pos)
    {
        if (item.identifier == 9 || item.identifier == 13)
        {
            return (CheckForPlayers1(pos));
        }
        else if (item.identifier == 7)
        {
            return (CheckForPlayers2(pos));
        }
        else if (item.identifier == 15 || item.identifier == 14 || item.identifier == 21)
        {
                return true;
        }
        else
        {
            return false;
            //could not use the item
        }
        //TODO item.identifier == 5 will be prompted for when you try to search
    }
   
    public void UseItem(Item item, Vector2 pos)
    {
        //TODO- instantiate weapons used
        if (item.identifier == 9 || item.identifier == 13 || item.identifier == 7 || item.identifier == 21)
        {
            UseWeapon(item, pos);
        }
        else if (item.identifier == 15)
        {
            //TODO
            //distraction
            UseDistraction(item);
            RemoveSingleItem(GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState(), item);
        }
        else if (item.identifier == 14)
        {
            //move current player to infirmary
            //mystery meat
            GameObject.Find("Fighting").GetComponent<Fight>().MoveInfirmaryInstant(
                GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState());

            RemoveSingleItem(GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState(), item);
        }
        else print("Cannot use this item");

    }


    public void UseWeapon(Item item, Vector2 pos)
    {
        if (item.identifier == 21)
        {
            //any range
            //no counters at all
            //TODO canvas to select players

        }
        else if (item.identifier == 7)
        {
            //2 range
            //no counters except infirmary
            GameObject otherPlayer = SelectPlayerToAttack2(pos);
            //TODO-check to see if other person has an appropriate counter
            GameObject.Find("Fighting").GetComponent<Fight>().
                      WhoWins(GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState(), item, otherPlayer);
        }
        else
        {
            //select player to attack
            GameObject otherPlayer = SelectPlayerToAttack1(pos);
            GameObject.Find("Fighting").GetComponent<Fight>().
                      WhoWins(GameObject.Find("StateMachine").GetComponent<GameState>().GetObjectFromState(), item, otherPlayer);
            //prompt other player to see if they have a weapon

            //TODO have a selector to choose the player to attack in update of UseItems
            //cancel canvas movement && deactivate canvas while this is happening
            //after it is done pull up canvas

        }
    }

    public void UseDistraction(Item item)
    {
        if(item.location == "visitor center"){
            //move warden to a visitor center position
            GameObject guard = GameObject.Find("GuardState").GetComponent<GuardStates>().GetRandomGuard();
            guard.transform.position = HazardMovement.getRandomGuardPoint(HazardMovement.visitorCenter);
            guard.GetComponent<GuardMovement>().pos = guard.transform.position;
            guard.GetComponent<GuardMovement>().resetPosition = guard.transform.position;
        }
        else if(item.location == "infirmary")
        {
            //move warden to a infirmary center position
            GameObject guard = GameObject.Find("GuardState").GetComponent<GuardStates>().GetRandomGuard();
            guard.transform.position = HazardMovement.getRandomGuardPoint(HazardMovement.infirmaryPoints2);
            guard.GetComponent<GuardMovement>().pos = guard.transform.position;
            guard.GetComponent<GuardMovement>().resetPosition = guard.transform.position;
        }
        else if (item.location == "kitchen")
        {
            //move warden to a kitchen position
            GameObject guard = GameObject.Find("GuardState").GetComponent<GuardStates>().GetRandomGuard();
            guard.transform.position = HazardMovement.getRandomGuardPoint(HazardMovement.kitchenPoints);
            guard.GetComponent<GuardMovement>().pos = guard.transform.position;
            guard.GetComponent<GuardMovement>().resetPosition = guard.transform.position;
        }

    }

    public bool HasCertainItem(GameObject player, int identifier)
    {
        for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
        {
            if (player.GetComponent<Player>().heldItems[i].identifier == identifier)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasItemType(GameObject player, string type)
    {
        for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
        {
            if (player.GetComponent<Player>().heldItems[i].type == type)
            {
                return true;
            }
        }
        return false;
    }
    /*
    public void UseCounterItem(Item item, Vector2 pos)
    {
        if(item.identifier == 1 || item.identifier == 2)
        {
            //no infirmary
        }
        else if (item.identifier == 4)
        {
            //counter warden
        }
    }*/

    public Item CounterWeapon1(GameObject player)
    {

        //TODO-instantiate item2
        if (HasBattleCancel(player))
        {
            for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
            {
                if (player.GetComponent<Player>().heldItems[i].identifier == 6)
                {
                    return player.GetComponent<Player>().heldItems[i];
                }
            }
        }

        else if (HasMeeleeWeapon(player))
        {
            for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
            {
                if (player.GetComponent<Player>().heldItems[i].identifier == 9 ||
                   player.GetComponent<Player>().heldItems[i].identifier == 13)
                {
                    return player.GetComponent<Player>().heldItems[i];
                }
            }
        }

        else if (HasRangedWeapon(player))
        {
            for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
            {
                if (player.GetComponent<Player>().heldItems[i].identifier == 7 ||
                   player.GetComponent<Player>().heldItems[i].identifier == 21)
                {
                    return player.GetComponent<Player>().heldItems[i];
                }
            }
        }

        /*
        else if(HasHealthItem(player))
        {
            //find the first health item
            for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
            {
                if (CanUseHealthItem(player.GetComponent<Player>().heldItems[i]))
                {
                    return player.GetComponent<Player>().heldItems[i];
                }
            }
        }*/
            /*
            if (itm.identifier == 9 || itm.identifier == 13) return itm;
            //melee weapons
            else if (itm.identifier == 7 || itm.identifier == 21) return itm;
            //ranged weapons
            else if (itm.identifier == 6) return itm;
            else if (itm.identifier == 1 || itm.identifier == 2) return itm;
            */
        return null;
    }

    public bool HasMeeleeWeapon(GameObject player)
    {
        bool ret = false;
        for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
        {
            Item itm = player.GetComponent<Player>().heldItems[i];
            if (itm.identifier == 9 || itm.identifier == 13)
            {
                ret = true;
            }
        }
        return ret;
    }

    public bool HasRangedWeapon(GameObject player)
    {
        bool ret = false;
        for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
        {
            Item itm = player.GetComponent<Player>().heldItems[i];
            if (itm.identifier == 7 || itm.identifier == 21)
            {
                ret = true;
            }
        }
        return ret;
    }

    public bool HasBattleCancel(GameObject player)
    {
        bool ret = false;
        for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
        {
            Item itm = player.GetComponent<Player>().heldItems[i];
            if (itm.identifier == 6)
            {
                ret = true;
            }
        }
        return ret;
    }

    public bool HasCounterItem(GameObject player)
    {
        bool ret = false;
        for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
        {
            if (CanUseCounterItem(player.GetComponent<Player>().heldItems[i]))
            {
                ret = true;
            }
        }
        return ret;
    }

    public bool HasHealthItem(GameObject player)
    {
        bool ret = false;
        for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
        {
            if (CanUseHealthItem(player.GetComponent<Player>().heldItems[i]))
            {
                ret = true;
            }
        }
        return ret;
    }

    public void UseHealthItem(GameObject player)
    {
        //uses the first health item in an inventory
        for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
        {
            if (CanUseHealthItem(player.GetComponent<Player>().heldItems[i]))
            {
                Item itm = player.GetComponent<Player>().heldItems[i];
                player.GetComponent<Player>().heldItems.Remove(itm);
                GameObject.Find("Item").GetComponent<ItemDatabase>().ReturnItem(itm);
                i = player.GetComponent<Player>().heldItems.Count+1;
                //TODO-check to see if this exits the loop
            }
        }
    }

    public bool HasDonut(GameObject player)
    {
        bool ret = false;
        for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
        {
            if (player.GetComponent<Player>().heldItems[i].identifier == 4)
            {
                ret = true;
            }
        }
        return ret;
    }

    public Item ReturnDonut(GameObject player)
    {
        for (int i = 0; i < player.GetComponent<Player>().heldItems.Count; i++)
        {
            if (player.GetComponent<Player>().heldItems[i].identifier == 4)
            {
                return player.GetComponent<Player>().heldItems[i];
            }
        }
        return null;
    }

    public void EncounterWarden(float x, float y)
    {
        //send player to solitary and take an item unless they have a donut
        GameObject player = GameController.ReturnPlayer(x, y);
        if (HasDonut(player) == false)
        {
            player.transform.position = HazardMovement.getRandomSolitaryPoint();
            player.GetComponent<PlayerMovement>().pos = player.transform.position;
            player.GetComponent<PlayerMovement>().resetPosition = player.transform.position;
            //Move player to solitary
            Item itm = GameObject.Find("Items").GetComponent<ItemDatabase>().drawAndRemove(
                player.GetComponent<Player>().heldItems);
            //put an item in warden office
            GameObject.Find("Items").GetComponent<ItemDatabase>().PutItemInWardens(itm);
            print("Item has been sent to warden's office");
        }
        else
        {
            Item donut = ReturnDonut(player);
            RemoveSingleItem(player, donut);
            //remove donut
        }
    }

    public bool CanUseHealthItem(Item item)
    {
        if (item.identifier == 1 || item.identifier == 2)
        {
            return true;
        }
        else return false;
    }

    public bool CanUseCounterItem(Item item)
    {
        if (item.identifier == 6 || item.identifier == 9 || item.identifier == 13 ||
            item.identifier == 7 || item.identifier == 21)
        {
            return true;
        }
        else return false;
    }


    public bool CheckForPlayers1 (Vector2 pos)
    {
        if((GameController.CheckForPlayer((pos.x - 1.28f), pos.y) == true) ||
           (GameController.CheckForPlayer((pos.x + 1.28f), pos.y) == true) ||
           (GameController.CheckForPlayer(pos.x, pos.y + 1.28f) == true) ||
           (GameController.CheckForPlayer(pos.x, pos.y - 1.28f) == true))
        {
            return true;
        }
        else return false;
    }

    public bool CheckForPlayers2(Vector2 pos)
    {
        if ((GameController.CheckForPlayer((pos.x - 2.56f), pos.y) == true) ||
           (GameController.CheckForPlayer((pos.x + 2.56f), pos.y) == true) ||
           (GameController.CheckForPlayer(pos.x, pos.y + 2.56f) == true) ||
           (GameController.CheckForPlayer(pos.x, pos.y - 2.56f) == true))
        {
            return true;
        }
        else return false;
    }

    public GameObject SelectPlayerToAttack1(Vector2 pos)
    {
        print("Select a player to attack");
        GameObject other = null;
        //only selects players next to you
        //TODO fix to select the first player to the right, down, left, or up of pos


        if (GameController.CheckForPlayer(pos.x + 1.28f, pos.y) == true)
        {
            //attack player right
            other = GameController.ReturnPlayer(pos.x + 1.28f, pos.y);
        }
        else if (GameController.CheckForPlayer(pos.x, pos.y - 1.28f) == true)
        {
            //attack player down
            other = GameController.ReturnPlayer(pos.x, pos.y - 1.28f);
        }

        else if (GameController.CheckForPlayer(pos.x - 1.28f, pos.y) == true)
        {
            //attack player left
            other = GameController.ReturnPlayer(pos.x - 1.28f, pos.y);
        }
        else if (GameController.CheckForPlayer(pos.x, pos.y + 1.28f) == true)
        {
            //attack player up
            other = GameController.ReturnPlayer(pos.x, pos.y + 1.28f);
        }
        return other;
    }

    public GameObject SelectPlayerToAttack2(Vector2 pos)
    {
        print("Select a player to attack");
        GameObject other = null;
        //only selects players next to you
        //TODO fix to select the first player to the right, down, left, or up of pos


        if (GameController.CheckForPlayer(pos.x + 2.56f, pos.y) == true)
        {
            //attack player right
            other = GameController.ReturnPlayer(pos.x + 2.56f, pos.y);
        }
        else if (GameController.CheckForPlayer(pos.x, pos.y - 2.56f) == true)
        {
            //attack player down
            other = GameController.ReturnPlayer(pos.x, pos.y - 2.56f);
        }

        else if (GameController.CheckForPlayer(pos.x - 2.56f, pos.y) == true)
        {
            //attack player left
            other = GameController.ReturnPlayer(pos.x - 2.56f, pos.y);
        }
        else if (GameController.CheckForPlayer(pos.x, pos.y + 2.56f) == true)
        {
            //attack player up
            other = GameController.ReturnPlayer(pos.x, pos.y + 2.56f);
        }
        return other;

    }

    public void RemoveSingleItem(GameObject player1, Item item1)
    {
        if (item1 != null)
        {
            player1.GetComponent<Player>().heldItems.Remove(item1);
            GameObject.Find("Items").GetComponent<ItemDatabase>().ReturnItem(item1);
        }
    }

        // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
