using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertContainer : MonoBehaviour {

	public GameObject alertPrefab;
	public GameObject alertContainer;
	private static AlertContainer _Instance;

	public static AlertContainer Instance {
		get {
			if(_Instance == null) {
				_Instance = GameObject.FindObjectOfType<AlertContainer>();
			}
			return _Instance;
		}
	}
	// Use this for initialization
	void Start () {
		if(alertContainer == null) {
			alertContainer = this.gameObject;
		}
	}
	
	public static void NewAlert(string text) {
		GameObject alert = (GameObject) Instantiate(Instance.alertPrefab);
		alert.GetComponentInChildren<Text>().text = text;
		alert.transform.SetParent(Instance.alertContainer.transform);
		alert.transform.localScale = Vector3.one;
	}
}
