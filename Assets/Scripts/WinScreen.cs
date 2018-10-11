using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {
    //public GameObject square;
    public string winnerColor;
    /*
    public Color col;
    public MeshRenderer wcRenderer;
    public Material mat;
    */
	// Use this for initialization
	void Start () {
        winnerColor = PlayerPrefs.GetString("winner");
        //wcRenderer = square.GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        /*
GameObject whateverGameObject = whatever;
Color whateverColor = new Color(whateverRValue,whateverGValue,whateverBValue,1);
 
MeshRenderer gameObjectRenderer = whateverGameObject.GetComponent<MeshRenderer>();
 
Material newMaterial = new Material(Shader.Find("Whatever name of the shader you want to use"));
 
newMaterial.color = whateverColor;
gameObjectRenderer.material = newMaterial ;

         */
        /*
        if (winnerColor == "red")
        {
            square.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (winnerColor == "green")
        {

        }
        else if (winnerColor == "yellow")
        {

        }
        else if (winnerColor == "brown")
        {

        }
        else if (winnerColor == "purple")
        {

        }
        else if (winnerColor == "blue")
        {

        }*/


        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("OpeningScene");
        }

    }
}
