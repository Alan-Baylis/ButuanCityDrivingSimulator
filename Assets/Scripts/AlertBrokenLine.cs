using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertBrokenLine : MonoBehaviour {
    
    public bool isDoneAnnounce;
    private UIBrokenLineAlert alert;

	void Start() {
		alert = FindObjectOfType<UIBrokenLineAlert>();
	}

    void OnTriggerEnter(Collider collider) {
        Announce();
    }

    public void Announce() {
        if(!alert.isOpen)
            isDoneAnnounce = true;
            alert.Show();
    }
}
