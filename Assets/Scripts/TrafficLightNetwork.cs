using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightNetwork : MonoBehaviour {

	public float greenDuration = 12f;
	public float yellowDuration = 2f;

	private TrafficLight[] trafficLights;

	void Start () {
		float delay = 0f;
		trafficLights = GetComponentsInChildren<TrafficLight>();
		for (int i = 0; i < trafficLights.Length; i++)
		{
			trafficLights[i].SetGreenDuration(greenDuration);
			trafficLights[i].SetYellowDuration(this.yellowDuration);
			trafficLights[i].SetRedDuration((greenDuration + (yellowDuration / 2f)) * (trafficLights.Length - 1));
			StartCoroutine(trafficLights[i].Initiate(delay));
			delay += (greenDuration + yellowDuration);
		}
	}
}
