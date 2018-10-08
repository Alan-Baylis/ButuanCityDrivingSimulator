using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetCarPosition : MonoBehaviour {

    private Camera topDownCamera;
    private GameObject mainCamera;
    private GameObject mainCanvas;
    private GameObject resetPositionCanvas;

	// Use this for initialization
	void Awake () {
        resetPositionCanvas = GameObject.Find("ResetPositionCanvas");
        mainCanvas = GameObject.Find("MainCanvas");
		mainCamera = GameObject.Find("Main Camera");
		topDownCamera = FindObjectOfType<TopDownCameraController>().GetComponent<Camera>();
	}

    void Start () {
        resetPositionCanvas.SetActive(false);
        topDownCamera.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		SetPosition();
	}

    private void SetPosition() {
        if(Input.GetMouseButton(0) && topDownCamera.gameObject.activeSelf) {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            Vector3 clickPosition = -Vector3.one;
            Ray ray = topDownCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                clickPosition = hit.point;
            }
            Vector3 cameraPosition = clickPosition;
            cameraPosition.z = clickPosition.z - 4;
            cameraPosition.y = clickPosition.y + 4;
            mainCamera.transform.position = cameraPosition;
            FindObjectOfType<CustomCarUserControl>().gameObject.transform.position = clickPosition;
            CloseCanvas();
        }
    }

    public void ResetPosition() {
        topDownCamera.gameObject.SetActive(true);
        resetPositionCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void CloseCanvas() {
        topDownCamera.gameObject.SetActive(false);
        resetPositionCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
