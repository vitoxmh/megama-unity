using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacionesMegaman : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rb;
	private float movimientox, movimientoy;
	public float velocidadMovimiento;
	private SpriteRenderer sr;
	private bool mirarDerecha;
	public float framesPerSecond;
	private Vector3 girar;
	public float SegundoDisparo;
	private bool disparo;
	public float AlturaSalto;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
		rb.freezeRotation = true;
		disparo = false;
		mirarDerecha = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		movimientox = Input.GetAxis("Horizontal");
		movimientoy = Input.GetAxis("Vertical");

		//sr.sprite = "red";

		if (Input.GetKey (KeyCode.G)) {

			disparo = true;



		} else {

			disparo = false;

		}




	

		// Mueve el sprite de izquierda a derecha
		if (mirarDerecha && movimientox < 0) {

			girar = transform.localScale;
			girar.x *= (-1);
			girar = transform.localScale = girar;
			mirarDerecha = false;

		} else if(movimientox > 0 && !mirarDerecha){

			girar = transform.localScale;
			girar.x *= (-1);
			girar = transform.localScale = girar;
			mirarDerecha = true;
		}


		if ((movimientox < 0 || movimientox > 0)) {

			rb.velocity = new Vector2 (movimientox*velocidadMovimiento, rb.velocity.y);	
		}




		if (movimientox == 0) {
		
			quieto (5f);

		}



		if (movimientox != 0) {
		
			camina (12f);
		}


		if (Input.GetKeyDown(KeyCode.Space)) {

			salta (12f);
		} 



	}


	void camina(float fps){



		Sprite[] textures;


		if (disparo) {

			textures = Resources.LoadAll<Sprite>("Sprite/Megaman/caminaDispara");


		} else {

			textures = Resources.LoadAll<Sprite>("Sprite/Megaman/camina");

		}
			

		int index = (int)(Time.timeSinceLevelLoad * fps);

		index = index % textures.Length;



		sr.sprite = textures[index];


		if (Input.GetKeyDown(KeyCode.Space)) {

			rb.velocity = new Vector2 (movimientox*velocidadMovimiento, AlturaSalto);	
		} 


	}


	void quieto(float fps){
	
		Sprite[] textures;

		textures = Resources.LoadAll<Sprite>("Sprite/Megaman/quieto");


		int index = (int)(Time.timeSinceLevelLoad * fps);

		index = index % textures.Length;
		sr.sprite = textures[index];

	
	}


	void salta(float fps){
	
		Sprite[] textures;

		textures = Resources.LoadAll<Sprite>("Sprite/Megaman/Saltar");


		int index = (int)(Time.timeSinceLevelLoad * fps);

		index = index % textures.Length;
		sr.sprite = textures[index];

	}

}
