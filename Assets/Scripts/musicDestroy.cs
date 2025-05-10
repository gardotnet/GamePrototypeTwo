using UnityEngine;
using UnityEngine.SceneManagement;

public class musicDestroy : MonoBehaviour {
    static bool musicPlaying = false;

    void Awake() {
        if (musicPlaying) {
            Destroy(gameObject);
        }
        else {
            musicPlaying = true;
            DontDestroyOnLoad(gameObject);
        }
    }
}
