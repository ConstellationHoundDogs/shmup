using UnityEngine;
using System.Collections;

public class BulletEmitter : MonoBehaviour {

	public GameObject bullet;
	public string patternPath;
	
	private MyEmitter emitter;
	private MyBulletManager bulletManager;
	private PatternManager patternManager;
	private MyBullet rootBullet;
	
	// Use this for initialization
	void Start () {

		bulletManager = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<BulletManager> ().myBulletManager;

		///

		if (bulletManager == null) {
			throw new UnityException("BulletEmitter: bulletManager is not defined.");
		}

		rootBullet = new MyBullet (bulletManager, bullet);

		patternManager = GameObject.FindGameObjectWithTag("PatternManager").GetComponent<PatternManager> ();

		///

		if (patternManager == null) {
			throw new UnityException("BulletEmitter: patternManager is not defined.");
		}

		BulletMLLib.BulletPattern pattern = patternManager.GetPatternByPath (patternPath);
		emitter = new MyEmitter (bulletManager, pattern, rootBullet);
		emitter.Update (transform.position.x, transform.position.y);
		//Hide root bullet
		rootBullet.bulletPrefab.SetActive (false);
		Destroy (rootBullet.bulletPrefab, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		if(emitter != null){
			emitter.Update (transform.position.x, transform.position.y);
		}
	}
}

public class MyBullet : BulletMLLib.Bullet {

	public GameObject bulletPrefab;

	private float initialZRotation;
	
	public MyBullet(BulletMLLib.IBulletManager myBulletManager, GameObject bullet)
		: base(myBulletManager) {
		TimeSpeed = 1;
		Scale = 1;
		bulletPrefab = bullet;
	}

	public MyBullet(BulletMLLib.IBulletManager myBulletManager, MyEmitter e) : base(myBulletManager) {
		Emitter = e;
	}

	public void SetBullet (GameObject bullet) {
		bulletPrefab = bullet;
	}
	
	public override void Update () {
		base.Update ();
		if (bulletPrefab != null) {
			bulletPrefab.transform.position = new Vector3 (X, Y, 0);
			bulletPrefab.transform.eulerAngles = new Vector3 (0, 0, initialZRotation + (Direction * 180 / Mathf.PI));
		}
	}

	
	#region implemented abstract members of Bullet

	public override void BulletSpawned () {
		if (bulletPrefab == null) {
			return;
		}

		initialZRotation = bulletPrefab.transform.rotation.eulerAngles.z;

		bulletPrefab = GameObject.Instantiate (bulletPrefab, new Vector3(X, Y), Quaternion.Euler(new Vector3(0,0, initialZRotation + (Direction * 180/Mathf.PI)))) as GameObject;
		bulletPrefab.SetActive (true);
	}

	public override float X { get; set; }
	public override float Y { get; set; }

	#endregion

}

public class MyEmitter : BulletMLLib.Emitter {

	public BulletMLLib.IBulletManager bulletManager;
	public MyBullet rootBullet;
	
	public MyEmitter(BulletMLLib.IBulletManager _bulletManager, BulletMLLib.BulletPattern pattern, MyBullet bl) : base(_bulletManager, pattern, bl)	{
		rootBullet = bl;
		bulletManager = _bulletManager;
	}

}
