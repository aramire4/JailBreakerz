using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionMakerBehavior : MonoBehaviour
{
    public bool makingDecision;
    public int decision;

    public Text title;
    public Text choice1;
    public Text choice2;

    public void ActivateDecision(string t)
    {
        //TODO-fix box selector position
        /*
        transform.position = current.GetComponent<Player>().transform.position;
        tempPosition.x = transform.position.x - 3f;
        tempPosition.y = transform.position.y + 2f;
        */
        //tempPosition = new Vector3(transform.position.x - 3.65f, transform.position.y + 2.75f, 0f);
        //tempPosition = pos;
        choice1.text = "";
        choice2.text = "";
        title.text = t;
        gameObject.SetActive(true);
        makingDecision = true;
        decision = -1;
        //-1 has not decided, 0 yes, 1 no
    }

    public void ActivateDifferentChoice(string c1, string c2, string t)
    {
        //UpdateText(c1, c2);
        gameObject.SetActive(true);
        makingDecision = true;
        choice1.text = c1;
        choice2.text = c2;
        title.text = t;
        decision = -1;
    }

    public void DeactivateDecision()
    {
        makingDecision = false;
        gameObject.SetActive(false);

        //selection.transform.position = tempPosition;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") < .5)
        {
            decision = 0;
            DeactivateDecision();
        }
        if (Input.GetAxis("Horizontal") > .5)
        {
            decision = 1;
            DeactivateDecision();
        }

    }

    public void UpdateText(string str1, string str2)
    {
        if(str1 == "" && str2 == "")
        {
            choice1.text = "yes";
            choice2.text = "no";
        }
        else
        {
            choice1.text = str1;
            choice2.text = str2;
        }
    }
    public void UpdateTitle(string t)
    {
        title.text = t;
    }
}