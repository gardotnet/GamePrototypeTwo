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
        if (gameObject.CompareTag("FakeNews")){
            addPesos(50);
            OnPointsGained?.Invoke(50);
        } else if (gameObject.CompareTag("RealNews")){
            losePesos(50);
            OnPointsLost?.Invoke(50);
        }
    }

    public void Like() {
        if (retweeted || liked) return;
        liked = true;

        if (gameObject.CompareTag("FakeNews")){
            addPesos(10);
            OnPointsGained?.Invoke(10);
        } else if (gameObject.CompareTag("RealNews")){
            losePesos(10);
            OnPointsLost?.Invoke(10);
        }
    }

    private void addPesos(int pesos){
        dailyEarnings += pesos;
    }

    private void losePesos(int pesos){
        dailyEarnings -= pesos;
    }

    private void modifyMorality(int amount) {
        playerMorality = Mathf.Clamp(playerMorality + amount, 0, 100);
    }
}
