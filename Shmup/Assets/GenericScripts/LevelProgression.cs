using UnityEngine;
using System.Collections;

public class LevelProgression : MonoBehaviour {

	public float progressionSpeed = -1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.up * Time.deltaTime * progressionSpeed;
	}
}
