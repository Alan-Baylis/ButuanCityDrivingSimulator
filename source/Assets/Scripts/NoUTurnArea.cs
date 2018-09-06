using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoUTurnArea : CarSensor {

    private float entranceDot;
    private float exitDot;
    private Vector3 forward;

    void Awake() {
        forward = transform.TransformDirection(Vector3.forward);
    }

    public override void OnTriggerEnter(Collider collider) {
        g = collider.gameObject;
        entranceDot = Vector3.Dot(g.transform.forward, forward);
    }

    public override void OnTriggerExit(Collider collider) {
        Vector3 colliderForward = g.transform.forward * Mathf.RoundToInt(entranceDot);
        exitDot = Vector3.Dot(colliderForward, forward) * Mathf.RoundToInt(entranceDot);
        
        if(exitDot > -0.5 && exitDot < 0.5 && colliderForward.x  > 0) {
            Debug.Log("Right-Turn");
        } else if(exitDot > -0.4 && exitDot < 0.4 && colliderForward.x < 0) {
            Debug.Log("Left-Turn");
        } else if(exitDot > -1.0 && exitDot < -0.7) {
            Debug.Log("U-Turn");
        }

        g = null;
    }
}
