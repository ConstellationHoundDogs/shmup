using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

[SelectionBase]
public class Mover : MonoBehaviour {

	public float startWayPointWait = 0.0f;
	public bool isLocal;
	public bool loop;

	[Serializable]
	public class WayPoint{
		public Vector3 point;
		public float waitDuration;
		public float arrivalTime;
	}

	public List<WayPoint> wayPoints;

	//to start from zero array entity
	private int currentWayPointIndex = 0;
	
	// Use this for initialization
	void Start () {
		StartCurrentWayPoint (startWayPointWait);
	}

	void StartCurrentWayPoint(float waitUntilMove) {
		
		if(currentWayPointIndex >= wayPoints.Count){
			if(loop){
				currentWayPointIndex = 0;
			}else{
				OnMovementEnd();
				return;
			}
		}


		WayPoint nextWaypoint = wayPoints [currentWayPointIndex];
		MoveToWayPoint (nextWaypoint, waitUntilMove);
		
		currentWayPointIndex++;
	}



	void MoveToWayPoint (WayPoint wayPoint, float delay){

		GameObject objectToMove = (gameObject.transform.parent.gameObject) ? gameObject.transform.parent.gameObject : gameObject;

		iTween.MoveTo(objectToMove, iTween.Hash("isLocal", isLocal,
		                                      "position", wayPoint.point,
		                                      "time", wayPoint.arrivalTime,
		                                      "onCompleteTarget", gameObject,
		                                      "onComplete", "StartCurrentWayPoint",
		                                      "oncompleteparams", wayPoint.waitDuration,
		                                      "delay", delay));
	}



	void Destroy(){
		OnMovementEnd ();
	}
	
	void OnMovementEnd() {

	}

	void OnDrawGizmos(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, 0.5f);
	}
}
