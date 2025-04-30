using UnityEngine;
using UnityEngine.UI;

public class ModelScale : MonoBehaviour {
    public Slider scaleSlider;
    public float speed = 3f;
    private ModelsDisplay modelsDisplay;
    private GameObject currentModel;

    private Vector3 initialScale;

    void Start() {
        modelsDisplay = FindFirstObjectByType<ModelsDisplay>();
        if (modelsDisplay.currentModel != null) {
            currentModel = modelsDisplay.currentModel;
            initialScale = modelsDisplay.currentModel.transform.localScale;
        }
        scaleSlider.onValueChanged.AddListener((v) => {
            if (modelsDisplay.currentModel != null) {
                modelsDisplay.currentModel.transform.localScale = initialScale * v * speed;
            }
        });
    }

    void Update() {
        if (modelsDisplay.currentModel != null) {
            if (currentModel != modelsDisplay.currentModel) {
                currentModel = modelsDisplay.currentModel;
                initialScale = modelsDisplay.currentModel.transform.localScale;
            }
        }
    }
}
