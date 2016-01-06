using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShipShoot : MonoBehaviour {

	public float shootSpeed = 0.2f;

	private List<Shooter> shooters;

	private bool canShoot = true;

	void Start () {
		initShooters ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1") && canShoot){
			fireAllShooters();
			canShoot = false;
			Invoke("resetCanShoot", shootSpeed);
		}
	}

	void fireAllShooters () {
		foreach(Shooter shooter in shooters){
			shooter.shoot();
		}
	}

	void initShooters () {
		shooters = new List<Shooter> ();

		foreach (Transform child in transform)
		{
			if(child.gameObject.tag == "Shooter"){
				shooters.Add(child.GetComponent<Shooter>());
			}
		}
	}

	private void resetCanShoot () {
		canShoot = true;
	}

}
