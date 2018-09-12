﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSize = 1.28f;
    public Vector3 pos;
    private Vector3 resetPosition;
    private Rigidbody2D theRigidbody;


    // Use this for initialization
    void Start () {
        pos = transform.position;
        resetPosition = transform.position;
        theRigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            pos.y += moveSize;
            //transform.localPosition
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            pos.y -= moveSize;
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            pos.x += moveSize;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            pos.x -= moveSize;
        }
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            transform.position = resetPosition;
        }
    }
}