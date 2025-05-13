using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void startCutscene(){
        SceneManager.LoadScene(1);
    }

    public void startGameplay(){
        SceneManager.LoadScene(2);
    }

    public void startFinalCutscene() {
        SceneManager.LoadScene(3);
    }

    public void goToMenu() {
        SceneManager.LoadScene(0);
    }
}
