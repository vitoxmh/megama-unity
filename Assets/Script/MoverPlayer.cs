using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlayer : MonoBehaviour {

	private Rigidbody2D rb;
	public float AlturaSalto;
	public float velocidadMovimiento;
	private float movimientox, movimientoy;
	//private Animator anim;
	public LayerMask queEsSuelo;
	public Transform SueloCheck;
	private bool sueloToca;
	private bool mirarDerecha;
	private Vector3 girar;
	public Transform bulletSpawner;
	public GameObject bulletPreFabs;
	private bool estadoDisparo;
	private float TiempoDisparo =  0.0f;
	public float SegundoDisparo;
	private SpriteRenderer sr;
	public Sprite img;
	private bool detenerAnimacion;
	private bool estadoDisparoAnimacion;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		//anim = GetComponent<Animator> ();
		rb.freezeRotation = true;
		mirarDerecha = true;
		estadoDisparo = false;
		sr = GetComponent<SpriteRenderer> ();
		detenerAnimacion = false;
		estadoDisparoAnimacion = false;
	}
	
	// Update is called once per frame
	void Update () {


		float nuevoSalto = 0;
		movimientox = Input.GetAxis("Horizontal");
		movimientoy = Input.GetAxis("Vertical");

		// Verifica si el player toca el suelo.
		if (Physics2D.OverlapCircle (SueloCheck.position, 0.04663513f, queEsSuelo)) {
			
			sueloToca = true;
			detenerAnimacion = false;

		} else {

			sueloToca = false;
		
		}


		// Personaje solo se mueve en eje X
		if ((movimientox < 0 || movimientox > 0)) {

			rb.velocity = new Vector2 (movimientox*velocidadMovimiento, rb.velocity.y);	
		}



		if (Input.GetKeyDown(KeyCode.Space) && sueloToca) {

			nuevoSalto = AlturaSalto;
			rb.velocity = new Vector2 (movimientox*velocidadMovimiento, nuevoSalto);	
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


		if (Input.GetKey (KeyCode.F) && TiempoDisparo < Time.time) {

			estadoDisparo = true;
			estadoDisparoAnimacion = true;
			TiempoDisparo = Time.time + SegundoDisparo;
			disparo ();

		} else {
			estadoDisparo = false;
		
		} 



		// Animaciones
		//Camina sin accion
		if(movimientox != 0 && sueloToca){

			camina (12f);
		}


		// Camina y dispara
		/*if(movimientox != 0 && sueloToca && estadoDisparo){

			anim.SetBool ("MegamanCamina", false);
			anim.SetBool ("MegamanQuieto", false);
			anim.SetBool ("MegamanSalta", false);
			anim.SetBool ("CaminaDispara", true);

		}*/
			
		// Megaman Salta
		if(movimientox != 0 && !sueloToca && !estadoDisparo){

			salta (12f, false);
		}

		// Megaman Quieto
		if(movimientox == 0 && sueloToca && !estadoDisparo){

			quieto (6f);

		}


		if(movimientox == 0 && sueloToca && estadoDisparo){
			
		
		}
			
		if(movimientox == 0 && !sueloToca && !estadoDisparo){

			salta (12f, false);
		}



	}


	public void disparo(){

			Instantiate (bulletPreFabs, bulletSpawner.position, bulletSpawner.rotation);
	}



	void camina(float fps){


		Sprite[] textures;
		Debug.Log (estadoDisparoAnimacion);

		if (estadoDisparoAnimacion) {

			textures = Resources.LoadAll<Sprite>("Sprite/Megaman/caminaDispara");

			estadoDisparoAnimacion = true;
			Invoke ("resetDisparo",0.25f);


		} else {

			textures = Resources.LoadAll<Sprite>("Sprite/Megaman/camina");


		}
			

		int index = (int)(Time.timeSinceLevelLoad * fps);

		index = index % textures.Length;

		sr.sprite = textures[index];


	}


	void quieto(float fps){

		Sprite[] textures;

		textures = Resources.LoadAll<Sprite>("Sprite/Megaman/quieto");

		int index = (int)(Time.timeSinceLevelLoad * fps);

		index = index % textures.Length;
	
		sr.sprite = textures[index];

	}


	void salta(float fps = 12f, bool loop = true){

		Sprite[] textures;

		textures = Resources.LoadAll<Sprite>("Sprite/Megaman/Saltar");

		int index = (int)(Time.timeSinceLevelLoad * fps);

		if (loop) {

			index = index % textures.Length;
			sr.sprite = textures[index];

		} else {
			
			index = index % textures.Length;
			 
			if(textures[textures.Length-1] == textures[index] && detenerAnimacion == false){
				
				detenerAnimacion = true;
				float tiempoReset = ((60 * textures.Length) / fps)/60;
				Invoke ("reset",tiempoReset);
			}
				
			 
			if (detenerAnimacion) {

				sr.sprite = textures[textures.Length-1];

			} else {

				sr.sprite = textures[index];
			
			}

		}
	


	}


	void reset(){
	
		detenerAnimacion = false;

	}



	void resetDisparo(){

		estadoDisparoAnimacion = false;
		Debug.Log("Para");

	}




}
	