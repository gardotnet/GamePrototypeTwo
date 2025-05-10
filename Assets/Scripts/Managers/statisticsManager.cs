using UnityEngine;
using TMPro;

public class statisticsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dayTotal;
    public feedInstancing feedManager;

    private void Start(){
        dayTotal.enabled = false;
    }
    public void printTotal() {
        dayTotal.enabled = true;
        if (feedManager != null && dayTotal != null) {
            dayTotal.text = "P" + feedManager.GetTotalEarnings();
        }
    }
}
