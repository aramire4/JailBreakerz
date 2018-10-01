using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{

    // Use this for initialization
    public float moveSize = 1.28f;
    public Vector3 pos;

    private Vector3 resetPosition;
    private int inputAvailable = 0;

    void Start()
    {
        pos = transform.position;
        resetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        inputAvailable--;

        if (inputAvailable <= 0)
        {
            if (Input.GetAxis("Vertical") > .5)
            {
                if (GameController.CheckForWalls(pos.x, (pos.y + moveSize)) == false
                   && GameController.CheckForPlayer(pos.x, (pos.y + moveSize)) == false)
                {
                    pos.y += moveSize;
                    inputAvailable = 20;
                }

                //transform.localPosition
            }

            else if (Input.GetAxis("Vertical") < -.5)
            {
                if (GameController.CheckForWalls(pos.x, (pos.y - moveSize)) == false
                    && GameController.CheckForPlayer(pos.x, (pos.y - moveSize)) == false)

                {
                    pos.y -= moveSize;
                    inputAvailable = 20;
                }
            }

            else if (Input.GetAxis("Horizontal") > .5)
            {
                if (GameController.CheckForWalls((pos.x + moveSize), pos.y) == false
                    && GameController.CheckForPlayer((pos.x + moveSize), pos.y) == false)
                {
                    pos.x += moveSize;
                    inputAvailable = 20;
                }
            }

            else if (Input.GetAxis("Horizontal") < -.5)
            {
                if (GameController.CheckForWalls((pos.x - moveSize), pos.y) == false
                    && GameController.CheckForPlayer((pos.x - moveSize), pos.y) == false)
                {
                    pos.x -= moveSize;
                    inputAvailable = 20;
                }
            }
            transform.position = pos;

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
                pos = resetPosition;
                transform.position = pos;
        }

    }
}
