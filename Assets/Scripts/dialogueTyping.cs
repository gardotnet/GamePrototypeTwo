using UnityEngine;
using System.Collections;
using TMPro;

public class TypingEffect : MonoBehaviour {
    public float textSpeed = 0.05f;

    private void Start() {
        StartTyping();
    }

    public void StartTyping() {
        TextMeshProUGUI[] textObjects = GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI textObject in textObjects) {
            if (textObject != null) {
                StartCoroutine(TypeText(textObject));
            }
        }
    }

    IEnumerator TypeText(TextMeshProUGUI textComponent) {
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
