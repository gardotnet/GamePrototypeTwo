using UnityEngine;

public class audioManager : MonoBehaviour {
    [SerializeField] private AudioSource page_turn;
    [SerializeField] private AudioSource short_beep;

    public void playPageTurn() {
        if (page_turn != null) {
            page_turn.Play();
        }
    }

    public void playShortBeep() {
        if (short_beep != null) {
            short_beep.Play();
        }
    }
}