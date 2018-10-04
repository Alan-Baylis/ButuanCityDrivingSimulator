using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTurnDetector : MonoBehaviour {
	List<UTurnIdentifier> uTurnIdentifiers;

	private void Start() {
		uTurnIdentifiers = new List<UTurnIdentifier>();
	}

	private void OnTriggerEnter(Collider other) {
		UTurnIdentifier detector = other.GetComponent<UTurnIdentifier>();
		if(detector == null) {
			return;
		}
		uTurnIdentifiers.Add(detector);
		for (int i = 0; i < uTurnIdentifiers.Count; i++)
		{
			Debug.Log(uTurnIdentifiers[i].index);
			if(uTurnIdentifiers[i].index != i + 1) {
				uTurnIdentifiers.Clear();
				return;
			}	
		}
		Detect();
	}

	private void Detect() {
		if(uTurnIdentifiers.Count == 3) {
			if(uTurnIdentifiers[0].index == 1 
				&& uTurnIdentifiers[1].index == 2 
				&& uTurnIdentifiers[2].index == 3) {
				AlertContainer.NewAlert("U-Turn - Php 1,500");
				uTurnIdentifiers.Clear();
			}
		}
	}
}
