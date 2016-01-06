using UnityEngine;
using System.Collections;

public class DamageOnTrigger : MonoBehaviour {

	public int bulletDamage = 1;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter (Collider other) {
		EnemyController enemy = other.gameObject.GetComponent<EnemyController> ();
		if(enemy != null){
			enemy.TakeDamage (bulletDamage);
		}
	}	
}
