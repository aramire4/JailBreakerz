using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase{
    public List<Item> itemDatabase = new List<Item>();

    public List<Item> infirmaryDatabase = new List<Item>();
    public List<Item> armoryDatabase = new List<Item>();
    public List<Item> visitorCenter = new List<Item>();
    public List<Item> yardDatabase = new List<Item>();
    public List<Item> libraryDatabase = new List<Item>();

    public List<Item> wardenOfficeDatabase = new List<Item>();
    //public Stack<Item> infirmaryDatabase = new Stack<Item>();


    // Use this for initialization
    void Start () {
        //apple
        Item apple = new Item();
        apple.identifier = 1;
        apple.itemName = "Apple";
        apple.description = "Use this item to avoid going to the infirmary once";
        itemDatabase.Add(apple);
        //TODO-add item to it's specific database

	}
	
    public Item GetItem(int identifier){
        for (int i = 0; i < itemDatabase.Count; i++){
            if(itemDatabase[i].identifier == identifier){
                return itemDatabase[i];
            }
        }
        return null;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
