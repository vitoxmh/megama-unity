using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muereBullet : MonoBehaviour {

	// Use this for initialization

	private Animator anim;
	public float TiempoDeVida;

	void Awake(){

		anim = GetComponent<Animator> ();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		anim.SetBool ("explota",true);
		Destroy (gameObject, TiempoDeVida);
	}
}
