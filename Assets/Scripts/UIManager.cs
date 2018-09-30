using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text speedText;
    [SerializeField]
    private Image speedometer;
    [SerializeField]
    private CarController carToTrack;

	// Use this for initialization
	void Start()
    {
        DisableSpeedometer();
    }

    // Update is called once per frame
    void Update() 
    {
        if(carToTrack == null) 
        {
            Debug.LogError("Car to track not set.");
            enabled = false;
            return;
        }
        if(speedometer == null) 
        {
            Debug.LogError("Speedometer Image not set.");
            enabled = false;
            return;
        }
        if(speedText == null) 
        {
            Debug.LogError("Speedometer Text not set.");
            enabled = false;
            return;
        }
		UpdateSpeedText();
	}

    void UpdateSpeedText() 
    {
        int speed = (int) carToTrack.GetSpeed();
        speedText.text = speed.ToString() + " km/h";
        speedometer.fillAmount = (float) speed / 125;
    }

    public void SetCar(CarController car) 
    {
        carToTrack = car;
        enabled = true;
    }

    public void EnableSpeedometer() 
    {
        speedometer.enabled = true;
        speedText.enabled = true;
    }

    private void DisableSpeedometer()
    {
        speedText.enabled = false;
        speedometer.enabled = false;
    }

}
