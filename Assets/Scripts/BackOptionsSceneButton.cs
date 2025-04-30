using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackOptionsSceneButton : MonoBehaviour, IPointerClickHandler {
    private UIAnimation uiAnimation;
    void Start() {
        uiAnimation = FindFirstObjectByType<UIAnimation>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        uiAnimation.CloseScannerPage(() => {
            SceneManager.LoadScene(0);
        });
    }
}
