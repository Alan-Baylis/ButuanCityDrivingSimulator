using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
public class VehicleSwitcher : MonoBehaviour {

	public Vector3 vehiclePosition;
	public Vector3 rotation;

	public CameraController mainCamera;
	public CameraController secondaryCamera;

	public GameObject carPrefab;
	public GameObject truckPrefab;

	public void SpawnCar() 
    {
		SpawnVehicle(carPrefab);
	}

	public void SpawnTruck() 
    {
		SpawnVehicle(truckPrefab);
	}

	private void SpawnVehicle(GameObject selectedVehicle)
    {
        GameObject spawned = (GameObject)Instantiate(selectedVehicle, vehiclePosition, Quaternion.Euler(rotation.x, rotation.y, rotation.z));
        Transform thirdPersonHelper = spawned.transform.Find("Helpers").Find("ThirdPersonCamera");
        Transform firstPersonHelper = spawned.transform.Find("Helpers").Find("FirstPersonCamera");

        SetCamera(mainCamera, true, thirdPersonHelper);
        SetCamera(secondaryCamera, false, firstPersonHelper);
        CloseVehicleSelectionPanel();
    }

    private void SetCamera(CameraController camera, bool enabled, Transform target) {
        camera.GetComponent<Camera>().enabled = enabled;
        camera.GetComponent<AudioListener>().enabled = enabled;
        camera.target = target;
    }
    
    private void CloseVehicleSelectionPanel() 
    {
        gameObject.SetActive(false);
    }
}
