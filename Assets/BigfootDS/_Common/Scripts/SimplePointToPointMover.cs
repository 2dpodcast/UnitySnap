using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigfootDS;

namespace BigfootDS {
	public class SimplePointToPointMover : MonoBehaviour {

		public float destinationStopDelay = 1;
		public  float destinationDistanceOffset = 0.5f;
		public Transform[] pointsToMoveBetween;
		int pointIndex = 0;
		public float movementSpeed = 5;
		public bool isStopped = false;
		
		void OnEnable () {
			StartCoroutine (SimplePointToPointRoutine ());
		}



		IEnumerator SimplePointToPointRoutine () {
			while (true) {
				if (Vector3.Distance (transform.position, pointsToMoveBetween [pointIndex].position) < destinationDistanceOffset) {
					if (!isStopped) {
						isStopped = true;
						yield return new WaitForSeconds (destinationStopDelay);
					}
					pointIndex++;
					isStopped = false;
				}
				if (pointIndex >= pointsToMoveBetween.Length) {
					pointIndex = 0;
				}
				transform.LookAt (pointsToMoveBetween [pointIndex]);
				transform.position += transform.forward * movementSpeed * Time.deltaTime;

				yield return new WaitForEndOfFrame();
			}
		}



	}
}