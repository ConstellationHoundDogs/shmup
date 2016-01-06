using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour{

	public float speed = 10f;
	public float acceleration = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		speed += acceleration;
		transform.position += transform.up * Time.deltaTime * speed;
	}

	void OnTriggerEnter (Collider other) {
		if(other.tag == "Enemy"){
			Destroy(gameObject);
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "GameArea"){
			Destroy(gameObject);
		}
	}

}
