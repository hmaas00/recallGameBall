using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFora : MonoBehaviour {

    private bool fora;
    //public bool morto;
	// Use this for initialization
	void Awake () {
        fora = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 11 || transform.position.x < -11 || transform.position.z > 11 || transform.position.z < -12)
        {
            fora = true;
            //Debug.Log("start : " + this.transform.position.x + " " + this.transform.position.y + " " + this.transform.position.z);
        }
        else fora = false;
    }

    public bool getFora()
    {
        return fora;
    }
}
