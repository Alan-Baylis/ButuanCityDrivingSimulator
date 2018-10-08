using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraController : MonoBehaviour {

    public float panSpeed = 100f;
    public float panBorder = 20f;
    public Vector2 panLimitMax;
    public Vector2 panLimitMin;

    private GameObject car;

    private void OnEnable() {
        if(FindObjectOfType<CustomCarUserControl>() != null)
            car = FindObjectOfType<CustomCarUserControl>().gameObject;
        if(car != null) {
            Vector3 newPosition = car.transform.position;
            newPosition.y = 250f;
            newPosition.z = newPosition.z - 120;
            transform.position = newPosition;
        }
    }

	void Update () {
        Vector3 position = transform.position;

        if(Input.mousePosition.y >= Screen.height - panBorder) {
            position.z += panSpeed * Time.deltaTime;
        }
        if(Input.mousePosition.y <= panBorder) {
            position.z -= panSpeed * Time.deltaTime;
        }
        if(Input.mousePosition.x >= Screen.width - panBorder) {
            position.x += panSpeed * Time.deltaTime;
        }
        if(Input.mousePosition.x <= panBorder) {
            position.x -= panSpeed * Time.deltaTime;
        }

        position.x = Mathf.Clamp(position.x, panLimitMin.x, panLimitMax.x);
        position.z = Mathf.Clamp(position.z, panLimitMin.y, panLimitMax.y);

        transform.position = position;
	}
}
