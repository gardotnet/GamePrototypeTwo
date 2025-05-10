using UnityEngine;

public class CS_audioManager : MonoBehaviour
{
    [SerializeField] private AudioSource pageTurn;
    [SerializeField] private AudioSource shortBeep;

    public void playPageTurn() {
        if (pageTurn != null) {
            pageTurn.Play();
        }
    }

    public void playShortBeep() {
        if (shortBeep != null) {
            shortBeep.Play();
        }
    }
}
