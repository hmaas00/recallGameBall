using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCamera2 : MonoBehaviour {

    private GameObject Target ;
	// Use this for initialization
	void Awake () {
        if (Target == null)
        {
            Target = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("Target was destroyed");
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Target.transform);
	}
    public void SetTarget(GameObject t)
    {
        Target = t;
    }
}
