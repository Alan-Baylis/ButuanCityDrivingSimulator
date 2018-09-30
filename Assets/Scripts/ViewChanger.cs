using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewChanger : MonoBehaviour {

	public CameraController mainCamera;
	public CameraController secondaryCamera;

	void Start () {
		SetupCameras();
	}
	
	public void SwitchView() {
		mainCamera.SwitchCamera();
		secondaryCamera.SwitchCamera();
	}

	private void SetupCameras() {
		mainCamera.GetComponent<Camera>().enabled = true;
		mainCamera.GetComponent<AudioListener>().enabled = true;
		secondaryCamera.GetComponent<Camera>().enabled = false;
		secondaryCamera.GetComponent<AudioListener>().enabled = false;
	}
}
