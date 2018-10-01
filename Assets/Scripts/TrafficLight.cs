using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour {

	public GameObject[] lights;
	public TrafficLightStatus status;

	private float greenDuration;
	private float yellowDuration;
	private float redDuration;

    public IEnumerator Initiate(float delayInSeconds)
    {
		if(delayInSeconds > 0) {
			lights[4].SetActive(true);
			lights[5].SetActive(true);
		}
		yield return new WaitForSeconds(delayInSeconds);
        StartCoroutine(Green());
    }

    void Awake () {
		OffAll();
	}

	void OffAll() {
		for (int i = 0; i < lights.Length; i++)
		{
			lights[i].SetActive(false);
		}
	}

	IEnumerator Green() {
		OffAll();
		status = TrafficLightStatus.Go;
		lights[0].SetActive(true);
		lights[1].SetActive(true);
		yield return new WaitForSeconds(greenDuration);
		StartCoroutine(Yellow());
	}

	IEnumerator Yellow() {
		OffAll();
		lights[2].SetActive(true);
		lights[3].SetActive(true);
		yield return new WaitForSeconds(yellowDuration);
		if(status == TrafficLightStatus.Go) {
			StartCoroutine(Red());
		} else {
			StartCoroutine(Green());
		}
	}

	IEnumerator Red() {
		OffAll();
		status = TrafficLightStatus.Stop;
		lights[4].SetActive(true);
		lights[5].SetActive(true);
		yield return new WaitForSeconds(redDuration);
		StartCoroutine(Yellow());
	}

	public float GetGreenDuration() {
		return this.greenDuration;
	}

	
    public float GetYellowDuration()
    {
        return this.yellowDuration;
    }

	public float GetRedDuration() {
		return this.redDuration;
	}

	public void SetGreenDuration(float seconds) {
		this.greenDuration = seconds;
	}
	
	public void SetYellowDuration(float seconds) {
		this.yellowDuration = seconds;
	}

	public void SetRedDuration(float seconds) {
		this.redDuration = seconds;
	}
}

public enum TrafficLightStatus {
	Stop, Go
}
