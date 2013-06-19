using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public bool HasFired { get; set; }
	
	public Transform missile;

	// Use this for initialization
	void Start ()
	{
		HasFired = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If the left input is pressed...
		if (Input.GetButton ("Left"))
		{
			// ...move left.
			transform.Translate (10 * Vector3.right * Time.deltaTime);
		}

		// If the right input is pressed...
		if (Input.GetButton ("Right"))
		{
			// ...move left.
			transform.Translate (10 * Vector3.left * Time.deltaTime);
		}
		
		// If the player's paddle is to the left of the screen...
		if (transform.position.x < -13)
		{
			// ...reset the player's paddle to the left of the screen.
			transform.position = new Vector3 (-13, transform.position.y, transform.position.z);
		}
		
		// If the player's paddle is to the right of the screen...
		if (transform.position.x > 13)
		{			
			// ...reset the player's paddle to the right of the screen.
			transform.position = new Vector3 (13, transform.position.y, transform.position.z);
		}
		// Prevent movement on the z-axis.
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		
		// Check to see if the player has fired a missile.
		if (Input.GetButton ("Fire"))
		{
			FireMissile ();
		}
		//transform.position = new Vector3 (transform.position.x, transform.position.y,);
	}
		
	// Check to see if the player has moved past the boundary.
	private void CheckBoundary ()
	{
		if (transform.position.x > 13)
		{
			transform.position = new Vector3 (13, transform.position.y, transform.position.z);
		}
		else if (transform.position.x < -13)
		{
			transform.position = new Vector3 (-13, transform.position.y, transform.position.z);
		}
	}
	// Fire a new missile.
	private void FireMissile ()
	{
		if (!HasFired)
		{
			HasFired = true;
			
			// Create a new missile.
			Instantiate (missile, new Vector3 (transform.position.x, transform.position.y + (renderer.bounds.size.y / 2), 0), Quaternion.identity);
		}
	}
}
