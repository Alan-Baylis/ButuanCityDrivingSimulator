using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIViolationManager : MonoBehaviour {
	
    public RectTransform violationPanel;

    public void ShowViolationPanel() {
        violationPanel.DOAnchorPos(new Vector2(0, 0), 0.30f);
    }

    public void HideViolationPanel() {
        violationPanel.DOAnchorPos(new Vector2(-violationPanel.rect.width, 0), 0.3f);
    }
}
