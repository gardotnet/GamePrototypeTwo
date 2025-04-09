using UnityEngine;

public class audioManager : MonoBehaviour {
    private AudioSource page_turn;

    void Start() {
        page_turn = GetComponent<AudioSource>();
    }

    public void PlayPageTurnSound() {
        if (page_turn != null) {
            page_turn.Play();
        }
    }
}
