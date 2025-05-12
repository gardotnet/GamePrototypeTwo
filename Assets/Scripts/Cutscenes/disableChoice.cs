using UnityEngine;
using UnityEngine.UI;

public class disableChoice : MonoBehaviour
{
    [SerializeField] Button choice;
    public void disableButton(){
        choice.interactable = false;
    }
}
