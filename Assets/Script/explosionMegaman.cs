using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionMegaman : MonoBehaviour {

	// Use this for initialization

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("explosion",true);
		Destroy (gameObject, 0.7f);
	}
}
