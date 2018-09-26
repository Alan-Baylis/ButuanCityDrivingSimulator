using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAlert : MonoBehaviour {

	public bool autoClose;

	public void Close() {
		Destroy(gameObject);
	}

	void Start() {
		if(autoClose) {
			StartCoroutine(CloseSelf());
		}
	}

	IEnumerator CloseSelf() {
		yield return new WaitForSeconds(2.5f);
		Close();
	}
}
