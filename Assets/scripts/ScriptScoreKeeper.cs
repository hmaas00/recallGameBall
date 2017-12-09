using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptScoreKeeper : MonoBehaviour {

    public int points = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddPoints(int p)
    {
        points += p;
    }
    public int getPoints()
    {
        return points;
    }
}
