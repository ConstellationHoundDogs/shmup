using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using BulletMLLib;


public class PatternManager : MonoBehaviour {

	private Dictionary<string, BulletPattern> patterns = new Dictionary<string, BulletPattern>();


	// If there such name for pattern exist in dictionary it will be rewritten
	public string RegisterPattern (string path) {

		if(path.Equals("")){
			return null;
		}

		try{
			BulletPattern newPattern = new BulletPattern (path);
			patterns.Add(path, newPattern);

		}catch (Exception e) {
			Debug.LogError("Error loading a pattern XML file: " + e.Message);
		}

		return path;

	}

	public BulletPattern GetPatternByPath (string path) {

		if(!patterns.ContainsKey(path)){
			throw new Exception("No such pattern requested by path: " + path);
		}

		return  patterns[path]; 
	}


	// Use this for initialization
	void Awake () {
		RegisterPattern ("./Assets/example.xml");
		RegisterPattern ("./Assets/example2.xml");
	}

}
