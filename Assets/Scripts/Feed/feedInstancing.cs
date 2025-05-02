using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class feedInstancing : MonoBehaviour {
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;
    [SerializeField] private Transform content;

    public List<GameObject> feedPosts;

    private List<postStats> allPostStats = new List<postStats>();

    
    public void beginDay(){
        StartCoroutine(postSpawning());
        Debug.Log("guh");
    }

    private IEnumerator postSpawning() {
        while (content.childCount < 10 && feedPosts.Count > 0) {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);
            spawnPost();
        }
    }

    private void spawnPost() {
        int index = Random.Range(0, feedPosts.Count);
        GameObject newPost = Instantiate(feedPosts[index], content);

        postStats stats = newPost.GetComponent<postStats>();
        if (stats != null) {
            allPostStats.Add(stats);
        }
        
        feedPosts.RemoveAt(index);
    }

    public int GetTotalEarnings() {
        int totalEarnings = 0;
        foreach (postStats stats in allPostStats) {
            totalEarnings += stats.dailyEarnings;
        }
        return totalEarnings;
    }
}
