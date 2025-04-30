using UnityEngine;
using Controller;

public class ModelMovement : MonoBehaviour {
    public Joystick joystick;
    public float moveSpeed = 5f;
    private ModelsDisplay modelsDisplay;

    void Start() {
        modelsDisplay = FindFirstObjectByType<ModelsDisplay>();
    }

    void Update() {
        Vector2 moveInput = new Vector2(-joystick.Horizontal, -joystick.Vertical);

        bool isRunning = false;
        bool isJumping = false;

        if (modelsDisplay.currentModel != null) {
            CreatureMover mover = modelsDisplay.currentModel.GetComponent<CreatureMover>();
            // Vector3 lookTarget = mover.transform.position + new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime;
            Vector3 lookTarget = new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime;
            mover.SetInput(moveInput, lookTarget, isRunning, isJumping);
        }
    }
}

