using UnityEngine;
using System.Collections;

public class InstOnTrigger : MonoBehaviour {
	
	public GameObject objectToInstantiate;

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag != "GameArea"){
			return;
		}

		if(objectToInstantiate == null){
			return;
		}

		Transform gameArea = GameObject.FindGameObjectsWithTag ("GameArea") [0].transform;

		GameObject newObject = (GameObject) Instantiate(objectToInstantiate, new Vector3(transform.position.x, gameArea.position.y + objectToInstantiate.transform.position.y), objectToInstantiate.transform.rotation);

		newObject.transform.parent = gameArea;

		Destroy (gameObject);
	}
		
	void OnDrawGizmos (){
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube (transform.position, new Vector3(1, 1, 1));
	}

}
