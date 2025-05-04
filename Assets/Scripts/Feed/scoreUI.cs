using UnityEngine;
using TMPro;

public class scoreUI : MonoBehaviour {
    public feedInstancing feedManager;
    public TextMeshProUGUI scoreLabel;

    private void Update() {
        if (feedManager != null && scoreLabel != null) {
            scoreLabel.text = "P" + feedManager.GetTotalEarnings();
        }
    }
}
