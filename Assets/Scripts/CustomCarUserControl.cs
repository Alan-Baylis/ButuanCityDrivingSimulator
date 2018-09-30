using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CustomCarUserControl : CarUserControl {

	bool isAlerted = false;

	void Update () {
		if(!isAlerted && m_Car.GetSpeed() > 41) {
			AlertContainer.NewAlert("Overspeeding - Php 1500");
			isAlerted = true;
		} else if(m_Car.GetSpeed() < 39){
			isAlerted = false;
		}
	}
}
