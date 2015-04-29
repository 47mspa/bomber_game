using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player" 
		    || other.gameObject.tag == "Enemy") {
			Destroy (other.gameObject);
		}
	}
}
