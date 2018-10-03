using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIMenuManager : MonoBehaviour {

	public RectTransform canvas, mainScreen, helpScreen, aboutScreen, playScreen;
	private Vector2 onScreenPosition = new Vector2(120, 10);

	void Start()
    {
        SetDefaultPosition();
    }

    private void SetDefaultPosition()
    {
        helpScreen.anchoredPosition = new Vector2(canvas.rect.width, 10);
        aboutScreen.anchoredPosition = new Vector2(canvas.rect.width, 10);
        playScreen.anchoredPosition = new Vector2(canvas.rect.width, 10);
    }

	public void MenuScreenButton() {
		mainScreen.DOAnchorPos(onScreenPosition, 0.25f);
		helpScreen.DOAnchorPos(new Vector2(canvas.rect.width, 10), .25f);
		aboutScreen.DOAnchorPos(new Vector2(canvas.rect.width, 10), .25f);
		playScreen.DOAnchorPos(new Vector2(canvas.rect.width, 10), .25f);
	}

	public void HelpScreenButton() {
		mainScreen.DOAnchorPos(new Vector2(-mainScreen.rect.width, 10), 0.25f);
		helpScreen.DOAnchorPos3D(onScreenPosition, 0.25f);
	}

	public void PlayScreenButton() {
		mainScreen.DOAnchorPos(new Vector2(-mainScreen.rect.width, 10), 0.25f);
		playScreen.DOAnchorPos3D(onScreenPosition, 0.25f);
	}

	public void AboutScreenButton() {
		mainScreen.DOAnchorPos(new Vector2(-mainScreen.rect.width, 10), 0.25f);
		aboutScreen.DOAnchorPos3D(onScreenPosition, 0.25f);
	}

	public void CityButton() {
		SceneManager.LoadScene("City");
	}
	
	public void MountainButton() {
		SceneManager.LoadScene("Mountain");
	}

	public void OutCityButton() {
		SceneManager.LoadScene("OutCity");
	}
}
