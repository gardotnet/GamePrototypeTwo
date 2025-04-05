using UnityEngine;
using System.Collections;
using TMPro;

public class dialogueTyping : MonoBehaviour {

    public float textSpeed;

    public void triggerTyping(Transform textObject) {
        TextMeshProUGUI textComponent = textObject.GetComponent<TextMeshProUGUI>();
        if (textComponent != null) {
            StartCoroutine(startType(textComponent));
        }
    }

    IEnumerator startType(TextMeshProUGUI textComponent) {
        string fullText = textComponent.text;
        textComponent.text = "";
        bool insideTag = false;
        string currentText = "";

        for (int i = 0; i < fullText.Length; i++) {
            if (fullText[i] == '<') {
                insideTag = true;
                currentText += "<";
            }
            else if (fullText[i] == '>') {
                insideTag = false;
                currentText += ">";
            }
            else if (!insideTag) {
                currentText += fullText[i];
                textComponent.text = currentText;
                yield return new WaitForSeconds(textSpeed);
            }
            else {
                currentText += fullText[i];
            }
        }
    }
}
