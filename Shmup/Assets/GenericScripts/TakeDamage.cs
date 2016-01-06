using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	private EnemyController enemyController;

	void Start (){
		enemyController = gameObject.GetComponent<EnemyController> ();
	}

	void OnTriggerEnter () {
		enemyController.TakeDamage (1);
	}	
}
