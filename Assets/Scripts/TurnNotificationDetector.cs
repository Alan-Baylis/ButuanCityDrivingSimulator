using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnNotificationDetector : MonoBehaviour {

	public Sign sign;

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
        if(collider.GetComponentInParent<CustomCarUserControl>() == null) return;
        if(Vector3.Dot(forward, other) > 0) {
			string message = "";
			Sprite image = null;
			switch(sign) {
				case Sign.LeftTurn:
					message = "Prepare to turn left in curve road";
					image = turnNotification.sourceImages[0];
					break;
				case Sign.RightTurn: 
					message = "Prepare to turn right in curve road"; 
					image = turnNotification.sourceImages[1];
					break;
				case Sign.Deadend:
					message = "Prepare to slow down, dead end ahead"; 
					image = turnNotification.sourceImages[2];
					break;
				case Sign.Pedestrian:
					message = "Prepare to slow down, predestrian crossing ahead"; 
					image = turnNotification.sourceImages[3];
					break;
				case Sign.School:
					message = "Prepare to slowdown School Zone ahead"; 
					image = turnNotification.sourceImages[4];
					break;
				default: 
					Debug.Log("Nothing");
					break;
			}
			SetNotificationContent(message, image);
			turnNotification.Show();
        }
	}

	void SetNotificationContent(string text, Sprite sprite) {
		turnNotification.text.text = text;
		turnNotification.image.sprite = sprite;
	}
}

public enum Sign {
	LeftTurn, 
	RightTurn, 
	Pedestrian, 
	School,
	Deadend
}
