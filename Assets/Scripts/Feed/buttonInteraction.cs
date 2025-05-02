using UnityEngine;
using UnityEngine.UI;

public class buttonInteraction : MonoBehaviour
{
   //bool buttonPressed = false;
    public void OnPress(Button button) {
        //if (buttonPressed) return;

        ColorBlock block = button.colors;

        bool isToggled = block.normalColor == block.selectedColor;
        block.normalColor = isToggled ? block.disabledColor : block.selectedColor;

        button.colors = block;
        //buttonPressed = true;

    }
}
