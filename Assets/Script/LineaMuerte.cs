using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineaMuerte : MonoBehaviour {

	// Use this for initialization

	public GameObject explosionPreFabs;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D coll){


		Destroy (coll.gameObject, 0f);


		Instantiate (explosionPreFabs,coll.gameObject.transform.position, coll.gameObject.transform.rotation);

		Debug.Log (coll.gameObject.tag);

	}


	void OnTriggerStay2D(Collider2D other) {


	}

}
