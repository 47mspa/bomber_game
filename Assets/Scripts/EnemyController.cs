using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float enemySpeed;
	private bool isForward;
	// Use this for initialization
	void Start () {
		isForward = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isForward) {
			transform.position += transform.forward * Time.deltaTime*enemySpeed;
		} else {
			transform.position += -transform.forward * Time.deltaTime*enemySpeed;
		}
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "Solid Wall"
			|| c.gameObject.tag == "Breakable Wall") {
			isForward = !isForward;
		}
	}
}
