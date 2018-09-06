using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoadSign : MonoBehaviour {

    [SerializeField]
    private RoadSignType signType;
    [SerializeField]
    private int speed;
    [SerializeField]
    private SpeedLimitArea speedLimitArea;
    [SerializeField]
    private NoParkingArea noParkingArea;
    [SerializeField]
    private List<GameObject> models;

    private TextMeshProUGUI text;

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

