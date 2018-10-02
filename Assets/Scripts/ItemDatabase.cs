using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ItemDatabase : MonoBehaviour{
    public static List<Item> itemDatabase = new List<Item>();

    public static List<Item> infirmaryDatabase = new List<Item>();
    public static List<Item> armoryDatabase = new List<Item>();
    public static List<Item> visitorCenterDatabase = new List<Item>();
    public static List<Item> yardDatabase = new List<Item>();
    public static List<Item> libraryDatabase = new List<Item>();
    public static List<Item> kitchenDatabase = new List<Item>();
    public static List<Item> showerDatabase = new List<Item>();
    public int totalLuck = 10;

    public static List<Item> wardenOfficeDatabase = new List<Item>();
    //public Stack<Item> infirmaryDatabase = new Stack<Item>();

    public List<Vector2> triggerPoints = new List<Vector2>(new Vector2[] {
        new Vector2(-19.582f, -0.7449999f)/*infirmary*/,
        new Vector2(-18.302f, -4.585f)/*visitor center*/,
        new Vector2(-18.302f, -7.145f)/*visitor center*/,
        new Vector2(-9.342001f, -3.305f)/*yard*/,
        new Vector2(-2.942002f, -3.305f)/*shower*/,
        new Vector2(3.457998f, -7.145f)/*kitchen*/,
        new Vector2(13.698f, -4.585f)/*warden*/,
        new Vector2(13.698f, -16.105f)/*armory*/,
        new Vector2(-18.302f, -16.105f)/*library*/
    });

    public List<List<Item>> db = new List<List<Item>>(new List<Item>[] {
        infirmaryDatabase, visitorCenterDatabase, visitorCenterDatabase, yardDatabase,
        showerDatabase, kitchenDatabase, wardenOfficeDatabase, armoryDatabase, libraryDatabase
    });

    // Use this for initialization
    void Start () {
        //TODO-uses: counter, self, other, stat, move, none
        loadKitchenDatabase();
        loadInfirmaryDatabase();
        loadLibraryDatabase();
        loadVisitorCenterDatabase();
        loadArmoryDatabase();
        loadYardDatabase();
        loadShowerDatabase();
    }


    public List<Item> getItemDatabase(){
        return itemDatabase;
    }

    public List<Item> getDatabaseFromPosition(float x, float y){
        for (int i = 0; i < triggerPoints.Count; i++)
            {
            if (Math.Abs(triggerPoints[i].x - x) <= 0.5
                && Math.Abs(triggerPoints[i].y - y) <= 0.5)
                {
                    return db[i];
                }
            }
            return null;
        //return null;
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

    public void loadKitchenDatabase()
    {
        //apple
        Item apple = new Item();
        apple.identifier = 1;
        apple.itemName = "Apple";
        apple.description = "Use this item to avoid going to the infirmary once";
        apple.location = "kitchen";
        apple.type = "food";
        apple.use = "counter";
        apple.rare = false;
        apple.range = 0;
        for (int i = 0; i < 3; i++) { kitchenDatabase.Add(apple); }

        Item breadKnife = new Item();
        breadKnife.identifier = 9;
        breadKnife.itemName = "Knife";
        breadKnife.description = "Use this item to sent a player next to you to the infirmary (range 1)";
        breadKnife.location = "kitchen";
        breadKnife.type = "weapon";
        breadKnife.use = "other";
        breadKnife.rare = false;
        breadKnife.range = 1;
        for (int i = 0; i < 2; i++) { kitchenDatabase.Add(breadKnife); }

        Item mysteryMeat = new Item();
        mysteryMeat.identifier = 14;
        mysteryMeat.itemName = "Mystery Meat";
        mysteryMeat.description = "Use this item to send yourself to the infirmary";
        mysteryMeat.location = "kitchen";
        mysteryMeat.type = "food";
        mysteryMeat.use = "self";
        mysteryMeat.rare = false;
        mysteryMeat.range = 0;
        for (int i = 0; i < 3; i++){ kitchenDatabase.Add(mysteryMeat); }

        Item kitchenRiot = new Item();
        kitchenRiot.identifier = 15;
        kitchenRiot.itemName = "Kitchen Riot";
        kitchenRiot.description = "Use this item to send a warden to the kitchen";
        kitchenRiot.location = "kitchen";
        kitchenRiot.type = "distraction";
        kitchenRiot.use = "other";
        kitchenRiot.rare = true;
        kitchenDatabase.Add(kitchenRiot);

        Item spoon = new Item();
        spoon.identifier = 18;
        spoon.itemName = "Spoon";
        spoon.description = "This item has no use";
        spoon.location = "kitchen";
        spoon.type = "none";
        spoon.use = "none";
        spoon.rare = false;
        spoon.range = 0;
        for (int i = 0; i < 3; i++){ kitchenDatabase.Add(spoon); }
    }

    public void loadInfirmaryDatabase(){
        Item bandages = new Item();
        bandages.identifier = 2;
        bandages.itemName = "Bandages";
        bandages.description = "Use this item to avoid going to the infirmary once";
        bandages.location = "infirmary";
        bandages.type = "none";
        bandages.use = "counter";
        bandages.rare = false;
        bandages.range = 0;
        for (int i = 0; i < 3; i++){ infirmaryDatabase.Add(bandages); }

        Item lollipop = new Item();
        lollipop.identifier = 10;
        lollipop.itemName = "Lollipop";
        lollipop.description = "You were a good patient in your last doctor's visit";
        lollipop.location = "infirmary";
        lollipop.type = "food";
        lollipop.use = "none";
        lollipop.rare = false;
        lollipop.range = 0;
        for (int i = 0; i < 3; i++){ infirmaryDatabase.Add(lollipop); }

        Item shiv = new Item();
        shiv.identifier = 13;
        shiv.itemName = "Shiv";
        shiv.description = "Use this item to sent a player next to you to the infirmary (range 1)";
        shiv.location = "infirmary";
        shiv.type = "weapon";
        shiv.use = "other";
        shiv.rare = false;
        shiv.range = 1;
        for (int i = 0; i < 3; i++){ infirmaryDatabase.Add(shiv); }

        Item infirmaryRiot = new Item();
        infirmaryRiot.identifier = 15;
        infirmaryRiot.itemName = "Infirmary Riot";
        infirmaryRiot.description = "Use this item to send a warden to the infirmary";
        infirmaryRiot.location = "infirmary";
        infirmaryRiot.type = "distraction";
        infirmaryRiot.use = "other";
        infirmaryRiot.rare = true;
        kitchenDatabase.Add(infirmaryRiot);
    }

    public void loadLibraryDatabase()
    {
        Item book = new Item();
        book.identifier = 3;
        book.itemName = "Book";
        book.description = "Nice reading material to help pass the time in jail";
        book.location = "library";
        book.type = "none";
        book.use = "none";
        book.rare = false;
        book.range = 0;
        for (int i = 0; i < 2; i++){ libraryDatabase.Add(book); }

        Item cut = new Item();
        cut.identifier = -1;
        cut.itemName = "Get a paper cut";
        cut.description = "Go to the infirmary";
        cut.location = "library";
        cut.type = "hazard";
        cut.use = "move";
        cut.rare = false;
        cut.range = 0;
        for (int i = 0; i < 4; i++){ libraryDatabase.Add(cut); }

        Item smarts1 = new Item();
        smarts1.identifier = 0;
        smarts1.itemName = "+1 Smarts";
        smarts1.description = "Add 1 to your smarts";
        smarts1.location = "library";
        smarts1.type = "smarts";
        smarts1.use = "stat";
        smarts1.rare = false;
        smarts1.range = 0;
        for (int i = 0; i < 4; i++){ libraryDatabase.Add(smarts1); }

        Item smarts2 = new Item();
        smarts2.identifier = 0;
        smarts2.itemName = "+2 Smarts";
        smarts2.description = "Add 2 to your smarts";
        smarts2.location = "library";
        smarts2.type = "smarts";
        smarts2.use = "stat";
        smarts2.rare = true;
        smarts2.range = 0;
        libraryDatabase.Add(smarts2);
    }

    public void loadVisitorCenterDatabase()
    {
        Item book = new Item();
        book.identifier = 3;
        book.itemName = "Book";
        book.description = "Nice reading material to help pass the time in jail";
        book.location = "visitor center";
        book.type = "none";
        book.use = "none";
        book.rare = false;
        book.range = 0;
        for (int i = 0; i < 2; i++){ visitorCenterDatabase.Add(book); }

        Item flowers = new Item();
        flowers.identifier = 6;
        flowers.itemName = "Flowers";
        flowers.description = "Make someone next to you lost a turn (range 1)";
        flowers.location = "visitor center";
        flowers.type = "none";
        flowers.use = "other";
        flowers.rare = false;
        flowers.range = 1;
        for (int i = 0; i < 2; i++){ visitorCenterDatabase.Add(flowers); }

        Item key = new Item();
        key.identifier = 8;
        key.itemName = "Key";
        key.description = "Unlocks the front door";
        key.location = "visitor center";
        key.type = "none";
        key.use = "none";
        key.rare = false;
        key.range = 0;
        for (int i = 0; i < 2; i++){ visitorCenterDatabase.Add(key); }

        Item knife = new Item();
        knife.identifier = 9;
        knife.itemName = "Knife";
        knife.description = "Use this item to sent a player next to you to the infirmary (range 1)";
        knife.location = "visitor center";
        knife.type = "weapon";
        knife.use = "other";
        knife.rare = false;
        knife.range = 1;
        for (int i = 0; i < 2; i++){ visitorCenterDatabase.Add(knife); }

        Item visitorCenterRiot = new Item();
        visitorCenterRiot.identifier = 15;
        visitorCenterRiot.itemName = "Visitor Center Riot";
        visitorCenterRiot.description = "Use this item to send a warden to the visitor center";
        visitorCenterRiot.location = "visitor cneter";
        visitorCenterRiot.type = "distraction";
        visitorCenterRiot.use = "other";
        visitorCenterRiot.rare = true;
        visitorCenterDatabase.Add(visitorCenterRiot);

        Item phone = new Item();
        phone.identifier = -2;
        phone.itemName = "On the phone for too long";
        phone.description = "Go to solitary";
        phone.location = "visitor center";
        phone.type = "hazard";
        phone.use = "move";
        phone.rare = false;
        phone.range = 0;
        for (int i = 0; i < 3; i++){ visitorCenterDatabase.Add(phone); }
    }

    public void loadArmoryDatabase(){
        Item donut = new Item();
        donut.identifier = 4;
        donut.itemName = "Donut";
        donut.description = "Use this item to make a player next to you lose a turn (range 1)";
        donut.location = "armory";
        donut.type = "food";
        donut.use = "other";
        donut.rare = false;
        donut.range = 1;
        for (int i = 0; i < 2; i++){ armoryDatabase.Add(donut); }

        Item flashLight = new Item();
        flashLight.identifier = 5;
        flashLight.itemName = "Donut";
        flashLight.description = "Use this item to avoid losing a turn";
        flashLight.location = "armory";
        flashLight.type = "none";
        flashLight.use = "counter";
        flashLight.rare = false;
        flashLight.range = 0;
        for (int i = 0; i < 4; i++){ armoryDatabase.Add(flashLight); }

        Item gun = new Item();
        gun.identifier = 5;
        gun.itemName = "Donut";
        gun.description = "Use this item to send someone near you to the infirmary (range 2)";
        gun.location = "armory";
        gun.type = "weapon";
        gun.use = "other";
        gun.rare = false;
        gun.range = 2;
        for (int i = 0; i < 3; i++){ armoryDatabase.Add(gun); }

        Item key = new Item();
        key.identifier = 8;
        key.itemName = "Key";
        key.description = "Unlocks the front door";
        key.location = "armory";
        key.type = "none";
        key.use = "none";
        key.rare = false;
        key.range = 0;
        for (int i = 0; i < 2; i++){ armoryDatabase.Add(key); }

        Item sniper = new Item();
        sniper.identifier = 21;
        sniper.itemName = "Sniper";
        sniper.description = "Send anyone on the board to the infirmary (range infinite)";
        sniper.location = "armory";
        sniper.type = "weapon";
        sniper.use = "other";
        sniper.rare = true;
        sniper.range = -1;
        armoryDatabase.Add(sniper);

        Item caught = new Item();
        caught.identifier = -2;
        caught.itemName = "Get caught";
        caught.description = "Go to solitary";
        caught.location = "armory";
        caught.type = "hazard";
        caught.use = "move";
        caught.rare = false;
        caught.range = 0;
        for (int i = 0; i < 3; i++){ armoryDatabase.Add(caught); }
    }

    public void loadYardDatabase(){
        Item flowers = new Item();
        flowers.identifier = 6;
        flowers.itemName = "Flowers";
        flowers.description = "Make someone next to you lost a turn (range 1)";
        flowers.location = "visitor center";
        flowers.type = "none";
        flowers.use = "other";
        flowers.rare = false;
        flowers.range = 1;
        for (int i = 0; i < 2; i++){ yardDatabase.Add(flowers); }

        Item pull = new Item();
        pull.identifier = -1;
        pull.itemName = "Pulled a Muscle";
        pull.description = "Go to the infirmary";
        pull.location = "yard";
        pull.type = "hazard";
        pull.use = "move";
        pull.rare = false;
        pull.range = 0;
        for (int i = 0; i < 4; i++){ yardDatabase.Add(pull); }

        Item strength1 = new Item();
        strength1.identifier = 0;
        strength1.itemName = "+1 Strength";
        strength1.description = "Add 1 to your strength";
        strength1.location = "yard";
        strength1.type = "strength";
        strength1.use = "stat";
        strength1.rare = false;
        strength1.range = 0;
        for (int i = 0; i < 4; i++){ yardDatabase.Add(strength1); }

        Item strength2 = new Item();
        strength2.identifier = 0;
        strength2.itemName = "+2 Strength";
        strength2.description = "Add 2 to your strength";
        strength2.location = "yard";
        strength2.type = "strength";
        strength2.use = "stat";
        strength2.rare = true;
        strength2.range = 0;
        yardDatabase.Add(strength2);
    }

    public void loadShowerDatabase(){
        Item slip = new Item();
        slip.identifier = -1;
        slip.itemName = "Slip in the Shower";
        slip.description = "Go to the infirmary";
        slip.location = "shower";
        slip.type = "hazard";
        slip.use = "move";
        slip.rare = false;
        slip.range = 0;
        for (int i = 0; i < 4; i++){ showerDatabase.Add(slip); }

        Item looks1 = new Item();
        looks1.identifier = 0;
        looks1.itemName = "+1 looks";
        looks1.description = "Add 1 to your looks";
        looks1.location = "shower";
        looks1.type = "looks";
        looks1.use = "stat";
        looks1.rare = false;
        looks1.range = 0;
        for (int i = 0; i < 4; i++){ showerDatabase.Add(looks1); }

        Item looks2 = new Item();
        looks2.identifier = 0;
        looks2.itemName = "+2 looks";
        looks2.description = "Add 2 to your looks";
        looks2.location = "shower";
        looks2.type = "looks";
        looks2.use = "stat";
        looks2.rare = true;
        looks2.range = 0;
        showerDatabase.Add(looks2);
    }

}
