using UnityEngine;

public class menuManager : MonoBehaviour
{
    [SerializeField] private GameObject letterPanel;
    [SerializeField] private GameObject dayEndMenu;

    public void Awake() {
        dayEndMenu.SetActive(false);
    }

    public void toggleLetterPanel(){
        letterPanel.SetActive(false);
    }

    public void toggleDayEndMenu() {
        dayEndMenu.SetActive(true);
    }
}
