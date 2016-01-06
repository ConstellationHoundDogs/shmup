//using UnityEngine;
//using System.Linq;
//using System.Collections;
//using System.Collections.Generic;
//using BulletMLLib;
//
//public class BulletMLTest : MonoBehaviour {
//
//	public GameObject bullet;
//
//	private FakeBulletManager bm;
//	private FakeEmitter emitter;
//	private FakeBullet fakeBullet;
//
//	private PatternManager patternManager;
//
//
//	// Use this for initialization
//	void Start () {
//
//		patternManager = GameObject.Find("PatternManager").GetComponent<PatternManager>();
//
//		bm = new FakeBulletManager();
//		
//		GameManager.GameDifficulty = () => 1f;
//		
//		BulletPattern pattern = patternManager.GetPatternByPath("./Assets/example.xml");
//
//		fakeBullet = new FakeBullet(bm, bullet);
//
//		emitter = new FakeEmitter(bm, pattern, fakeBullet);
//
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		emitter.Update (0, 0);
//		for (int ii = 0; ii < bm.Bullets.Count; ii++) {
//			bm.Bullets [ii].Update ();
//		}
//	}
//}
//
//public class FakeEmitter : Emitter
//{
//	IBulletManager _bulletManager;
//	Bullet rootBullet;
//
//	public FakeEmitter(IBulletManager bulletManager, BulletPattern pattern, Bullet bl) : base(bulletManager, pattern, bl)
//	{
//		rootBullet = bl;
//		_bulletManager = bulletManager;
//	}
//
//}
//
//public class FakeBullet : Bullet
//{
//
//	public Bullet _bullet;
//	
//	public FakeBullet(IBulletManager myBulletManager, GameObject bullet)
//		: base(myBulletManager)
//	{
//		TimeSpeed = 1;
//		Scale = 1;
//		_bullet = bullet;
//	}
//	
//	
//	public FakeBullet(IBulletManager myBulletManager, FakeEmitter e) : base(myBulletManager)
//	{
//		Emitter = e;
//		_bullet = e.rootBullet;
//	}
//	
//	public bool IsActive { get; set; }
//	
//	public override void BulletSpawned()
//	{
//		// instantiate prefab or something..
//
//		_bullet = MonoBehaviour.Instantiate (_bullet, new Vector3(X, Y, 0), Quaternion.Euler(new Vector3(0,0, Direction * 180/Mathf.PI))) as GameObject;
//
//		//Debug.Log ("Direction: " + Direction);
//
//	}
//
//	public override void Update(){
//		base.Update ();
//
//		_bullet.transform.position = new Vector3(X, Y);
//		_bullet.transform.eulerAngles = new Vector3 (0, 0, Direction * 180/Mathf.PI);
//
//		//Debug.Log ("Direction: " + Direction);
//
//	}
//	
//	public override float X { get; set; }
//	public override float Y { get; set; }
//	
//}
//
//public class FakeBulletManager : IBulletManager
//{
//	private GameObject player;
//
//	public List<FakeBullet> Bullets = new List<FakeBullet>();
//
//	public FakeBulletManager () {
//		player = GameObject.Find ("PlayerShip");
//	}
//
//	public Vector2 PlayerPosition(Bullet targettedBullet)
//	{
//		return new Vector2(player.transform.position.x, player.transform.position.y);
//	}
//
//	public void RemoveBullet(Bullet deadBullet)
//	{
//		//Debug.Log ("Bullet removed: " + deadBullet);
//		var b = Bullets.Single(x => x == deadBullet);
//		b.IsActive = false;
//	}
//	
//	public Bullet CreateBullet(Emitter e)
//	{
//		var bullet = new FakeBullet(this, e);
//		Bullets.Add(bullet);
//		return bullet;
//	}
//}
//




