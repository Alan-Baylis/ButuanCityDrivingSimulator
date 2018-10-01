using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightSensor : MonoBehaviour {

	public TrafficLight trafficLight;

	private void OnTriggerEnter(Collider collider) {
		Vector3 forward = transform.forward;
        Vector3 other = collider.transform.forward;
		if(collider.GetComponentInParent<CustomCarUserControl>() == null) {
			return;
		}
		if(Vector3.Dot(forward, other) > 0 && trafficLight.status == TrafficLightStatus.Stop) {
			AlertContainer.NewAlert("Red Light Violation - Php 1,500");
		}
	}
}
