using UnityEngine;

public class UITweenLoader : MonoBehaviour {
    public RectTransform footer;
    public RectTransform title;
    public RectTransform backButton;
    public RectTransform animalsList;

    public float panelScaleDuration = 0.6f;
    public float elementMoveDuration = 0.5f;
    public float elementDelay = 0.15f;
    public float elementLowOffsetY = -1800f;
    public float elementHighOffsetY = 2500f;

    void Start() {
        LoadScene();
    }

    public void LoadScene(System.Action onComplete = null) {
        footer.gameObject.SetActive(true);
        title.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        animalsList.gameObject.SetActive(true);
        AnimateElementHigh(footer, 0);
        AnimateElementHigh(title, 1);
        AnimateElementHigh(backButton, 2);
        AnimateElementHigh(animalsList, 3);

        onComplete?.Invoke();
    }
    public void CloseScene(System.Action onComplete = null) {
        LeanTween.scale(footer, Vector3.zero, panelScaleDuration).setEaseInQuad().setOnComplete(() => {
            footer.gameObject.SetActive(false);
            LeanTween.scale(footer, Vector3.one, panelScaleDuration);
        });
        LeanTween.scale(animalsList, Vector3.zero, panelScaleDuration).setEaseInQuad().setOnComplete(() => {
            animalsList.gameObject.SetActive(false);

            onComplete?.Invoke();
            LeanTween.scale(animalsList, Vector3.one, panelScaleDuration);
        });
    }

    private void AnimateElementHigh(RectTransform element, int index) {
        Vector2 originalPos = element.anchoredPosition;
        element.anchoredPosition = new Vector2(originalPos.x, originalPos.y + elementHighOffsetY);

        LeanTween.moveY(element, originalPos.y, elementMoveDuration).setEaseOutCubic().setDelay(index * elementDelay);
    }
}
