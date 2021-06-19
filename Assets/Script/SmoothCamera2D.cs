using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera2D : MonoBehaviour
{

	private Vector2 velocidad;
	public float smoothTimeY;
	public float smoothTimeX;
	public GameObject player;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		float postX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocidad.x, smoothTimeX);
		float postY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocidad.y, smoothTimeY);

		if (postY < -0.5f) {
		
			postY = -0.5f;
		
		} 
			
		transform.position = new Vector3 (postX,postY,transform.position.z);
	}
}