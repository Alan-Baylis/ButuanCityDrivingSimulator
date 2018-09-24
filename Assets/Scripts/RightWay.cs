using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWay : CarSensor {
	
    private bool alerted = false;

	void Update () {
		if(g != null) {
            CheckFlow();
            return;
        }
        alerted = false;
	}

    void CheckFlow() {
        Vector3 forward = transform.forward;
        Vector3 other = g.transform.forward;
        
        Debug.Log(Vector3.Dot(forward, other));
        if(Vector3.Dot(forward, other) < -0.8f) {
            if(!alerted) {
                AlertContainer.NewAlert("Counter Flow");
                alerted = true;
            }
        }
    }
}
