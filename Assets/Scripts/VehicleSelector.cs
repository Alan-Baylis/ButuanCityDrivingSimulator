using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
public class VehicleSelector : MonoBehaviour {

	public Vector3 vehiclePosition;

	public Camera mainCamera;
	public Camera secondaryCamera;
	public GameObject car;
	public GameObject truck;
	public GameObject background;
	public UIManager uIManager;

	void Start() {

	}

	public void SpawnCar() 
    {
		SpawnVehicle(car);
	}

	public void SpawnTruck() 
    {
		SpawnVehicle(truck);
	}

	private void SpawnVehicle(GameObject selectedVehicle)
    {
        GameObject spawned = (GameObject)Instantiate(selectedVehicle, vehiclePosition, Quaternion.identity);
        CarController car = spawned.GetComponent<CarController>();
        Transform thirdPersonHelper = spawned.transform.Find("Helpers").Find("ThirdPersonCamera");
        

        SetUIManager(car);
        SetMainCamera(thirdPersonHelper);
        CloseVehicleSelectionPanel();
    }

    private void SetMainCamera(Transform thirdPersonHelper)
    {
        CameraController mainCameraController = mainCamera.GetComponent<CameraController>();
        mainCameraController.enabled = true;
        mainCameraController.target = thirdPersonHelper;
    }

    private void SetUIManager(CarController car)
    {
        uIManager.SetCar(car);
        uIManager.EnableSpeedometer();
    }
    
    private void CloseVehicleSelectionPanel() 
    {
        background.SetActive(false);
    }
}
