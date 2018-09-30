using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnNotificationDetector : MonoBehaviour {

	public Direction direction;

	private UITurnNotification turnNotification;

	void Start() {
		turnNotification = FindObjectOfType<UITurnNotification>();
	}

	void OnTriggerEnter(Collider collider) {
		NotifyDirection(collider);
    }

	void NotifyDirection(Collider collider) {
		Vector3 forward = transform.forward;
        Vector3 other = collider.transform.forward;
        
        if(Vector3.Dot(forward, other) > 0) {
			if(direction == Direction.Left) {
				SetNotificationContent("Prepare to turn left in curve road", turnNotification.sourceImages[0]);
				turnNotification.Show();
				return;
			}
			SetNotificationContent("Prepare to turn right in curve road", turnNotification.sourceImages[1]);
			turnNotification.Show();
			return;
        }
	}

	void SetNotificationContent(string text, Sprite sprite) {
		turnNotification.text.text = text;
		turnNotification.image.sprite = sprite;
	}
}

public enum Direction {
	Left, Right
}
