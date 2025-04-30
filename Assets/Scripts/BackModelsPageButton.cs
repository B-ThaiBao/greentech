using UnityEngine;
using UnityEngine.EventSystems;

public class BackModelsPageButton : MonoBehaviour, IPointerClickHandler {
    private UIManagement uiManagement;
    void Start() {
        uiManagement = FindFirstObjectByType<UIManagement>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        uiManagement.CloseSettingsPage(() => {
            uiManagement.LoadModelsPage();
        });
    }
}
