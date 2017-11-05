using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltos : MonoBehaviour {
    public int saltos;
    public float speed;
	// Use this for initialization
	void Start () {
        saltos = 3;
        speed = 50;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("hola");
            transform.Translate(Vector3.up * speed, Space.Self);
            saltos--;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Salto"))
        {
            Destroy(collision.gameObject);
            saltos += 1;
        }
    }
}
