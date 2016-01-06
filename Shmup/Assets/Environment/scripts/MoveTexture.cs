using UnityEngine;
using System.Collections;

public class MoveTexture : MonoBehaviour {

	public float horizontalSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = GetComponent<Renderer>().material.mainTextureOffset;

		offset.y += horizontalSpeed * Time.deltaTime;

		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
