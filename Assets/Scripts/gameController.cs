using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameController : MonoBehaviour {
    /*
    public static GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
    public static int len = walls.Length;
    public static Vector2[] array = new Vector2[len];
    */
    public static GameObject[] walls;
    public static int len;
    public static Vector2[] array;

    // Use this for initialization
    void Start () {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        len = walls.Length;
        array = new Vector2[len];

        for (int i = 0; i < len; i++){
            array[i] = new Vector2(walls[i].transform.position.x, walls[i].transform.position.y);
        }
        //array[0] = new Vector2(-0.559f, 1.82f);
        //array[1] = new Vector2(-0.559f, 0.54f);
	}
	
    public static bool CheckForIntersect(float x, float y){
        for (int i = 0; i < len; i++)
        {
            if (Math.Abs(array[i].x - x) <= 0.5 
               && Math.Abs(array[i].y - y) <= 0.5)
            {
                return true;
            }
        }
        return false;
        /*
        if(array.Any(a => a ))
        return true;
        */
    }

	// Update is called once per frame
	void Update () {
		
	}
}
