using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class escena : MonoBehaviour {
    float speed,x,y,z;
	// Use this for initialization
	void Start () {
        speed = 50;
	}
	
	// Update is called once per frame
	void Update () {
       x += Input.acceleration.y * Time.deltaTime * speed;
        x = Mathf.Clamp(x, -10, 10);
        y += Input.acceleration.x * -1 * Time.deltaTime * speed;
        y= Mathf.Clamp(y, -10, 10);
        transform.localEulerAngles=new Vector3(x,0,y);
    }

}
