using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class dialogueInstancing : MonoBehaviour {
    [SerializeField] private Transform content;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private dialogueTyping dialogueTyping;
    [SerializeField] private GameObject continueButtonPrefab;
    [SerializeField] private audioManager audioManager;

    private int currentIndex = 0;
    private Transform[] dialogueQueue;

    public UnityEvent onContinueButtonPressed;

    void Start() {
        dialogueQueue = new Transform[content.childCount];

        for (int i = 0; i < content.childCount; i++) {
            dialogueQueue[i] = content.GetChild(i);
            dialogueQueue[i].gameObject.SetActive(false);
        }

        dialogueTyping.onTypingComplete.AddListener(OnTypingComplete);
        instantiateText();  // Start the dialogue
    }

    void instantiateText() {
        if (currentIndex < dialogueQueue.Length) {
            Transform prefabToAdd = dialogueQueue[currentIndex];
            prefabToAdd.gameObject.SetActive(true);
            Debug.Log($"Instantiating Text or Choice at index {currentIndex}");

            // If it's a regular TextMeshProUGUI (Dialogue Text)
            if (prefabToAdd.GetComponent<TextMeshProUGUI>() != null) {
                Debug.Log("Text component found. Triggering typing.");
                dialogueTyping.triggerTyping(prefabToAdd);
            }
            // If it's a choice button
            else if (prefabToAdd.CompareTag("Choice")) {
                Debug.Log("Choice button found. Adding listener.");
                Button choiceButton = prefabToAdd.GetComponent<Button>();
                choiceButton.onClick.AddListener(() => {
                    Debug.Log("Choice button clicked. Proceeding to next dialogue.");
                    continueNext(); // Proceed to next dialogue after choice is selected
                });
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
            scrollDown();
        }
        else {
            Debug.LogError("No more dialogues to instantiate.");
        }
    }

    void OnTypingComplete() {
        Debug.Log($"Typing completed for dialogue index {currentIndex}");

        // Only instantiate continue button if it's not a choice
        if (currentIndex < dialogueQueue.Length && !dialogueQueue[currentIndex].CompareTag("Choice")) {
            Debug.Log("Instantiating continue button.");

            GameObject continueButton = Instantiate(continueButtonPrefab, content);
            Button buttonComponent = continueButton.GetComponent<Button>();
            if (buttonComponent != null) {
                buttonComponent.onClick.AddListener(() => {
                    Debug.Log("Continue button clicked. Playing page turn sound.");
                    audioManager.PlayPageTurnSound();
                    continueNext();
                });
            }
            else {
                Debug.LogError("Button component is missing on continue button prefab.");
            }

            continueButton.SetActive(true);
        }

        // Remove index increment here, we’ll increment it in continueNext
    }

    void continueNext() {
        Debug.Log("Proceeding to next dialogue.");

        // Destroy continue button if it exists
        GameObject continueButton = GameObject.FindWithTag("Continue");
        if (continueButton != null) {
            Destroy(continueButton);
        }

        // Increment the index here to proceed to the next dialogue (text or choice)
        currentIndex++; // Ensure index is incremented when moving to next dialogue.

        // Ensure next dialogue is instantiated (whether text or choice)
        instantiateText();
    }

    void scrollDown() {
        Debug.Log("Scrolling to bottom of the dialogue content.");
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }
}
