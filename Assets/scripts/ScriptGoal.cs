using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGoal : MonoBehaviour {
    
    //public GameObject control;
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
        //se colisão for com keeper, nao pontuar!
        if (!other.gameObject.name.Equals("Keeper"))
        {
            //Debug.Log("KEEPER HIT!!!!!!! =" + other.gameObject.name);
            GetComponent<AudioSource>().Play(); // sound for goal
            GameObject control = GameObject.FindGameObjectWithTag("GameController");
            control.GetComponent<ScriptController>().AddPointsGoal();
            
        }
        
        //Debug.Log("GOAL");
    }
    public void testMessage()
    {
        Debug.Log("text message tudo ok");
    }
}
