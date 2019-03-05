using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAmbulance : MonoBehaviour {

    AlertAmbulance alert;
    [SerializeField]
    LayerMask mask;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CastRay();
	}
    
    private void CastRay() {
        Vector3 origin = transform.position;
        origin.y = transform.position.y + 0.30f;
        Ray ray = new Ray(origin, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100f, mask)) {
            alert = hit.collider.transform.root.GetComponent<AlertAmbulance>();
            Debug.Log(alert);
            if(alert != null && !alert.isDoneAnnounce) {
                alert.Announce();
            }
        } else {
        }
    }
}
