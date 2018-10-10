using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    private Transform car;

    public Transform target;

    public bool rotateEnabled;
	
	// Update is called once per frame
	void LateUpdate () {
        if(car != null) {
            Vector3 newPosition = car.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            if(rotateEnabled) {
                transform.rotation = Quaternion.Euler(90f, car.eulerAngles.y, 0f);
            }
        }
	}

    void Update() {
        if(target != null) car = target;
        if(car == null && FindObjectOfType<CustomCarUserControl>() != null)
            car = FindObjectOfType<CustomCarUserControl>().transform;
    }
}
