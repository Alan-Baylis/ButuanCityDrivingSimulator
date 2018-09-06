using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class NoParkingArea : CarSensor {

    [SerializeField]
    private float waitTime = 5;

    private float timeLeft;
	
	// Update is called once per frame
	void Update () {
        if(g == null) return;
        
        int speed = (int) g.GetComponentInParent<CarController>().GetSpeed();

        if(speed <= 0) {
            timeLeft -= Time.deltaTime;
        } else {
            timeLeft = waitTime;
        }

        if(timeLeft <= 0) {
            Debug.Log("No Parking " + speed);
        }
	}
}
