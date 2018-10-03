using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionDetector : MonoBehaviour {
	
	List<IntersectionIdentifier> detectors;

	private void Start() {
		detectors = new List<IntersectionIdentifier>();
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log("Enter");
		IntersectionIdentifier otherID = 
			other.GetComponent<IntersectionIdentifier>();

		if(otherID == null) {
			return;
		}
		if(Vector3.Dot(transform.forward, other.transform.forward) > 0) {
			Debug.Log("Index: " + otherID.GetIndex());
			detectors.Add(otherID);
		}
		if(detectors.Count < 2) {
			return;
		}
		CheckIdentifier();
	}

	void CheckIdentifier() {
		if(detectors[0].GetIndex() == 0 && detectors[1].GetIndex() == 3) {
			Debug.Log("Right Turn");
		} else if(detectors[0].GetIndex() == 3 && detectors[1].GetIndex() == 0) {
			AlertContainer.NewAlert("No Left Turn - Php 1,500");
		} else if(detectors[0].GetIndex() == detectors[1].GetIndex() + 1) {
			Debug.Log("Right Trurn");
		} else {
			AlertContainer.NewAlert("No Left Turn - Php 1,500");
		}
		detectors.Clear();
	}
}
