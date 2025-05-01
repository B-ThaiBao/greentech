using UnityEngine;
using Controller;

public class ModelMovement : MonoBehaviour {
    public Joystick joystick;
    public float moveSpeed = 5f;
    private ModelsDisplay modelsDisplay;
    public ToggleButton toggleButton;

    void Start() {
        modelsDisplay = FindFirstObjectByType<ModelsDisplay>();
    }

    void Update() {
        float x = joystick.Horizontal;
        float y = joystick.Vertical;
        float angle = -145f;
        float rad = angle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);
        Vector2 moveInput = new Vector2(x * cos - y * sin, x * sin + y * cos);

        bool isRunning = toggleButton.IsRunning();
        bool isJumping = false;

        if (modelsDisplay.currentModel != null) {
            CreatureMover mover = modelsDisplay.currentModel.GetComponent<CreatureMover>();
            // Vector3 lookTarget = mover.transform.position + new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime;
            Vector3 lookTarget = new Vector3(moveInput.x, 0, moveInput.y);
            mover.SetInput(moveInput, lookTarget, isRunning, isJumping);
        }
    }
}

