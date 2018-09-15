using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {


    public static GameObject [] walls = GameObject.FindGameObjectsWithTag("Wall");
    public static int len = walls.Length;
    public static Vector2[] array = new Vector2[len];

	// Use this for initialization
	void Start () {
        for (int i = 0; i < len; i++){
            array[i] = new Vector2(walls[i].transform.position.x, walls[i].transform.position.y);
        }
        //array[0] = new Vector2(-0.559f, 1.82f);
        //array[1] = new Vector2(-0.559f, 0.54f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
