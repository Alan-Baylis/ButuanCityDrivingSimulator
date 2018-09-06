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
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateSpeedText();
	}

    void UpdateSpeedText() {
        int speed = (int) carToTrack.GetSpeed();
        speedText.text = speed.ToString() + " km/h";
        speedometer.fillAmount = (float) speed / 125;
    }
}
