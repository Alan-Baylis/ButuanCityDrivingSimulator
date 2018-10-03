using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTurnDetector : MonoBehaviour {
	List<UTurnDetector> uTurnDetectors;

	private void Start() {
		uTurnDetectors = new List<UTurnDetector>();
	}

	private void OnTriggerEnter(Collider other) {
		UTurnDetector detector = other.GetComponent<UTurnDetector>();
		if(detector == null) {
			uTurnDetectors.Clear();
			return;
		}
		uTurnDetectors.Add(detector);
		Detect();
	}

	private void Detect() {
		if(uTurnDetectors.Count == 3) {
			Debug.Log("U-TUrn");
			uTurnDetectors.Clear();
		}
	}
}
