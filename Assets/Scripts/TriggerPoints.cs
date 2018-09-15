using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoints : MonoBehaviour {
    public string roomType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(System.Math.Abs(GameObject.FindWithTag("Player").transform.position.x - transform.position.x) < 0.5f
           && System.Math.Abs(GameObject.FindWithTag("Player").transform.position.y - transform.position.y) < 0.5f
           && System.Math.Abs(GameObject.FindWithTag("Player").transform.position.x - transform.position.x) > -0.5f
          && System.Math.Abs(GameObject.FindWithTag("Player").transform.position.y - transform.position.y) > -0.5f)
        {
            print("Draw card");
        }
	}
}
