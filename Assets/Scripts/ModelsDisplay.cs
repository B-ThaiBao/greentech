using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ModelsDisplay : MonoBehaviour {
    public List<GameObject> models;
    public Transform modelParent;
    public GameObject currentModel;

    private void LoadModelIndex(int idx) {
        if (currentModel != null) Destroy(currentModel);
        currentModel = Instantiate(models[idx], modelParent);
    }

    public void OnDisplayChickenModel() {
        LoadModelIndex(0);
    }
    public void OnDisplayDeerModel() {
        LoadModelIndex(1);
    }
    public void OnDisplayDogModel() {
        LoadModelIndex(2);
    }
    public void OnDisplayHorseModel() {
        LoadModelIndex(3);
    }
    public void OnDisplayCatModel() {
        LoadModelIndex(4);
    }
    public void OnDisplayPinguinModel() {
        LoadModelIndex(5);
    }
    public void OnDisplayTigerModel() {
        LoadModelIndex(6);
    }
}
