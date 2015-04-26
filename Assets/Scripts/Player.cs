using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void FixedUpdate()
	{
		if (Input.GetKey("left") || Input.GetKey("a") 
		    || Input.GetKey("right") || Input.GetKey("d")
		    || Input.GetKey("up") || Input.GetKey("w")
		    || Input.GetKey("down") || Input.GetKey("s")) {

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		transform.position += transform.forward * (speed/100*moveVertical);
		transform.position += transform.right * (speed/100*moveHorizontal);	
		}
	}

	void Update() 
	{
		if(Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, new Vector3(Mathf.Round(shotSpawn.position.x), shotSpawn.position.y, Mathf.Round(shotSpawn.position.z)),
			             shotSpawn.rotation);
		}
	}
}
