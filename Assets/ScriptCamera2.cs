﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCamera2 : MonoBehaviour {

    public GameObject Target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Target.transform);
	}
}
