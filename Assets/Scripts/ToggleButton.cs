using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour {
    public Sprite runningSprite;
    public Sprite walkingSprite;
    public Image image;
    private bool isRunning = false;

    private void Start() {
        UpdateImage();
        GetComponent<Button>().onClick.AddListener(ToggleState);
    }
    private void ToggleState() {
        isRunning = !isRunning;
        UpdateImage();
    }
    private void UpdateImage() {
        image.sprite = isRunning ? walkingSprite : runningSprite;
    }
    public bool IsRunning() {
        return isRunning;
    }
}
