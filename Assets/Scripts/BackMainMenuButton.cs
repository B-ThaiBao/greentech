using UnityEngine;
using UnityEngine.EventSystems;

public class BackMainMenuButton : MonoBehaviour, IPointerClickHandler {
    public RectTransform currentPanel;
    public RectTransform nextPanel;
    public RectTransform logo;
    public RectTransform emailInput;
    public RectTransform passwordInput;
    public RectTransform signInButton;

    public float panelScaleDuration = 0.6f;
    public float elementMoveDuration = 0.5f;
    public float elementDelay = 0.15f;
    public float elementOffsetY = -1800f;

    public void OnPointerClick(PointerEventData eventData) {
        LeanTween.scale(currentPanel, Vector3.zero, panelScaleDuration).setEaseOutBack().setOnComplete(() => {
            nextPanel.localScale = Vector3.zero;
            nextPanel.gameObject.SetActive(true);
            logo.gameObject.SetActive(false);
            emailInput.gameObject.SetActive(false);
            passwordInput.gameObject.SetActive(false);
            signInButton.gameObject.SetActive(false);

            LeanTween.scale(nextPanel, Vector3.one, panelScaleDuration).setEaseOutBack().setOnComplete(() => {
                logo.gameObject.SetActive(true);
                emailInput.gameObject.SetActive(true);
                passwordInput.gameObject.SetActive(true);
                signInButton.gameObject.SetActive(true);

                AnimateElement(logo, 0);
                AnimateElement(emailInput, 1);
                AnimateElement(passwordInput, 2);
                AnimateElement(signInButton, 3);
            });
        });
    }

    void AnimateElement(RectTransform element, int index) {
        Vector2 originalPos = element.anchoredPosition;
        element.anchoredPosition = new Vector2(originalPos.x, originalPos.y + elementOffsetY);

        LeanTween.moveY(element, originalPos.y, elementMoveDuration)
            .setEaseOutCubic()
            .setDelay(index * elementDelay);
    }
}
