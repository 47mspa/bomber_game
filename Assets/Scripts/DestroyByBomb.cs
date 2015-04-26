using UnityEngine;
using System.Collections;
using System.Linq;

public class DestroyByBomb : MonoBehaviour {
	public GameObject explosion;
	public float range;

	private float timer;
	// Use this for initialization
	void Start () {
		timer = Random.Range(3,5);
	}
	
	// Update is called once per frame
	void Update () {
		if(timer > 0) {
			timer -= Time.deltaTime;
		}
		else {
			removeHits(Physics.RaycastAll(transform.position, transform.forward, range));
			removeHits(Physics.RaycastAll(transform.position, -transform.forward, range));
			removeHits(Physics.RaycastAll(transform.position, transform.right, range));
			removeHits(Physics.RaycastAll(transform.position, -transform.right, range));

//			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}

	void removeHits(RaycastHit[] hits) {
		hits.OrderBy(h=>h.distance);
		foreach(RaycastHit hit in hits) {
			GameObject gameObject = hit.transform.gameObject;
			if (gameObject.tag == "Enemy" 
			    || gameObject.tag == "Player"
			    || gameObject.tag == "Breakable Wall"){
				Destroy(hit.transform.gameObject);
			}
			if (gameObject.tag == "Breakable Wall" || gameObject.tag == "Solid Wall") {
				return;
			}
		}
	}
}
