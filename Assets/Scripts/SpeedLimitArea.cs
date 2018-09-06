using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SpeedLimitArea : CarSensor {

    private int speedLimit;

    void Update() {
        if(g == null) {
            return;
        }
        CheckSpeed();
    }

    void CheckSpeed() {
        int speed = (int) g.GetComponentInParent<CarController>().GetSpeed();
        if(speed > speedLimit) {
            Debug.Log("Exceeded maximum speed of " + speedLimit + " km/h");
        }
    }

    public void SetSpeedLimit(int speedLimit) {
        this.speedLimit = speedLimit;
    }

    public int GetSpeedLimit() {
        return this.speedLimit;
    }
}
