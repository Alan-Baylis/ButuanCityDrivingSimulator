using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSensor : MonoBehaviour {

    [HideInInspector]
    public GameObject g;

    public virtual void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.GetComponentInParent<CustomCarUserControl>() != null) {
            g = collider.gameObject;
        }
    }

    public virtual void OnTriggerExit(Collider collider) {
        if(g == collider.gameObject) {
            g = null;
        }
    }
}
