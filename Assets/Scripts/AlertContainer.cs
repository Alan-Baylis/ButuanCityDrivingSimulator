using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlertContainer : MonoBehaviour {

	public GameObject alertPrefab;
	public GameObject alertContainer;
	public GameObject violationContainer;

	private List<string> violations = new List<string>();

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
		GameObject alert = Instance.Alert(text, true);
		GameObject violation = Instance.Alert(text, false);

		violation.transform.SetParent(Instance.violationContainer.transform);
		violation.transform.localScale = Vector3.one;

		alert.transform.SetParent(Instance.alertContainer.transform);
		alert.transform.localScale = Vector3.one;
	}

	public GameObject Alert(string text, bool autoClose) {
		GameObject alert = (GameObject) Instantiate(Instance.alertPrefab);
		Instance.violations.Add(text);
		alert.GetComponent<UIAlert>().autoClose = autoClose;
		alert.GetComponentInChildren<TextMeshProUGUI>().text = text;
		return alert;
	}
}
