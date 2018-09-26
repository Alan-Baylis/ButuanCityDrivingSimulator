using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoadSign : MonoBehaviour {

    
    public RoadSignType signType;
    public int speed;
    public SpeedLimitArea speedLimitArea;
    public NoParkingArea noParkingArea;
    public List<GameObject> models;
    public TextMeshProUGUI text;

    void Awake() {
        InstantiateModel();
        SetSpeedLimit();
		text = GetComponentInChildren<TextMeshProUGUI>();
    }

	void Start () 
    {
        if(text != null) {
            text.text = speed.ToString();
        }
	}

    void SetSpeedLimit() {
        if(speedLimitArea != null) 
            speedLimitArea.SetSpeedLimit(speed);
    }

    void InstantiateModel() {
        foreach (GameObject model in models)
        {
            if(model.name.Equals(signType.ToString())) {
                GameObject sign = Instantiate(model, transform.position, Quaternion.identity);
                sign.transform.SetParent(transform);
                return;
            }
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, .5f);
        Gizmos.color = Color.green;
        if(noParkingArea != null)
            Gizmos.DrawLine(transform.position + Vector3.up, noParkingArea.transform.position);
        if(speedLimitArea != null)
            Gizmos.DrawLine(transform.position + Vector3.up, speedLimitArea.transform.position);
    }
}
public enum RoadSignType {
    SpeedLimit,
    NoParking
}

