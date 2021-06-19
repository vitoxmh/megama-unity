using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espera : MonoBehaviour {

	// Use this for initialization

	private int cont = 0;

	void Awake(){
	
		Invoke ("hola",1f);
	
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void hola (){

		Debug.Log ("Gol"+cont);
		cont++;
	}
}
