using UnityEngine;

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