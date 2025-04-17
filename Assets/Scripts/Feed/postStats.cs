using UnityEngine;
using UnityEngine.Events;

public class postStats : MonoBehaviour {
    public UnityEvent pointsGained;
    public UnityEvent pointsLost;

    private bool isFakeNews;
    private int dailyEarnings = 0;
    private int playerMorality = 100;

    private void Start() {
        isFakeNews = gameObject.CompareTag("FakeNews");
    }

    public void Retweet() {
        if (isFakeNews) {
            addPoints(5);
            Debug.Log("Added 5 points for retweeting fake news. Total points: " + dailyEarnings);
        }
        else {
            subtractPoints(5);
            Debug.Log("Lost 5 points for retweeting real news. Total points: " + dailyEarnings);
        }
    }

    public void Like() {
        if (isFakeNews) {
            addPoints(1);
            Debug.Log("Added 1 point for liking fake news. Total points: " + dailyEarnings);
        }
        else {
            subtractPoints(1);
            Debug.Log("Lost 1 point for liking real news. Total points: " + dailyEarnings);
        }
    }

    private void addPoints(int points) {
        dailyEarnings += points;
        modifyMorality(-points);
        pointsGained.Invoke();
    }

    private void subtractPoints(int points) {
        dailyEarnings -= points;
        modifyMorality(points);
        pointsLost.Invoke();
    }

    private void modifyMorality(int amount) {
        playerMorality = Mathf.Clamp(playerMorality + amount, 0, 100);
    }
}
