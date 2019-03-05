using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertAmbulance : MonoBehaviour {
    
    public bool isDoneAnnounce;
    private UIAmbulanceAlert turnNotification;

	void Start() {
		turnNotification = FindObjectOfType<UIAmbulanceAlert>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Announce() {
        if(!turnNotification.isOpen)
            isDoneAnnounce = true;
            turnNotification.Show();
    }
}
