using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour {

	public float ttl = 5;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, ttl);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
