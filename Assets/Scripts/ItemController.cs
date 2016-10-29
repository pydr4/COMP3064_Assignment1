using UnityEngine;
using System.Collections;

/*
	Name           : Makoto Wilson
	Student Number: 100810278
*/

public class ItemController : MonoBehaviour {

	[SerializeField]
	private float speed = -0.05f;


	private Transform _transform = null;
	private Vector2 currentPosition;

	//Constants
	private const float resetX = -6f;

	private const float minY = -1.5f;
	private const float maxY = 1f;
	private const float maxX = 8.28f;
	private const float minX = 4.77f;
	// Use this for initialization
	void Start () {
		_transform = gameObject.transform;
	}

	// Update is called once per frame
	void Update () {

		//moves item as the player moves left and right 
		currentPosition = _transform.position;

		float input = Input.GetAxis ("Horizontal");

		currentPosition += new Vector2 (input*speed , 0);


		if (currentPosition.x < resetX) {
			//resets item location
			Reset ();		
		}

		_transform.position = currentPosition;


	}

	void Reset(){

		float y = Random.Range (minY, maxY);
		float x = Random.Range (minX, maxX);
		currentPosition = new Vector2 (x,y);
		_transform.position = currentPosition;

	}

	public void OnTriggerEnter2D(Collider2D other){
		//Implement collision here
		if (other.gameObject.tag == "Player"){
			Debug.Log ("Collision With Player");
			// plays sound on player interaction
			AudioSource ac = GetComponent<AudioSource> ();
			ac.Play ();
			Player.Instance.Points++;
			this.Reset ();
		}
		if (other.gameObject.tag == "platform") {
			Debug.Log ("Collision with ground");
			this.Reset ();
		}
	}
		
}
