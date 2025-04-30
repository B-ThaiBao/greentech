using UnityEngine;
using UnityEngine.EventSystems;

public class BackOptionsButton : MonoBehaviour, IPointerClickHandler {
    private UIManagement uiManagement;
    void Start() {
        uiManagement = FindFirstObjectByType<UIManagement>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        uiManagement.CloseModelsPage(() => {
            uiManagement.LoadOptions();
        });
    }
}
