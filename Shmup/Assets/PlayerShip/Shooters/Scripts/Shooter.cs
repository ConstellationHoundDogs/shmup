using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject bullet;
	
	public void shoot(){
		GameObject gameArea = (GameObject) GameObject.FindGameObjectsWithTag("GameArea")[0];

		if (bullet != null) {
			GameObject newBullet = (GameObject) Instantiate(bullet, transform.position, transform.rotation);
			newBullet.transform.parent = gameArea.transform;
		}
	}

	public void OnDrawGizmos(){

	}
}
