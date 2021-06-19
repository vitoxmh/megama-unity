using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inicioPlayer : MonoBehaviour {

	// Use this for initialization

	public float velocidadCaida;
	private bool tocaPiso = false;
	private Animator anim;
	public GameObject player;


	void Start () {
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		//gameObject.transform.Translate(new Vector3(0,-velocidadCaida,0)*Time.deltaTime*1);


		anim.SetBool ("rayo",true);
		if(tocaPiso){


			//Destroy (gameObject, 0f);
			//player.transform.position =  new Vector3 (gameObject.transform.position.x,gameObject.transform.position.y,player.transform.position.z);
		}

	}


	void OnTriggerEnter2D(Collider2D collider) {
		
		if (collider.tag == "Plataforma" || collider.tag == "Pilar") {
		
			tocaPiso = true;

		
		}

	}
}
