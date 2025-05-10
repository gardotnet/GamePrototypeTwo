using UnityEngine;

public class volumeManager : MonoBehaviour
{
    [SerializeField] private AudioSource cutsceneMusic;
    [SerializeField] private AudioSource gameplayMusic;
    private float crossfadeDuration = 1.0f;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
