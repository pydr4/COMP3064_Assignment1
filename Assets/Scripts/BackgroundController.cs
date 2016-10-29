using UnityEngine;
using System.Collections;
/*
	Name           : Makoto Wilson
	Student Number: 100810278
*/
public class BackgroundController : MonoBehaviour {
	
	float scrollspeed = 0.01f;
	private Vector2 offset = Vector2.zero;

	Rigidbody2D rb;

	[SerializeField]
	Renderer rend = null;


	void Start(){
		// gets the renderer component of the background
		rend = GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 offset = rend.material.mainTextureOffset;


		float input = Input.GetAxis ("Horizontal");
		//player input controls movement of the background (parallax)
			offset.x += input * scrollspeed;

		rend.material.mainTextureOffset = offset;
	}
		
}
