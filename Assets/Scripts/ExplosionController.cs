using UnityEngine;
using System.Collections;

/*
	Name           : Makoto Wilson
	Student Number: 100810278
*/

public class ExplosionController : MonoBehaviour {
	
	public void End(){
		//Destroys gameobject
		Destroy (gameObject);
	}

	void Update(){
		//moves explosion as the screen moves
		Vector2 position = transform.position;

		float input = Input.GetAxis ("Horizontal");

		position += new Vector2 (input*-0.05f , 0);

		transform.position = position;

	}
}
