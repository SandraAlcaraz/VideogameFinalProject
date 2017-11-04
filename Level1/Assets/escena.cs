using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class escena : MonoBehaviour {
    float speed,x,y,z;
	// Use this for initialization
	void Start () {
        speed = 40;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //Debug.Log(x);
        transform.Rotate(new Vector3(Input.acceleration.x*-1,0, Input.acceleration.y*-1) *Time.deltaTime*speed);
        //transform.Rotate(Input.gyro.attitude);
        /*
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back* Time.deltaTime * speed, Space.World);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * speed, Space.World);
        }*/

    }

}
