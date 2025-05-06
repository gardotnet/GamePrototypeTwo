using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class clockUI : MonoBehaviour {
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] UnityEvent onHourIncrement;

    private float elapsedTime = 0f;
    private int hours = 0;

    void Update() {
        if (hours >= 6) {
            return;
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 20f) {
            hours++;
            elapsedTime = 0f;

            onHourIncrement?.Invoke();
        }

        timerText.text = string.Format("{0:00}:00 AM", hours);
    }
}
