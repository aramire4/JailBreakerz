using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayers : MonoBehaviour {

    // Use this for initialization
   
    public int numberOfPlayers;
    public List<GameObject> prefabs = new List<GameObject>(6);

    public List<Vector2> spawnPoints = new List<Vector2>(new Vector2[] {
        new Vector2(-9.342f, 4.375f), new Vector2 (-8.062f, 4.375f),
        new Vector2(-4.222001f, 4.375f), new Vector2(-2.942001f, 4.375f),
        new Vector2(0.8979988f, 4.375f), new Vector2(2.177999f, 4.375f),
        new Vector2(6.017999f, 4.375f), new Vector2(7.297998f, 4.375f)
    });
    //numberOfPlayers = PlayerPrefs.GetInt("NumberOfPlayers");

    void Awake(){
	    numberOfPlayers = PlayerPrefs.GetInt("NumberOfPlayers");
        for (int i = 1; i <= numberOfPlayers; i++){
            SpawnPlayer(StringToGameObject(TranslatePlayerPref(i)));
        }
    }

    string TranslatePlayerPref(int num){
        if(num == 1){
            return PlayerPrefs.GetString("player1");
        }
        else if (num == 2){
            return PlayerPrefs.GetString("player2");
        }
        else if (num == 3)
        {
            return PlayerPrefs.GetString("player3");
        }
        else if (num == 4)
        {
            return PlayerPrefs.GetString("player4");
        }
        else if (num == 5)
        {
            return PlayerPrefs.GetString("player5");
        }
        else if (num == 6)
        {
            return PlayerPrefs.GetString("player6");
        }
        else return null;
    }

    GameObject StringToGameObject(string str){
        if (str == "red")
        {
            //return (GameObject.Find("Jail Breaker Red"));
            return prefabs[0];
        }
        else if (str == "green")
        {
            //return (GameObject.Find("Jail Breaker Green"));
            return prefabs[1];
        }
        else if (str == "yellow")
        {
            //return (GameObject.Find("Jail Breaker Yellow"));
            return prefabs[2];
        }
        else if (str == "brown")
        {
            //return (GameObject.Find("Jail Breaker Brown"));
            return prefabs[3];
        }
        else if (str == "purple")
        {
            //return (GameObject.Find("Jail Breaker Purple"));
            return prefabs[4];
        }
        else if (str == "blue")
        {
            //return (GameObject.Find("Jail Breaker Blue"));
            return prefabs[5];
        }
        else return null;
    }

    void SpawnPlayer(GameObject play){
        Vector2 pos = GetSpawnPoint();
        GameObject spawn = Instantiate(play,
                                       new Vector3(pos.x, pos.y, 0),
                                       Quaternion.identity) as GameObject;
    }

    Vector2 GetSpawnPoint(){
        System.Random rnd = new System.Random();
        Vector2 ret = spawnPoints[rnd.Next(spawnPoints.Count)];
        spawnPoints.Remove(ret);
        if(ret == null){
            ret = GetSpawnPoint();
        }
        return ret;
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
