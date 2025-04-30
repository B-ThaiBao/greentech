using UnityEngine;
using UnityEngine.EventSystems;

public class ModelsButton : MonoBehaviour, IPointerClickHandler {
    private UIManagement uiManagement;
    void Start() {
        uiManagement = FindFirstObjectByType<UIManagement>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        uiManagement.CloseOptions(() => {
            uiManagement.LoadModelsPage();
        });
    }
}
