using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHold : MonoBehaviour {

    //public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        GameObject ob =  other.gameObject;

        ob.GetComponent<Rigidbody>().isKinematic= true;
        //Tira movimento da bola
        ob.GetComponent<Rigidbody>().isKinematic = false;


    }
}
