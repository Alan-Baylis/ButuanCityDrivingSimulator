using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class NoParkingArea : CarSensor {

    [SerializeField]
    private float waitTime = 5;

    private float timeLeft;

    private bool alerted;
	
	// Update is called once per frame
	void Update () {
        if(g == null) {
            alerted = false;
            return;
        }
        
        int speed = (int) g.GetComponentInParent<CarController>().GetSpeed();

        if(speed <= 0) {
            timeLeft -= Time.deltaTime;
        } else {
            timeLeft = waitTime;
        }

        if(timeLeft <= 0 && !alerted) {
            AlertContainer.NewAlert("No Parking - Php 1,500");
            alerted = true;
        }
	}
}
