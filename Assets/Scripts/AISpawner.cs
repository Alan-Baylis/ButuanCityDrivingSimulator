using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class AISpawner : MonoBehaviour {

    public GameObject[] vehicles;
    public WaypointCircuit waypointCircuit;
    public int maximumVehicleCount;
    public float delayInSeconds = 5f;

    private int vehicleCount;
    private Coroutine coroutine;

	// Use this for initialization
	void Start () {
		coroutine = StartCoroutine(SpawnCar(delayInSeconds));
	}

    private void Update() {
        if(vehicleCount == maximumVehicleCount) {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator SpawnCar(float delayInSeconds) {
        delayInSeconds = Random.Range((float)delayInSeconds-2, (float)delayInSeconds+2);
        yield return new WaitForSeconds(delayInSeconds);
        int randomIndex = Random.Range(0,vehicles.Length);
        GameObject aiVechicle = Instantiate(vehicles[randomIndex], transform.position, transform.rotation);
        aiVechicle.transform.parent = gameObject.transform;
        aiVechicle.GetComponent<WaypointProgressTracker>().SetWaypointCircuit(waypointCircuit);
        vehicleCount += 1;
        coroutine = StartCoroutine(SpawnCar(delayInSeconds));
    }
}
