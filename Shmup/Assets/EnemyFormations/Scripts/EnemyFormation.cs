using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemyFormation : MonoBehaviour {

	[Serializable]
	public struct EnemyPath {
		public GameObject enemy;
		public string pathName;
	}

	public List<EnemyPath> enemyPaths;


	// Use this for initialization
	void Start () {

		Debug.Log("Start called");

		foreach (EnemyPath enemyPath in enemyPaths)
		{
			GameObject enemy = (GameObject) Instantiate(enemyPath.enemy, transform.position, transform.rotation);
			enemy.transform.parent = transform.parent;
			iTween.MoveTo(enemy, iTween.Hash("path", iTweenPath.GetPath(enemyPath.pathName), "time", 6, "isLocal", true));
			
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
