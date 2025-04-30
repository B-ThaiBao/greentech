using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsButton : MonoBehaviour, IPointerClickHandler {
    private UIManagement uiManagement;
    void Start() {
        uiManagement = FindFirstObjectByType<UIManagement>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        uiManagement.CloseModelsPage(() => {
            uiManagement.LoadSettingsPage();
        });
    }
}
