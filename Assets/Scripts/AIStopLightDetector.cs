using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class AIStopLightDetector : MonoBehaviour {

    [SerializeField] private TrafficLight trafficLight;
    private CarAIControl ai;

    private void Start() {
        ai = GetComponent<CarAIControl>();
    }

    private void Update() {
        if(trafficLight == null || ai == null) {
            return;
        }
        if(trafficLight.status == TrafficLightStatus.Stop) {
            ai.HoldBrake();
            return;
        }
        ai.ReleaseBrake();
        RemoveTrafficLight();
    }

    public void SetTrafficLight(TrafficLight trafficLight)
    {
        this.trafficLight = trafficLight;
        Debug.Log("Setup Traffic Light");
    }

    public void RemoveTrafficLight()
    {
        this.trafficLight = null;
        Debug.Log("Remove Traffic Light");
    }
}
