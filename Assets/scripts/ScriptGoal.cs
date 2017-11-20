using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGoal : MonoBehaviour {
    public GameObject control;
    public int goals;
	// Use this for initialization
	void Start () {
        goals = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        goals++;
        control.GetComponent<ScriptController>().AddPointsGoal();
        Debug.Log("GOAL");
    }
}
