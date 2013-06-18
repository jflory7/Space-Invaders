using UnityEngine;
using System.Collections;

public class PlayerMissile : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		// Add initial force.
		rigidbody.AddForce (0, 750, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.y > 17)
		{
			Destroy (gameObject);
		}
	}

	// Check to see if a collision has occured.
	
}
