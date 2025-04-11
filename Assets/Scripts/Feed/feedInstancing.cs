using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class feedInstancing : MonoBehaviour
{
    [SerializeField] private float spawnDelay;
    [SerializeField] private Transform content;

    public List<GameObject> feedPosts;
    private bool postDelay = true;

    void Update(){
        if (Input.GetKeyDown("space")){
            StartCoroutine(spawnPacing());
            spawnPost();
        }
    } 

    void spawnPost(){
        if (!postDelay){
            Instantiate(feedPosts[UnityEngine.Random.Range(0, feedPosts.Count)], content);
        }
    }
    private IEnumerator spawnPacing() {
        yield return new WaitForSeconds(spawnDelay);
        postDelay = false;
    }
}
