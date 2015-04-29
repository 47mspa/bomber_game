using UnityEngine;
using System.Collections;
using System.Linq;

public class DestroyByBomb : MonoBehaviour {
	public GameObject explosion;
	public GameObject fire;
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
			if(explosion != null) {
//				removeHits(Physics.RaycastAll(transform.position, transform.forward, range));
//				removeHits(Physics.RaycastAll(transform.position, -transform.forward, range));
//				removeHits(Physics.RaycastAll(transform.position, transform.right, range));
//				removeHits(Physics.RaycastAll(transform.position, -transform.right, range));
				row();
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(this.gameObject);
			}
		}
	}

	void row() {
		ExplosionDamage(transform.position);
		for (int i = 1; i <= range; i++) {
			if(!ExplosionDamage(transform.position + new Vector3(0, 0, i)))
				break;
		}
		for (int i = 1; i <= range; i++) {
			if(!ExplosionDamage(transform.position - new Vector3(0, 0, i)))
				break;
		}
		for (int i = 1; i <= range; i++) {
			if (!ExplosionDamage(transform.position + new Vector3(i, 0, 0)))
				break;
		}
		for (int i = 1; i <= range; i++) {
			if(!ExplosionDamage(transform.position - new Vector3(i, 0, 0)))
				break;
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

	bool ExplosionDamage(Vector3 origin) {
		if (origin.x < -4 || origin.z < -4 
		    || origin.x > 4 || origin.z > 4) {
			return false;
		}

		Collider[] hitColliders = Physics.OverlapSphere(origin, 0);
		Debug.Log ("x :" + origin.x + "y :" + origin.z);
		foreach(Collider c in hitColliders) {
			GameObject gameObject = c.gameObject;
			if (gameObject.tag == "Enemy" 
			    || gameObject.tag == "Player"
			    || gameObject.tag == "Breakable Wall"){
				Destroy(gameObject);
				if(gameObject.tag == "Breakable Wall"){
					Instantiate(fire, origin, transform.rotation);
				}
			}
			if (gameObject.tag == "Breakable Wall" 
			    || gameObject.tag == "Solid Wall") {
				Debug.Log ("return"+ c.name);
				return false;
			}

			Debug.Log ("collider"+ c.name);
		}
		Instantiate(fire, origin, transform.rotation);
		return true;
	}
}
