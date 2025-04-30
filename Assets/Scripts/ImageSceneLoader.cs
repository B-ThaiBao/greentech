using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ImageSceneLoader : MonoBehaviour, IPointerClickHandler {
    public int sceneToLoad;

    public void OnPointerClick(PointerEventData eventData) {
        SceneManager.LoadScene(sceneToLoad);

        /*
        if (sceneToLoad == 0) {
            SignInButton signInButton = GameObject.Find("SignInButton").GetComponent<SignInButton>();
            signInButton.currentPanel.SetActive(false);
            signInButton.nextPanel.SetActive(true);
        }
        */
    }
}
