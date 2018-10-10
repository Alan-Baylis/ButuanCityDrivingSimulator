using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class AITrafficAwareness : MonoBehaviour {

    public LayerMask mask;

    private CarAIControl ai;
    private bool shouldStop;

    private TrafficLight trafficLight;

    private void Start() {
        ai = GetComponent<CarAIControl>();
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
    
    private void FixedUpdate() {
        CastRay();
        ai.ReleaseBrake();
        if(shouldStop) {
            ai.HoldBrake();
        } else {
            ai.ReleaseBrake();
        }
        if(trafficLight == null) {
            return;
        }
        if(trafficLight.status == TrafficLightStatus.Go) {
            ai.ReleaseBrake();
            RemoveTrafficLight();
            return;
        }
        ai.HoldBrake();
    }

    private void CastRay() {
        Vector3 origin = transform.position;
        origin.y = transform.position.y + 0.30f;
        Ray ray = new Ray(origin, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 7f, mask)) {
            AINotifyStop notifyStop = hit.collider.GetComponent<AINotifyStop>();
            Vector3 forward = transform.forward;
            Vector3 other = hit.collider.transform.forward;
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            if(notifyStop != null && Vector3.Dot(forward, other) > 0) {
                trafficLight = notifyStop.trafficLight;
            }
            if(notifyStop != null) return;
            shouldStop = true;
        } else {
            shouldStop = false; 
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 7f, Color.green);
        }
    }
}
