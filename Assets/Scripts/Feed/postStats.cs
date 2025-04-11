using UnityEngine;
using UnityEngine.Events;

public class postStats : MonoBehaviour
{
    public UnityEvent pointsGained;
    public UnityEvent pointsLost;

    void Start(){

    }
    void gainPoints(){
        pointsGained.Invoke();
    }
    void subtractPoints(){
        pointsLost.Invoke();
    }
}
