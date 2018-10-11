using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item{

    public int identifier;
    public string itemName = "";
    public string description = "";
    public string location = "";
    public string type = ""; //TODO - types: weapon, food, distraction, stall, none
    public string use = ""; //TODO-uses: counter, self, other, stat, move, none
    public bool rare;
    public int range;

}
