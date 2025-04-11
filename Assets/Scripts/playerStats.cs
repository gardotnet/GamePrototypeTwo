using UnityEngine;
using UnityEngine.Events;

public class playerStats : MonoBehaviour
{
    private postStats postStats;

    public int dailyEarnings;
    public int totalEarnings;

    public UnityEvent pointsGained;
    public UnityEvent pointsLost;
    void Start()
    {
        postStats.pointsGained.AddListener(addToEarnings);
        postStats.pointsLost.AddListener(removeFromEarnings);
    }

    void addToEarnings(){
        dailyEarnings = dailyEarnings + 21;
    }

    void removeFromEarnings(){
        dailyEarnings = dailyEarnings - 21;
    }
}
