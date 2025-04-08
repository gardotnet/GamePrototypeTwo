using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueInstancing : MonoBehaviour {
    [SerializeField] private Transform content;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private dialogueTyping dialogueTyping;
    [SerializeField] private GameObject continueButtonPrefab;

    private int currentIndex = 0;
    private Transform[] dialogueQueue;

    void Start() {
        dialogueQueue = new Transform[content.childCount];

        for (int i = 0; i < content.childCount; i++) {
            dialogueQueue[i] = content.GetChild(i);
            dialogueQueue[i].gameObject.SetActive(false);
        }

        dialogueTyping.onTypingComplete.AddListener(OnTypingComplete);
        instantiateText();
    }

    void instantiateText() {
        if (currentIndex < dialogueQueue.Length) {
            Transform prefabToAdd = dialogueQueue[currentIndex];
            prefabToAdd.gameObject.SetActive(true);

            if (prefabToAdd.GetComponent<TextMeshProUGUI>() != null) {
                dialogueTyping.triggerTyping(prefabToAdd);
            }
            else if (prefabToAdd.CompareTag("Choice")) {
                Button choiceButton = prefabToAdd.GetComponent<Button>();
                choiceButton.onClick.AddListener(continueNext);
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());

            scrollDown();
        }
    }

    void OnTypingComplete() {
        if (currentIndex < dialogueQueue.Length && !dialogueQueue[currentIndex].CompareTag("Choice")) {
            GameObject continueButton = Instantiate(continueButtonPrefab, content);
            Button buttonComponent = continueButton.GetComponent<Button>();
            buttonComponent.onClick.AddListener(continueNext);
            continueButton.SetActive(true);
        }

        currentIndex++;
    }

    void continueNext() {
        GameObject continueButton = GameObject.FindWithTag("Continue");
        if (continueButton != null) {
            Destroy(continueButton);
        }
        instantiateText();
    }

    void scrollDown() {
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }
}
