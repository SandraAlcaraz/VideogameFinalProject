using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float maxAngularVelocity,Drag,
                 time;
    public bool isTiming,
                isTiming2,
                big,
                fuego,
                huevo;
    public Rigidbody rb;
    public int speed,
                vidas,
                saltos;
    public Text vidasText;
    public Text ganar;
    public Text perder;
    public Material normal, shfuego;
    public Renderer rend;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rb.maxAngularVelocity = 20;
        rb.angularDrag = 0.5f;
        Drag = rb.drag;
        fuego = true;
        huevo = false;
        saltos=3;
        Physics.gravity = new Vector3(0, -60, 0);
        speed = 30;
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

       if ((saltos>0 &&Input.touchCount > 0&& Input.GetTouch(0).phase == TouchPhase.Began))
        {
            rb.AddForce(Vector3.up * speed,ForceMode.VelocityChange);
            saltos--;
        }
        if (isTiming==true) {
            time -= Time.deltaTime;
            if (time==0||time<0) {
                isTiming = false;
                if (big == true)
                {
                    big = false;
                    transform.localScale -= new Vector3(2f, 2f, 2f);
                }
                else if (huevo == true) {
                    huevo = false;
                    transform.localScale -= new Vector3(0f, 2f, 0f);
                    rb.mass = 20;
                }
                else if (fuego) {
                    fuego = false;
                    rend.material = normal;

                }
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
        if (collision.gameObject.CompareTag("Escenario")) {
            rb.drag = Drag;
        }
        if (collision.gameObject.CompareTag("Meta")) {
            Time.timeScale = 0;
            ganar.enabled = true;
        }
        if (collision.gameObject.CompareTag("Crecer")) {
            Destroy(collision.gameObject);
            transform.localScale+=new Vector3(2f,2f,2f);
            time = 5;
            big = true;
            isTiming = true;

        }
        if (collision.gameObject.CompareTag("Huevo"))
        {
            Destroy(collision.gameObject);
            transform.localScale += new Vector3(0f, 2f, 0f);
            rb.mass = 10;
            huevo = true;
            time = 5;
            isTiming = true;
        }
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
       /* if (collision.gameObject.CompareTag("Enemy")) {
            if (big == true)
            {
                Destroy(collision.gameObject);
            }
            else {
                vidas -= 1;
                vidasText.text = "Vidas: " + vidas.ToString();
                time = 1;
                isTiming2 = true;
                if (vidas == 0)
                {
                    Time.timeScale = 0;
                    perder.enabled = true;
                }

            }

        }*/
        if (collision.gameObject.CompareTag("Fuego")) {
            fuego = true;
            Destroy(collision.gameObject);
            rend.material= shfuego;
            time = 5;
            isTiming = true;
        }
        if (collision.gameObject.CompareTag("Pared")&&fuego==true) {
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hielo"))
        {
            rb.drag = 0f;
        }
        if (collision.gameObject.CompareTag("Arena"))
        {
            rb.drag = 4f;
        }
    }

}
