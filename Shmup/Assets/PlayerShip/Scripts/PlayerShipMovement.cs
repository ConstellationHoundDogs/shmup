using UnityEngine;
using System.Collections;

public class PlayerShipMovement : MonoBehaviour {

	public float movementSpeed = 10f;
	public float boundaryOffset = 0.5f;

	public bool canControll = true;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 tempPos = transform.position;

		if(canControll){
			tempPos += new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * movementSpeed;

			float rightBoundary = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
			float leftBoundary = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
			float topBoundary = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
			float bottomBoundary = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;

			float spriteSizeX = GetDimensionInPX(gameObject).x / 2;
			float spriteSizeY = GetDimensionInPX(gameObject).y / 3; // finetuning sprite size

			tempPos.x = Mathf.Clamp(tempPos.x, leftBoundary + spriteSizeX, rightBoundary - spriteSizeX);
			tempPos.y = Mathf.Clamp(tempPos.y, bottomBoundary + spriteSizeY, topBoundary - spriteSizeY);
		}

		transform.position = tempPos;

	}


	private Vector2 GetDimensionInPX(GameObject obj) {
		Vector2 tmpDimension;
		
		tmpDimension.x = obj.transform.localScale.x / obj.GetComponent<SpriteRenderer>().sprite.bounds.size.x;  // this is gonna be our width
		tmpDimension.y = obj.transform.localScale.y / obj.GetComponent<SpriteRenderer>().sprite.bounds.size.y;  // this is gonna be our height
		
		return tmpDimension;
	}

}
