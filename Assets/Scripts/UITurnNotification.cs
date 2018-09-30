using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UITurnNotification : MonoBehaviour {

	public RectTransform container;
	public TextMeshProUGUI text;
	public Image image;
	public Sprite[] sourceImages;

	void Start() {
		container.anchoredPosition = new Vector2(0, 125);
	}

	public void Show() {
		container.DOAnchorPos(new Vector2(0, 0), .35f);
		StartCoroutine(HideNotification());
	}

	public void Hide() {
		container.DOAnchorPos(new Vector2(0, 125), .35f);	
	}

	IEnumerator HideNotification() {
		yield return new WaitForSeconds(4f);
		Hide();
	}
}

