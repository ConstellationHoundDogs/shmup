using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletManager : MonoBehaviour {

	public MyBulletManager myBulletManager;

	private GameObject player;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		myBulletManager = new MyBulletManager (player);
	}


	void Update(){
		if(myBulletManager != null){
			for (int ii = 0; ii < myBulletManager.bullets.Count; ii++) {
				//Destroy bullet which prefab was destroied
				if(myBulletManager.bullets[ii].bulletPrefab == null){
					myBulletManager.bullets.Remove(myBulletManager.bullets[ii]);
				}else{
					myBulletManager.bullets[ii].Update ();
				}
			}
		}
	}

}

public class MyBulletManager : BulletMLLib.IBulletManager {
	
	public List<MyBullet> bullets = new List<MyBullet>();
	public GameObject player;
	
	public MyBulletManager (GameObject _player) {
		player = _player;
	}
	
	#region IBulletManager implementation

	public Vector2 PlayerPosition (BulletMLLib.Bullet targettedBullet) {
		if(player == null) {
			throw new UnityException("MyBulletManager: PlayerPosition: player is not defined.");
		}

		Vector2 position = new Vector2 (player.transform.position.x, player.transform.position.y);

		return position;
	}

	public void RemoveBullet (BulletMLLib.Bullet deadBullet) {
		if(deadBullet == null) {
			throw new UnityException("MyBulletManager: RemoveBullet: bullet to remove is not defined.");
		}
		bullets.Remove ((MyBullet)deadBullet);
	}

	public BulletMLLib.Bullet CreateBullet (BulletMLLib.Emitter emitter) {
		if(emitter == null) {
			throw new UnityException("MyBulletManager: CreateBullet: emitter is not defined.");
		}

		//Idiotic inheritance lock accepting only emitter not able to normally pass GameObject when pattern spawns bullets
		MyEmitter myEmitter = ((MyEmitter)emitter);

		MyBullet newBullet = new MyBullet (this, myEmitter);

		newBullet.SetBullet (myEmitter.rootBullet.bulletPrefab);

		bullets.Add (newBullet);

		return newBullet;
	}

	#endregion
}

