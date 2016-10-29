using UnityEngine;
using System.Collections;

/*
	Name           : Makoto Wilson
	Student Number: 100810278
*/

public class BearController : MonoBehaviour {

	[SerializeField]
     int maxItems = 3;
	[SerializeField]
	 GameObject item;
	[SerializeField]
	float xMin = 4.77f;
	[SerializeField]
	float xMax = 8.28f;
	[SerializeField]
	float yMax =  1f;
	[SerializeField]
	float yMin =  -1.5f;

	private Vector2 originPosition;

	void Start (){
		originPosition = transform.position;

		//spawns 3 item game objects in random location
		Spawn ();
	}
	void Spawn(){
		for (int i = 0; i < maxItems; i++)
		{
			Vector2 randomPosition = new Vector2 (Random.Range (xMin, xMax) + 2f + originPosition.x, Random.Range (yMin, yMax));
			Instantiate (item, randomPosition, Quaternion.identity);
			originPosition = randomPosition;
		}

	}


}
