using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	public float spawnDelay = 0.5f;

	public List<GameObject> enemyList;


	void Start () {
		enemyList = new List<GameObject> ();
	}
	
	void OnTriggerEnter (Collider other){
		if(other.gameObject.tag == "GameArea"){
			Init(other.gameObject);
		}
	}

	void Init(GameObject spawnTo){
		Transform transform = spawnTo.transform;




	}
	
}
