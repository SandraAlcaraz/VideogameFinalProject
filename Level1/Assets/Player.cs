using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float maxAngularVelocity,
                 time;
    public bool isTiming,
                isTiming2,
                big;
    public Rigidbody rb;
    public int saltos,
                speed,
                vidas;
    public Text vidasText;
    public Text ganar;
    public Text perder;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 0;
        rb.angularDrag = 50F;
        saltos = 3;
        speed = 500;
        vidas = 3;
        time = 0;
        isTiming = false;
        isTiming2 = false;
        big = false;
        vidasText.text = "Vidas: " + vidas.ToString();
        ganar.enabled = false;
        perder.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Space)&&(saltos>0)){

            transform.Translate(Vector3.up*Time.deltaTime*speed,Space.World);
            saltos--;
        }
        if (isTiming==true) {
            time -= Time.deltaTime;
            if (time==0||time<0) {
                isTiming = false;
                transform.localScale -= new Vector3(2f, 2f, 2f);
            }
        }
        if (isTiming2 == true)
        {
            time -= Time.deltaTime;
            if (time == 0 || time < 0)
            {
                isTiming2 = false;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Meta")) {
            Time.timeScale = 0;
            ganar.enabled = true;
        }
        if (collision.gameObject.CompareTag("Crecer")) {
            Destroy(collision.gameObject);
            transform.localScale+=new Vector3(2f,2f,2f);
            time = 5;
            isTiming = true;

        }
        /*if (collision.gameObject.CompareTag("Huevo"))
        {
            Time.timeScale = 0;
            ganar.enabled = true;
        }*/
        if (collision.gameObject.CompareTag("Salto")) {
            Destroy(collision.gameObject);
            saltos += 1;
            

        }
        if (collision.gameObject.CompareTag("Vida")) {
            Destroy(collision.gameObject);
            vidas++;
            vidasText.text = "Vidas: " + vidas.ToString();
        }
        if (collision.gameObject.CompareTag("Hole")&&(isTiming2==false))
        {
            vidas -= 1;
            vidasText.text = "Vidas: " + vidas.ToString();
            time = 1;
            isTiming2 = true;
            if (vidas==0) {
                Time.timeScale = 0;
                perder.enabled = true;
            }
        }
    }
    
}
