using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Moving());
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
           
	}
    void OnCollisionEnter(Collision col)
    {
        StartCoroutine(WaitDestroy());
        if (col.gameObject.tag == "shootable")
        {
            GetComponent<AudioSource>().Play();
        }
        //Destroy(this.gameObject);
    }
    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
    //ir para direita e esquerda
    IEnumerator Moving()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().AddForce(new Vector3(2f, 0f, 0f), ForceMode.VelocityChange);
        while (true) {
            yield return new WaitForSeconds(1);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            yield return new WaitForSeconds(1);
           // GetComponent<Rigidbody>().WakeUp();
            GetComponent<Rigidbody>().AddForce(new Vector3(-4f, 0f, 0f), ForceMode.VelocityChange);
            yield return new WaitForSeconds(1);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            yield return new WaitForSeconds(1);
            // GetComponent<Rigidbody>().WakeUp();
            GetComponent<Rigidbody>().AddForce(new Vector3(4f, 0f, 0f), ForceMode.VelocityChange);
        }

    }

}
