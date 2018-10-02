using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardMovement : MonoBehaviour {

    public static List<Vector2> infirmaryPoints = new List<Vector2>(new Vector2[] {
        new Vector2(-19.582f, 4.375f), new Vector2(-19.582f, 3.095f),
        new Vector2(-17.022f, 4.375f), new Vector2(-17.022f, 3.095f),
        new Vector2(-14.462f, 4.375f), new Vector2(-14.462f, 3.095f),
        new Vector2(-11.902f, 4.375f), new Vector2(-11.902f, 3.095f)
    });

    public static List<Vector2> solitaryPoints = new List<Vector2>(new Vector2[] {
        new Vector2(14.978f, 4.375f), new Vector2(14.978f, 3.095f),
        new Vector2(13.698f, 4.375f), new Vector2(13.698f, 3.095f),
        new Vector2(12.418f, 4.375f), new Vector2(12.418f, 3.095f)
    });

    public static Vector2 getRandomInfirmaryPoint(){
        System.Random rnd = new System.Random();

        Vector2 ret = infirmaryPoints[rnd.Next(infirmaryPoints.Count)];
        if (GameController.CheckForPlayer(ret.x, ret.y) == true) { ret = getRandomInfirmaryPoint(); }
        return ret;
    }

    public static Vector2 getRandomSolitaryPoint()
    {
        System.Random rnd = new System.Random();
        Vector2 ret = solitaryPoints[rnd.Next(solitaryPoints.Count)];
        if (GameController.CheckForPlayer(ret.x, ret.y) == true) { ret = getRandomSolitaryPoint(); }
        return ret;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
