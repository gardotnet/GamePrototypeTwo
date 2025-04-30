using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class postStats : MonoBehaviour {
    public UnityEvent pointsGained;
    public UnityEvent pointsLost;

    private bool isFakeNews;
    private bool Liked;
    private bool Retweeted;
    public int dailyEarnings;
    private int playerMorality = 100;

    private Button button;
    private bool isPressed;

    private void Start() {
        isFakeNews = gameObject.CompareTag("FakeNews");
        button = GetComponent<Button>();
    }

    public void Retweet() {
        if (Liked) {
            return;
        }

        if (!Retweeted) {
            Retweeted = true;

            if (isFakeNews) {
                addPoints(5);
            }
            else {
                subtractPoints(5);
            }
        }
    }

    public void Like() {
        if (Retweeted) {
            return;
        }

        if (!Liked) {
            Liked = true;

            if (isFakeNews) {
                addPoints(1);
            }
            else {
                subtractPoints(1);
            }
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
