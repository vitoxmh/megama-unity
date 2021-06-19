using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	public float velocidadDisparo;
	private Rigidbody2D rb;
	public float TiempoDeVida;
	public GameObject player;
	private Transform playerTrans;
	private Animator anim;
	public GameObject bulletPreFabsExplosion;

	void Awake(){
	
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag("Player");
		playerTrans = player.transform;
		anim = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		

		if (playerTrans.localScale.x < 0) {
		
			rb.velocity = new Vector2 (-velocidadDisparo,rb.velocity.y);

		} else {
		
			rb.velocity = new Vector2 (velocidadDisparo,rb.velocity.y);
		
		}


	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, TiempoDeVida);
	}



	void OnTriggerEnter2D(Collider2D collider) {

		if (collider.gameObject.tag == "Pilar") {
		
			Destroy (gameObject, (float)0);

			Instantiate (bulletPreFabsExplosion, gameObject.transform.position, gameObject.transform.rotation);
		
		}
    }

}