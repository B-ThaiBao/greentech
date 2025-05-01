using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ARTechButton : MonoBehaviour, IPointerClickHandler {
    private UIManagement uiManagement;
    void Start() {
        uiManagement = FindFirstObjectByType<UIManagement>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        uiManagement.CloseModelsPage(() => {
            SceneManager.LoadScene(2);
        });
    }
}
