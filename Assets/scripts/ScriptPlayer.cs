using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayer: MonoBehaviour {

    // Use this for initialization

    private Rigidbody rb;
    public float speed;
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
    // public Rigidbody rb;


    // Update is called once per frame
    void FixedUpdate () {
        float movV = Input.GetAxis("Vertical") * speed;
        float movH = Input.GetAxis("Horizontal") * speed;
        Vector3 movement = new Vector3(movH, 0.0f, movV);
        rb.AddForce(movement);

            /*float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "shootable")
            GetComponent<AudioSource>().Play();
    }
}
