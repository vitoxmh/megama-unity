using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caerPlataforma : MonoBehaviour {

	public float tiempoCaida;
	private float deltaCaida = 0f;
	public float velocidadCaida;
	//private Rigidbody2D rb;
	private Transform plataforma;
	private bool cae;
	private bool tocarPlataforma;

	// Use this for initialization

	void Awake(){



	}
	void Start () {
		
		plataforma = transform;
		cae = false;
		tocarPlataforma = false;
		deltaCaida = Time.time + tiempoCaida;
		//rb = GetComponent<Rigidbody2D> ();
		//rb.freezeRotation = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (cae) {
		
			plataforma.Translate (new Vector3(0,-velocidadCaida,0)*Time.deltaTime*1);
			Destroy (gameObject, 3f);
		}




		if (Time.time > deltaCaida && tocarPlataforma) {
		
			deltaCaida = Time.time + tiempoCaida;
			cae = true;

		
		}




	}


	void OnCollisionEnter2D(Collision2D coll){
	
		if (coll.gameObject.tag == "Player") {
			 
			tocarPlataforma = true;

		}

	
	
	}


	void OnTriggerStay2D(Collider2D other) {
		
		other.transform.parent = transform;
	}



	void OnTriggerExit2D(Collider2D other)
	{
		
		other.transform.parent = null;

	}


}
