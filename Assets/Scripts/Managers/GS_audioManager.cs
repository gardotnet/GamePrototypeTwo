using UnityEngine;
using UnityEngine.Events;

public class GS_audioManager : MonoBehaviour {
    [SerializeField] private AudioSource pageTurn;
    [SerializeField] private AudioSource clockTick;
    [SerializeField] private AudioSource coinShimmer;

    public void playClockTick() {
        if (clockTick != null) {
            clockTick.Play();
        }
    }

    public void playCoinShimmer() {
        if (coinShimmer != null) {
            coinShimmer.Play();
        }
    }

    public void playPageTurn() {
        if (pageTurn != null) {
            pageTurn.Play();
        }
    }
}