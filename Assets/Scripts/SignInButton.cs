using UnityEngine;
using UnityEngine.EventSystems;

public class SignInButton : MonoBehaviour, IPointerClickHandler {
    private UIManagement uiManagement;

    void Start() {
        uiManagement = FindFirstObjectByType<UIManagement>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        uiManagement.CloseMainMenu(() => {
            uiManagement.LoadOptions();
        });
    }
}
