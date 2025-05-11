using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class feedInstancing : MonoBehaviour {
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject feedManager;

    public List<GameObject> dayOne;
    public List<GameObject> dayTwo;
    public List<GameObject> dayThree;

    private List<postStats> allPostStats = new List<postStats>();
    private List<List<GameObject>> allDays;

    private int currentDayIndex = 0;

    private void Start() {
        allDays = new List<List<GameObject>> {
            dayOne,
            dayTwo,
            dayThree
        };
    }

    public void beginDay() {
        StartCoroutine(postSpawning());
    }

    public void endDay() {
        feedManager.SetActive(false);
        StopCoroutine(postSpawning());
    }

    private IEnumerator postSpawning() {
        while (content.childCount < 14 && allDays[currentDayIndex].Count > 0) {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);
            spawnPost();
        }
    }

    private void spawnPost() {
        int index = Random.Range(0, allDays[currentDayIndex].Count);
        GameObject newPost = Instantiate(allDays[currentDayIndex][index], content);

        postStats stats = newPost.GetComponent<postStats>();
        if (stats != null) {
            allPostStats.Add(stats);
        }

        allDays[currentDayIndex].RemoveAt(index);
    }

    public int getTotalEarnings() {
        int totalEarnings = 0;
        foreach (postStats stats in allPostStats) {
            totalEarnings += stats.dailyEarnings;
        }
        return totalEarnings;
    }

    public void nextDay() {
        currentDayIndex = (currentDayIndex + 1) % allDays.Count;
        Debug.Log($"Day indexed to: {currentDayIndex + 1}");
    }
}
