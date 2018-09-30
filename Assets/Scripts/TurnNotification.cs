using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnNotification : MonoBehaviour {

	public Direction direction;

	void OnTriggerEnter(Collider collider) {
		NotifyDirection(collider);
    }

	void NotifyDirection(Collider collider) {
		Vector3 forward = transform.forward;
        Vector3 other = collider.transform.forward;
        
        if(Vector3.Dot(forward, other) > 0) {
			if(direction == Direction.Left) {
				Debug.Log("Turn Left");
				return;
			}
			Debug.Log("Turn Right");
			return;
        }
	}
}
public enum Direction {
	Left, Right
}
