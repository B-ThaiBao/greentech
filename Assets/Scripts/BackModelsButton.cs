using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackModelsButton : MonoBehaviour, IPointerClickHandler {
    private UITweenLoader uiTweenLoader;
    void Start() {
        uiTweenLoader = FindFirstObjectByType<UITweenLoader>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        uiTweenLoader.CloseScene(() => {
            SceneManager.LoadScene(0);
        });
    }
}
