using UnityEngine;

public class UIManagement : MonoBehaviour {
    private static int currentPageIndex = 0;
    // Main menu
    public RectTransform mainMenuPanel;
    public RectTransform greentechLogo;
    public RectTransform emailInput;
    public RectTransform passwordInput;
    public RectTransform signInButton;

    // Options
    public RectTransform optionsPanel;
    public RectTransform scannerButton;
    public RectTransform modelsButton;
    public RectTransform backButton;

    // Models Page
    public RectTransform footerModels;
    public RectTransform modelsTitle;
    public RectTransform backOptionsButton;
    public RectTransform animalsList;
    public RectTransform settingsButton;

    // Settings Page
    public RectTransform footerSettings;
    public RectTransform settingsTitle;
    public RectTransform backMainMenuButton;
    public RectTransform joystick;
    public RectTransform scaleSlider;

    public float panelScaleDuration = 0.6f;
    public float elementMoveDuration = 0.5f;
    public float elementDelay = 0.15f;
    public float elementLowOffsetY = -1800f;
    public float elementHighOffsetY = 2500f;
    void Start() {
        if (currentPageIndex == 0) LoadMainMenu();
        else if (currentPageIndex == 1) LoadOptions();
        else if (currentPageIndex == 2) LoadModelsPage();
        else if (currentPageIndex == 3) LoadSettingsPage();
    }
    public void LoadMainMenu(System.Action onComplete = null) {
        currentPageIndex = 0;
        greentechLogo.gameObject.SetActive(false);
        emailInput.gameObject.SetActive(false);
        passwordInput.gameObject.SetActive(false);
        signInButton.gameObject.SetActive(false);

        mainMenuPanel.localScale = Vector3.zero;
        mainMenuPanel.gameObject.SetActive(true);
        LeanTween.scale(mainMenuPanel, Vector3.one, panelScaleDuration).setEaseOutBack().setOnComplete(() => {
            greentechLogo.gameObject.SetActive(true);
            emailInput.gameObject.SetActive(true);
            passwordInput.gameObject.SetActive(true);
            signInButton.gameObject.SetActive(true);

            AnimateElementLow(greentechLogo, 0);
            AnimateElementLow(emailInput, 1);
            AnimateElementLow(passwordInput, 2);
            AnimateElementLow(signInButton, 3);

            onComplete?.Invoke();
        });
    }
    public void CloseMainMenu(System.Action onComplete = null) {
        LeanTween.scale(mainMenuPanel, Vector3.zero, panelScaleDuration).setEaseInQuad().setOnComplete(() => {
            mainMenuPanel.gameObject.SetActive(false);

            onComplete?.Invoke();
        });
    }

    public void LoadOptions(System.Action onComplete = null) {
        currentPageIndex = 1;
        scannerButton.gameObject.SetActive(false);
        modelsButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        optionsPanel.localScale = Vector3.zero;
        optionsPanel.gameObject.SetActive(true);
        LeanTween.scale(optionsPanel, Vector3.one, panelScaleDuration).setEaseOutBack().setOnComplete(() => {
            scannerButton.gameObject.SetActive(true);
            modelsButton.gameObject.SetActive(true);
            backButton.gameObject.SetActive(true);

            AnimateElementLow(scannerButton, 0);
            AnimateElementLow(modelsButton, 1);
            AnimateElementLow(backButton, 2);

            onComplete?.Invoke();
        });
    }
    public void CloseOptions(System.Action onComplete = null) {
        LeanTween.scale(optionsPanel, Vector3.zero, panelScaleDuration).setEaseInQuad().setOnComplete(() => {
            optionsPanel.gameObject.SetActive(false);

            onComplete?.Invoke();
        });
    }

    public void LoadModelsPage(System.Action onComplete = null) {
        currentPageIndex = 2;
        footerModels.gameObject.SetActive(true);
        modelsTitle.gameObject.SetActive(true);
        backOptionsButton.gameObject.SetActive(true);
        animalsList.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        AnimateElementHigh(footerModels, 0);
        AnimateElementHigh(modelsTitle, 1);
        AnimateElementHigh(backOptionsButton, 2);
        AnimateElementHigh(animalsList, 3);
        AnimateElementHigh(settingsButton, 4);

        onComplete?.Invoke();
    }
    public void CloseModelsPage(System.Action onComplete = null) {
        LeanTween.scale(footerModels, Vector3.zero, panelScaleDuration).setEaseInQuad().setOnComplete(() => {
            footerModels.gameObject.SetActive(false);
            LeanTween.scale(footerModels, Vector3.one, panelScaleDuration);
        });
        LeanTween.scale(animalsList, Vector3.zero, panelScaleDuration).setEaseInQuad().setOnComplete(() => {
            animalsList.gameObject.SetActive(false);
            LeanTween.scale(animalsList, Vector3.one, panelScaleDuration);
        });
        LeanTween.scale(settingsButton, Vector3.zero, panelScaleDuration).setEaseInQuad().setOnComplete(() => {
            settingsButton.gameObject.SetActive(false);

            onComplete?.Invoke();
            LeanTween.scale(settingsButton, Vector3.one, panelScaleDuration);
        });
    }

    public void LoadSettingsPage(System.Action onComplete = null) {
        currentPageIndex = 3;
        footerSettings.gameObject.SetActive(true);
        settingsTitle.gameObject.SetActive(true);
        backMainMenuButton.gameObject.SetActive(true);
        joystick.gameObject.SetActive(true);
        scaleSlider.gameObject.SetActive(true);
        AnimateElementHigh(footerSettings, 0);
        AnimateElementHigh(settingsTitle, 1);
        AnimateElementHigh(backMainMenuButton, 2);
        AnimateElementHigh(joystick, 3);
        AnimateElementHigh(scaleSlider, 4);

        onComplete?.Invoke();
    }
    public void CloseSettingsPage(System.Action onComplete = null) {
        LeanTween.scale(footerSettings, Vector3.zero, panelScaleDuration).setEaseInQuad().setOnComplete(() => {
            footerSettings.gameObject.SetActive(false);
            LeanTween.scale(footerSettings, Vector3.one, panelScaleDuration);
        });
        LeanTween.scale(joystick, Vector3.zero, panelScaleDuration).setEaseInQuad().setOnComplete(() => {
            joystick.gameObject.SetActive(false);
            LeanTween.scale(joystick, Vector3.one, panelScaleDuration);
        });
        LeanTween.scale(scaleSlider, Vector3.zero, panelScaleDuration).setEaseInQuad().setOnComplete(() => {
            scaleSlider.gameObject.SetActive(false);

            onComplete?.Invoke();
            LeanTween.scale(scaleSlider, Vector3.one, panelScaleDuration);
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
