using UnityEngine;
using System.Collections;

public class GibOnTrigger : MonoBehaviour {

	public GameObject particles;

	void OnTriggerEnter () {
		if(particles != null){
			Instantiate (particles, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}
}
