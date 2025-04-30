using UnityEngine;

public class UIAnimation : MonoBehaviour {
    public RectTransform footer;
    public RectTransform scannerTitle;
    public RectTransform backButton;

    public float panelScaleDuration = 0.6f;
    public float elementMoveDuration = 0.5f;
    public float elementDelay = 0.15f;
    public float elementLowOffsetY = -1800f;
    public float elementHighOffsetY = 2500f;
    void Start() {
        LoadScannerPage();
    }

    public void LoadScannerPage(System.Action onComplete = null) {
        footer.gameObject.SetActive(true);
        scannerTitle.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        AnimateElementHigh(footer, 0);
        AnimateElementHigh(scannerTitle, 1);
        AnimateElementHigh(backButton, 2);

        onComplete?.Invoke();
    }
    public void CloseScannerPage(System.Action onComplete = null) {
        LeanTween.scale(footer, Vector3.zero, panelScaleDuration).setEaseInQuad().setOnComplete(() => {
            footer.gameObject.SetActive(false);

            onComplete?.Invoke();
            LeanTween.scale(footer, Vector3.one, panelScaleDuration);
        });
    }

    private void AnimateElementLow(RectTransform element, int index) {
        Vector2 originalPos = element.anchoredPosition;
        element.anchoredPosition = new Vector2(originalPos.x, originalPos.y + elementLowOffsetY);
        LeanTween.moveY(element, originalPos.y, elementMoveDuration).setEaseOutCubic().setDelay(index * elementDelay);
    }
    private void AnimateElementHigh(RectTransform element, int index) {
        Vector2 originalPos = element.anchoredPosition;
        element.anchoredPosition = new Vector2(originalPos.x, originalPos.y + elementHighOffsetY);

        LeanTween.moveY(element, originalPos.y, elementMoveDuration).setEaseOutCubic().setDelay(index * elementDelay);
    }
}
