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

    //For moving guards
    public static List<Vector2> infirmaryPoints2 = new List<Vector2>(new Vector2[] {
        new Vector2(-13.182f, -0.7449999f), new Vector2(-14.462f, -0.7449999f),
        new Vector2(-15.742f, -0.7449999f), new Vector2(-17.022f, -0.7449999f),
        new Vector2(-13.182f, 0.05350001f), new Vector2(-14.462f, 0.05350001f),
        new Vector2(-15.742f, 0.05350001f), new Vector2(-17.022f, 0.05350001f)
    });

    public static List<Vector2> kitchenPoints = new List<Vector2>(new Vector2[] {
        new Vector2(6.017999f, -5.865f), new Vector2(4.737999f, -9.704999f),
        new Vector2(3.457999f, -9.704999f), new Vector2(7.297999f, -4.585f),
        new Vector2(0.897999f, -8.424999f), new Vector2(6.017999f, -9.704999f),
        new Vector2(8.577999f, -4.585f), new Vector2(-1.662001f, -8.424999f)
    });

    public static List<Vector2> visitorCenter = new List<Vector2>(new Vector2[] {
        new Vector2(-15.742f, -5.865f), new Vector2(-15.742f, -4.585f),
        new Vector2(-15.742f, -7.145f), new Vector2(-15.742f, -8.424999f),
        new Vector2(-14.462f, -5.865f), new Vector2(-14.462f, -4.585f),
        new Vector2(-14.462f, -7.145f), new Vector2(-14.462f, -8.424999f)
    });

    public static Vector2 getRandomGuardPoint(List<Vector2> lst)
    {
        System.Random rnd = new System.Random();

        Vector2 ret = lst[rnd.Next(lst.Count)];
        if (GameController.CheckForPlayer(ret.x, ret.y) == true 
            || GameController.CheckForGuard(ret.x, ret.y) == true) { ret = getRandomGuardPoint(lst); }
        return ret;
    }

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
