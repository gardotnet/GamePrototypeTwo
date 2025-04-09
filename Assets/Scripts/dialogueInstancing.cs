using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class dialogueInstancing : MonoBehaviour {
    [SerializeField] private Transform content;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private dialogueTyping dialogueTyping;
    [SerializeField] private GameObject continueButtonPrefab;
    [SerializeField] private audioManager audioManager; // Reference to audioManager

    private int currentIndex = 0;
    private Transform[] dialogueQueue;

    // Declare UnityEvent directly for page turn sound (for other triggers if needed)
    public UnityEvent onContinueButtonPressed;

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

            // Check if the prefab is a text component and trigger typing
            if (prefabToAdd.GetComponent<TextMeshProUGUI>() != null) {
                dialogueTyping.triggerTyping(prefabToAdd);
            }
            // If it's a choice button, instantiate the button without triggering the event
            else if (prefabToAdd.CompareTag("Choice")) {
                Button choiceButton = prefabToAdd.GetComponent<Button>();
                choiceButton.onClick.AddListener(() => {
                    // Handle choice selection but do not trigger the event here
                    continueNext(); // Continue to the next dialogue
                });
            }

            // Force the layout update and scroll
            LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
            scrollDown();
        }
    }

    void OnTypingComplete() {
        if (currentIndex < dialogueQueue.Length) {
            // If it's a regular text (not a choice), create the continue button
            if (!dialogueQueue[currentIndex].CompareTag("Choice")) {
                GameObject continueButton = Instantiate(continueButtonPrefab, content);
                Button buttonComponent = continueButton.GetComponent<Button>();

                // Add listener to play sound when button is clicked
                buttonComponent.onClick.AddListener(() => {
                    audioManager.PlayPageTurnSound();  // Play the sound when the button is clicked
                    continueNext();                   // Proceed to the next dialogue
                });

                continueButton.SetActive(true);
            }
        }

        currentIndex++;
    }

    void continueNext() {
        // Destroy the continue button and proceed to the next dialogue
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
