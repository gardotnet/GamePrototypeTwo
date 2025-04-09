using UnityEngine;

public class audioManager : MonoBehaviour {
    private AudioSource page_turn;

    void Start() {
        page_turn = GetComponent<AudioSource>();
        if (page_turn == null) {
            Debug.LogError("No AudioSource attached to audioManager!");
        }
    }

    // Method to play page turn sound
    public void PlayPageTurnSound() {
        if (page_turn != null) {
            page_turn.Play();
            Debug.Log("Page turn sound played");
        }
        else {
            Debug.LogError("AudioSource not found! Please attach an AudioSource.");
        }
    }
}
