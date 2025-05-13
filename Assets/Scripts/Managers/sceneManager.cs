using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void startCutscene(){
        SceneManager.LoadScene(1);
    }

    public void startGameplay(){
        SceneManager.LoadScene(2);
    }

    public void goToMenu() {
        SceneManager.LoadScene(0);
    }
}
