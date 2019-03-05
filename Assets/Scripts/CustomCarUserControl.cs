using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CustomCarUserControl : CarUserControl {

	bool isAlerted = false;
    public int speedLimit = 41;

	void Update () {
        if(speedLimit == 0) {
            return;
        }
		if(!isAlerted && m_Car.GetSpeed() > speedLimit) {
			AlertContainer.NewAlert("Overspeeding - Php 1500");
			isAlerted = true;
		} else if(m_Car.GetSpeed() < speedLimit - 2){
			isAlerted = false;
		}
	}
}
