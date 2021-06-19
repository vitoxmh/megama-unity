using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFondo : MonoBehaviour {

	private Vector2 velocidad;
	public float velocidadMovimeinto;
	public GameObject player;
	private Rigidbody2D rb;


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		

		rb.velocity = new Vector2 (player.transform.position.x*velocidadMovimeinto, rb.velocity.y);


	}
}
