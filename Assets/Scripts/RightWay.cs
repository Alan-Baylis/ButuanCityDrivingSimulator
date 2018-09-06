using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWay : CarSensor {
	
	void Update () {
		if(g != null) {
            CheckFlow();
        }
	}

    void CheckFlow() {
        Vector3 forward = transform.forward;
        Vector3 other = g.transform.forward;
        if(Vector3.Dot(forward, other) < 0) {
            Debug.Log("Counter Flow");
        }
    }
}
