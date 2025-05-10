using UnityEngine;

public class menuManager : MonoBehaviour
{
    [SerializeField] private GameObject letterPanel;

    public void toggleLetterPanel(){
        letterPanel.SetActive(false);
    }
}
