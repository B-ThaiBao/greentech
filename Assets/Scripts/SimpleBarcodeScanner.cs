using UnityEngine;
using TMPro;
using Vuforia;

public class SimpleBarcodeScanner : MonoBehaviour {
    public TextMeshProUGUI barcodeAsText;
    private BarcodeBehaviour mBarcodeBehaviour;
    private Camera uiCamera;

    void Start() {
        mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
        uiCamera = Camera.main; // dùng camera chính để tính vị trí touch
    }

    void Update() {
        if (mBarcodeBehaviour != null && mBarcodeBehaviour.InstanceData != null) {
            string url = mBarcodeBehaviour.InstanceData.Text;
            barcodeAsText.text = $"<link=\"{url}\"><u><color=#0000EE>{url}</color></u></link>";
        } else {
            barcodeAsText.text = "";
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            Vector2 touchPosition = Input.GetTouch(0).position;
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(barcodeAsText, touchPosition, uiCamera);
            if (linkIndex != -1) {
                TMP_LinkInfo linkInfo = barcodeAsText.textInfo.linkInfo[linkIndex];
                string clickedUrl = linkInfo.GetLinkID();
                Application.OpenURL(clickedUrl); // Mở trình duyệt hệ thống
            }
        }
    }
}

