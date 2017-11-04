using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escena : MonoBehaviour {
    float speed;
	// Use this for initialization
	void Start () {
        speed = 40f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation=Input.gyro.attitude;


	/*	if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * speed, Space.World);
			//print (Vector3.right * Time.deltaTime * speed);
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
        }
*/
    }
}
