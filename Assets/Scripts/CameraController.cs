using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float speed = 10;
    public float lookSpeed = 10;

    private void OnEnable() {
        Debug.Log("Enabled!");
    }

    public void LookAtTarget() {
        Vector3 lookDirection = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, lookSpeed * Time.deltaTime);
    }

    public void MoveToTarget() {
        Vector3 targetPosition = target.position 
            + target.forward * offset.z
            + target.right * offset.x
            + target.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void FixedUpdate() {
        if(target == null) {
            return;
        }
        LookAtTarget();
        MoveToTarget();
    }

    public void SwitchCamera() {
		bool state = true;
		Camera camera = GetComponent<Camera>();
		if(camera.enabled) {
			state = false;
		}
		camera.GetComponent<AudioListener>().enabled = state;
		camera.enabled = state;
	}
}
