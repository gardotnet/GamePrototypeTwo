using System;
using UnityEngine;
using UnityEngine.UI;

public class postStats : MonoBehaviour {
    public event Action<int> OnPointsGained;
    public event Action<int> OnPointsLost;

    private bool isFakeNews;
    private bool liked;
    private bool retweeted;

    public int dailyEarnings;

    private int playerMorality = 100;
    private Button button;

    private void Start() {
        isFakeNews = gameObject.CompareTag("FakeNews");
        button = GetComponentInChildren<Button>();
    }

    public void Retweet() {
        if (liked || retweeted) return;

        retweeted = true;
        UpdateStats(isFakeNews ? 5 : -5);
    }

    public void Like() {
        if (retweeted || liked) return;

        liked = true;
        UpdateStats(isFakeNews ? 1 : -1);
    }

    private void UpdateStats(int points) {
        dailyEarnings = Mathf.Max(0, dailyEarnings + points);
        modifyMorality(-points);

        if (points > 0) {
            OnPointsGained?.Invoke(points);
        }
        else {
            OnPointsLost?.Invoke(points);
        }
    }

    private void modifyMorality(int amount) {
        playerMorality = Mathf.Clamp(playerMorality + amount, 0, 100);
    }
}
