using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
   

	void Start () {
		offset = transform.position - player.transform.position;
        
    }

	void LateUpdate () {
        //transform.Rotate(new Vector3(Input.acceleration.x * -1, 0, Input.acceleration.y * -1) * Time.deltaTime * 20);
        transform.position = player.transform.position + offset;
	}
}
