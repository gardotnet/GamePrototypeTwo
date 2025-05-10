using UnityEngine;
using UnityEngine.UI;

public class buttonInteraction : MonoBehaviour
{
    public void OnPress(Button button) {

        ColorBlock block = button.colors;

        bool isToggled = block.normalColor == block.selectedColor;
        block.normalColor = isToggled ? block.disabledColor : block.selectedColor;

        button.colors = block;

    }
}
