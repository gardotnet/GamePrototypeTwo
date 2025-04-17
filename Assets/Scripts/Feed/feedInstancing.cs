using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class feedInstancing : MonoBehaviour {
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;
    [SerializeField] private Transform content;

    public List<GameObject> feedPosts;

    void Start() {
        StartCoroutine(postSpawning());
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
        Instantiate(feedPosts[index], content);
        feedPosts.RemoveAt(index);
    }
}
