using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScriptCamera : MonoBehaviour {

    public GameObject TargetObject;
    public float offset_x;
    public float offset_y;
    public float offset_z;

    // Use this for initialization
    void Awake () {

        TargetObject = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void LateUpdate()
    {
        Transform t = TargetObject.GetComponent<Transform>();
        Vector3 newPos = new Vector3(t.position.x + offset_x, t.position.y + offset_y, t.position.z + offset_z);
        this.transform.position = newPos;
    }
}
