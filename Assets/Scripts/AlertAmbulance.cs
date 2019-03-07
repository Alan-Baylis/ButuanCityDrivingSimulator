using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertAmbulance : MonoBehaviour {
    
    public bool isDoneAnnounce;
    private UIAmbulanceAlert alert;

	void Start() {
		alert = FindObjectOfType<UIAmbulanceAlert>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    public void Announce() {
        if(!alert.isOpen)
            // isDoneAnnounce = true;
            alert.Show();
    }
}
