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

    private void scoreLabelSwap(){
        if (dayTotalLabel.enabled == true) {
            scoreLabel.enabled = false;
        }
    }
    private void Update() {
        if (feedManager != null && scoreLabel != null) {
            scoreLabel.text = "P" + feedManager.GetTotalEarnings();
        }

        if (dayTotalLabel.enabled == true) {
            scoreLabel.enabled = false;
        }
    }
}
