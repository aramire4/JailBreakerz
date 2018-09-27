using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBahavior : MonoBehaviour {

    // Use this for initialization

    public void ActivateInventory()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateInventory()
    {
        gameObject.SetActive(false);
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
