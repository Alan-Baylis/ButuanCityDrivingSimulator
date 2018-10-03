using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class UISpeedometer : MonoBehaviour {

	[SerializeField]
    private Text speedText;
    [SerializeField]
    private Image speedometer;
    
    private CustomCarUserControl carToTrack;

	// Use this for initialization
	void Start()
    {
        carToTrack = FindObjectOfType<CustomCarUserControl>();
    }

    // Update is called once per frame
    void Update() 
    {
		UpdateSpeedText();
	}

    void UpdateSpeedText() 
    {
        if(carToTrack != null) {
            int speed = (int) carToTrack.GetComponent<CarController>().GetSpeed();
            speedText.text = speed.ToString() + " km/h";
            speedometer.fillAmount = (float) speed / 125;
            return;
        }
        carToTrack = FindObjectOfType<CustomCarUserControl>();
    }
}
