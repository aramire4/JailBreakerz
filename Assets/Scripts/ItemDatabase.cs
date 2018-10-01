using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour{
    public List<Item> itemDatabase = new List<Item>();

    public List<Item> infirmaryDatabase = new List<Item>();
    public List<Item> armoryDatabase = new List<Item>();
    public List<Item> visitorCenterDatabase = new List<Item>();
    public List<Item> yardDatabase = new List<Item>();
    public List<Item> libraryDatabase = new List<Item>();
    public List<Item> kitchenDatabase = new List<Item>();

    public List<Item> wardenOfficeDatabase = new List<Item>();
    //public Stack<Item> infirmaryDatabase = new Stack<Item>();


    // Use this for initialization
    void Start () {
        //apple
        Item apple = new Item();
        apple.identifier = 1;
        apple.itemName = "Apple";
        apple.description = "Use this item to avoid going to the infirmary once";
        apple.location = "kitchen";
        apple.type = "food";
        apple.use = "counter"; //uses: counter, self, other, stat, move
        itemDatabase.Add(apple);
        //itemDatabase.Add(apple);
        //TODO-add item to it's specific database

	}
	
    public List<Item> getItemDatabase(){
        return itemDatabase;
    }

    public List<Item> getDatabaseFromPosition(float x, float y){
        return null;
        //TODO
    }

    public Item drawAndRemove(List<Item> database){
        //Check if databse is empty
        if(database.Count == 0){
            //print("There are no cards left");
            return null;
        }
        System.Random rnd = new System.Random();
        Item ret = database[rnd.Next(database.Count)];
        database.Remove(ret);
        return ret;
    }

    public Item GetItem(int identifier){
        for (int i = 0; i < itemDatabase.Count; i++){
            if(itemDatabase[i].identifier == identifier){
                return itemDatabase[i];
            }
        }
        return null;
    }

    public void returnItem(Item item){
        if(item.location == "infirmary"){
            infirmaryDatabase.Add(item);
        }
        else if(item.location == "armory"){
            armoryDatabase.Add(item);
        }
        else if(item.location == "visitor"){
            visitorCenterDatabase.Add(item);
        }
        else if (item.location == "yard")
        {
            yardDatabase.Add(item);
        }
        else if (item.location == "library")
        {
            libraryDatabase.Add(item);
        }
        else if (item.location == "kitchen")
        {
            kitchenDatabase.Add(item);
        }
    }

    public void putItemInWardens(Item item){
        wardenOfficeDatabase.Add(item);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
