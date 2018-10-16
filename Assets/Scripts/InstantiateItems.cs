using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateItems : MonoBehaviour {

    public void InstantiateItem(Item item, Vector2 pos)
    {
        print("here is your card");
        Sprite sprite = MatchSpriteWithItem(item);
        GameObject go = new GameObject();
        SpriteRenderer rend = go.AddComponent<SpriteRenderer>();
        rend.sprite = sprite;
        GameObject spawn = Instantiate(go,
                                       new Vector3(pos.x, pos.y, 0),
                                       Quaternion.identity) as GameObject;
        spawn.GetComponent<SpriteRenderer>().sortingOrder = 6;
        StartCoroutine("ShowCard");
        Destroy(spawn.gameObject, 3f);
        Destroy(go, 0f);
        //GameObject loadItem = Instantiate(sprite) as GameObject;
    }

    public IEnumerable ShowCard()
    {

        yield return new WaitForSeconds(3.1f);
    }

    public Sprite MatchSpriteWithItem(Item item)
    {
        Sprite ret;
        ret = Resources.Load<Sprite>("Items/Apple");
        if (item.identifier == 0)
        {
            //stat
            if(item.location == "yard")
            {
                if (item.rare == false) ret = Resources.Load<Sprite>("Stats/Strength-1");//+1 strength
                else ret = Resources.Load<Sprite>("Stats/Strength-2");//+2 strength
            }
            else if (item.location == "library")
            {
                if (item.rare == false) ret = Resources.Load<Sprite>("Stats/Smarts-1");//+1 smarts
                else ret = Resources.Load<Sprite>("Stats/Smarts-2");//+2 smarts
            }
            else if (item.location == "shower")
            {
                if (item.rare == false) ret = Resources.Load<Sprite>("Stats/Looks-1");//+1 looks
                else ret = Resources.Load<Sprite>("Stats/Looks-2");//+2 looks
            }
        }
        else if (item.identifier == -1)
        {
            //go to infirmary
            if(item.location == "yard")
            {
                //pull muscle sprite
                ret = Resources.Load<Sprite>("Hazards/PullMuscle");
            }
            else if(item.location == "library")
            {
                //paper cut sprite
                ret = Resources.Load<Sprite>("Hazards/PaperCut");
            }
            else if(item.location == "showers")
            {
                //slip sprite
                ret = Resources.Load<Sprite>("Hazards/Slip");
            }
        }
        else if(item.identifier == -2)
        {
            //go to solitary
            if(item.location == "visitor")
            {
                //on phone too long sprite
                ret = Resources.Load<Sprite>("Hazards/Phone");
            }
            else if (item.location == "armory")
            {
                //get caught sprite
                ret = Resources.Load<Sprite>("Hazards/GetCaught");
            }
        }
        else if (item.identifier == 1)
        {
            //return apple sprite
            ret = Resources.Load<Sprite>("Items/Apple");
        }
        else if (item.identifier == 2)
        {
            //return bandages sprite
            ret = Resources.Load<Sprite>("Items/Bandage");
        }
        else if (item.identifier == 3)
        {
            //return book sprite
            ret = Resources.Load<Sprite>("Items/Book");
        }
        else if (item.identifier == 4)
        {
            //return donut sprite
            ret = Resources.Load<Sprite>("Items/Donut");
        }
        else if (item.identifier == 5)
        {
            //return flashlight sprite
            ret = Resources.Load<Sprite>("Items/Flashlight");
        }
        else if (item.identifier == 6)
        {
            //return flowers sprite
            ret = Resources.Load<Sprite>("Items/Flower");
        }
        else if (item.identifier == 7)
        {
            //return gun sprite
            ret = Resources.Load<Sprite>("Items/Gun");
        }
        else if (item.identifier == 9)
        {
            if (item.location == "visitor") 
                ret = Resources.Load<Sprite>("Items/Knife-1");//return normal knife
            else if (item.location == "kitchen")
                ret = Resources.Load<Sprite>("Items/Knife-2");//return butter knife
        }
        else if(item.identifier == 10)
        {
            ret = Resources.Load<Sprite>("Items/Lollipop");//return lollipop sprite

        }
        else if (item.identifier == 13)
        {
            ret = Resources.Load<Sprite>("Items/Shiv");//return shiv sprite
        }
        else if (item.identifier == 14)
        {
            ret = Resources.Load<Sprite>("Items/MysteryMeat");//return mystery meat sprite
        }
        else if (item.identifier == 15)
        {
            //return riot sprite
            ret = Resources.Load<Sprite>("Items/Riot");
        }
        else if (item.identifier == 18)
        {
            //return spoon sprite
            ret = Resources.Load<Sprite>("Items/Spoon");
        }
        else if (item.identifier == 21)
        {
            //return sniper sprite
            ret = Resources.Load<Sprite>("Items/Sniper");
        }
        return ret;

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
