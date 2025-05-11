using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class clockUI : MonoBehaviour {
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] UnityEvent onHourIncrement;
    [SerializeField] public float realTimeToGameHours;
    [SerializeField] GameObject clockManager;

    public UnityEvent nightEnd;

    private float elapsedTime = 0f;
    private int hours = 0;

    void Start() {
        clockManager.SetActive(false);
    }

    public void startClock() {
        clockManager.SetActive(true);
    }

    public void resetClock() {
        clockManager.SetActive(false);
        elapsedTime = 0f;
        hours = 0;
        timerText.text = "00:00 AM";
        startClock();
    }

    void Update() {
        if (hours >= 6) {
            nightEnd?.Invoke();
            return;
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= realTimeToGameHours) {
            hours++;
            elapsedTime = 0f;

            onHourIncrement?.Invoke();
        }

        timerText.text = string.Format("{0:00}:00 AM", hours);
    }
}
