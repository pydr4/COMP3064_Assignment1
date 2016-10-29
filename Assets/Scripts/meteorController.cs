using UnityEngine;
using System.Collections;

/*
	Name           : Makoto Wilson
	Student Number: 100810278
*/

public class meteorController : MonoBehaviour {

	[SerializeField]
	private Vector2 speed = new Vector2 (2, 2);
	[SerializeField]
	GameObject explosion = null;
	[SerializeField]
	GameObject exp       = null;

	private Vector2 _currentPosition;
	private Transform _transform = null;

	//Constants

	private const float topPosition = 3.5f;
	private const float resetYPosition = -8;
	private const float resetXPosition = -16;


	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		_transform = gameObject.transform;
		_currentPosition = _transform.position;
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		_currentPosition = _transform.position;
		_currentPosition -= speed;
		//detects player movement and moves meteor accordingly
		float input = Input.GetAxis ("Horizontal");

		//if(input < 0)
		rb.velocity = new Vector2 (-input * 3f, 2f);

		_transform.position = _currentPosition;

		//if meteor reaches reset point, it resets the position.
		if (_transform.position.x < resetXPosition || _transform.position.y < resetYPosition) {
			Reset ();
		}




	}

	public void Reset(){
		speed = new Vector2 (0.05f, Random.Range (0.05f, 0.1f));

		//resets meteor to random x axis
		float x = Random.Range(0f, 10f);

		_currentPosition = new Vector2(x, topPosition);
		_transform.position = _currentPosition;

	}


	public void OnTriggerEnter2D(Collider2D other){
		//Implement collision here
		if (other.gameObject.tag == "Player"){
			//Show explosion animation
			GameObject e = Instantiate(exp);
			e.transform.position = _transform.position;
			Debug.Log ("Collision With Player");

			// player takes damage
			Player.Instance.Lives--;
			this.Reset ();
		}
		if (other.gameObject.tag == "platform") {
			Debug.Log ("Collision with ground");

			//Shows different animation than hitting player
			GameObject e = Instantiate(explosion);
			e.transform.position = _transform.position;

			this.Reset ();
		}
	}
}
