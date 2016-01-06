using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BulletMLLib;
using System;

public class EnemyController : MonoBehaviour {

	[Serializable]
	public struct EmmiterNode {
		public GameObject emitter;
		public float ttl;
	}

	public int hp;
	public GameObject particles;

	public List<EmmiterNode> shootingMap;
	public bool loop;

	public EmmiterNode currentEmitterNode;

	private GameObject currentEmitterGameObject;

	private int currentEmitterNodeIndex = 0;
	private Time emitterTime;

	// Use this for initialization
	void Start () {
		executeNode ();
	}
	
	// Update is called once per frame
	void Update () {

	}

 
	private void executeNode(){
		if(currentEmitterNodeIndex >= shootingMap.Count){
			if(loop){
				currentEmitterNodeIndex = 0;
			}else{
				if(currentEmitterGameObject != null){
					Destroy(currentEmitterGameObject);
				}
				return;
			}
		}

		startNewEmmiterNode (currentEmitterNodeIndex);
		currentEmitterNodeIndex++;

		float timeToWait = currentEmitterNode.ttl;

		Invoke ("executeNode", timeToWait);
	}

	private void startNewEmmiterNode (int emitterNodeNumber) {

		if( (emitterNodeNumber < 0) || (emitterNodeNumber >= shootingMap.Count)){
			throw new UnityException("emitterNodeNumber: " +  emitterNodeNumber + " is out of bounds!");
		}

		currentEmitterNode = shootingMap [emitterNodeNumber];

		if(currentEmitterNode.emitter == null){
			return;
		}

		if(currentEmitterGameObject != null){
			Destroy(currentEmitterGameObject);
		}

		currentEmitterGameObject = Instantiate (currentEmitterNode.emitter, transform.position, transform.rotation) as GameObject;
		currentEmitterGameObject.transform.parent = transform;


	}



	public void TakeDamage (int howMuch) {
		if (hp <= 0) {
			if(particles != null) {
				Instantiate(particles, transform.position, transform.rotation);
			}
			Destroy(gameObject);
		} else {
			hp -= howMuch;
		}
	}
}
