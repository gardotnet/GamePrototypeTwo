using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class scoreUI : MonoBehaviour {
    public feedInstancing feedManager;
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI dayTotalLabel;
    [SerializeField] GameObject interactionManager;

    void Start() {
        interactionManager.SetActive(false);
    }

    public void startScore() {
        interactionManager.SetActive(true);
    }

    public void enableScoreLabel() {
        scoreLabel.enabled = true;
    }

    public void disableTotalLabel() {
        dayTotalLabel.enabled = false;
    }

    private void Update() {
        if (feedManager != null && scoreLabel != null) {
            scoreLabel.text = "P" + feedManager.getTotalEarnings();
        }

        if (dayTotalLabel.enabled == true) {
            scoreLabel.enabled = false;
        }
    }
}
