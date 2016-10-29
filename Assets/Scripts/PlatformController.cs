using UnityEngine;
using System.Collections;

/*
	Name           : Makoto Wilson
	Student Number: 100810278
*/

public class PlatformController : MonoBehaviour {

	[SerializeField]
	private float speed = -0.05f;

	private Transform _transform = null;
	private Vector2 currentPosition;

	//Constants
	private const float resetX = -6f;
	private const float startX = 5f;

	private const float minY = -2f;
	private const float maxY = 0;

	// Use this for initialization
	void Start () {
		_transform = gameObject.transform;
	}

	// Update is called once per frame
	void Update () {
		currentPosition = _transform.position;
		//moves platform upon player input
		float input = Input.GetAxis ("Horizontal");

		currentPosition += new Vector2 (input*speed , 0);


		if (currentPosition.x < resetX) {
			//resets the platform in random location
			Reset ();		
		}

		_transform.position = currentPosition;


	}

	void Reset(){

		float y = Random.Range (minY, maxY);

		currentPosition = new Vector2 (startX,y);
		_transform.position = currentPosition;
		
	}
}
