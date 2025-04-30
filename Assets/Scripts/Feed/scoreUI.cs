using UnityEngine;

public class scoreUI : MonoBehaviour
{
    public postStats playerStats;
    public TMPro.TextMeshProUGUI scoreLabel;
    void Update()
    {
        if (playerStats != null){
            scoreLabel.text =  "P-" + playerStats.dailyEarnings;
        }
    }
}
