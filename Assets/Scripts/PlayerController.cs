using UnityEngine;
using System.Collections;

/*
	Name           : Makoto Wilson
	Student Number: 100810278
*/

public class PlayerController : MonoBehaviour {
	Transform _transform = null;
	Vector2 _currentPosition;
	bool facingRight = true;

	bool ground = true;
	float groundRad = 0.2f;
	public LayerMask whatIsGround;
	public Transform groundCheck;

	Rigidbody2D rb;

	Animator animate;

	[SerializeField]
	float vForce = 1000f;
	[SerializeField]
	float speed = 2;




	// Use this for initialization
	void Start () {
		_transform = gameObject.transform;

		//gets player animator
		animate = GetComponent<Animator> ();

		//gets the player's rigid body
		rb = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		_currentPosition = gameObject.transform.position;

		//checks if player is grounded
		ground = Physics2D.OverlapCircle (groundCheck.position, groundRad, whatIsGround);

		//sets animate ground property
		animate.SetBool ("Ground", ground);

		//sets the animation speed to current speed of player
		animate.SetFloat ("vSpeed", rb.velocity.y);
	
		float input = Input.GetAxis ("Horizontal");

		animate.SetFloat("Speed",Mathf.Abs(input));

		
		//rb.velocity = new Vector2 (input * speed, rb.velocity.y);

		//flips player if player is facing wrong way
		if (input > 0 && !facingRight) 
			Flip ();
		 else if (input < 0 && facingRight)
			Flip ();
		//_transform.position = _currentPosition;

		if (_currentPosition.y < -5) {
			//player takes damage if fallen from platform
			die ();

		} 
	}

	void Update(){
		//jumps player only if the player is on the ground
		if (ground && Input.GetButtonDown("Jump")) {
			animate.SetBool ("Ground", false);
			rb.AddForce (new Vector2(rb.velocity.x*speed, vForce));
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void die(){
		_currentPosition = new Vector2 (0, 2.5f);
		_transform.position = _currentPosition;

		Player.Instance.Lives--;


	}
		
}
