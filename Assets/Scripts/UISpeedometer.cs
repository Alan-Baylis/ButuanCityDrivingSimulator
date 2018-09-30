using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class UISpeedometer : MonoBehaviour {

	[SerializeField]
    private Text speedText;
    [SerializeField]
    private Image speedometer;
    
    private CarController carToTrack;

	// Use this for initialization
	void Start()
    {
        carToTrack = FindObjectOfType<CarController>();
    }

    // Update is called once per frame
    void Update() 
    {
		UpdateSpeedText();
	}

    void UpdateSpeedText() 
    {
        int speed = (int) carToTrack.GetSpeed();
        speedText.text = speed.ToString() + " km/h";
        speedometer.fillAmount = (float) speed / 125;
    }
}
