using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {
	public GameObject player;
	//public GameObject tablero;
	private Vector3 offset;


	void Start () {
		offset = transform.position - player.transform.position;
		//tab = transform.rotation;
	}

	void LateUpdate () {
		
		transform.position = player.transform.position + offset;
		//transform.rotation = tablero.transform.rotation +tab ;
	}
}
