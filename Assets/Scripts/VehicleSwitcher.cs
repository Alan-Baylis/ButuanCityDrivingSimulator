using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
public class VehicleSwitcher : MonoBehaviour {

	public Transform vehicleTransform;

	public CameraController mainCamera;
	public CameraController secondaryCamera;

	public GameObject carPrefab;
	public GameObject truckPrefab;

	public GameObject spawned;

	public void SpawnCar() 
    {
		SpawnVehicle(carPrefab);
	}

    public void SetPositionAndRotation() {
        spawned.transform.position = vehicleTransform.position;
        spawned.transform.localRotation = vehicleTransform.rotation;
        ResetSpeed();
    }

    private void ResetSpeed() {
        if(spawned != null) {
            spawned.GetComponent<CarController>().ResetSpeed();
        }
    }

	public void SpawnTruck() 
    {
		SpawnVehicle(truckPrefab);
	}

	private void SpawnVehicle(GameObject selectedVehicle)
    {
        spawned = (GameObject)Instantiate(selectedVehicle);
        SetPositionAndRotation();
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
