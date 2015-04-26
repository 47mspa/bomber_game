using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		winText.text = "";
		SetCountText();
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3((int)(moveHorizontal/0.5), 0.0f, (int)(moveVertical/0.5));
		rb.AddForce(movement*speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Pick Up")
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 12)
		{
			winText.text = "You Win!";
		}
	}

}
