using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class dialogueInstancing : MonoBehaviour {
    [SerializeField] private Transform content;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private dialogueTyping dialogueTyping;
    [SerializeField] private GameObject continuePrefab;
    [SerializeField] private GameObject bookendPrefab;
    [SerializeField] private CS_audioManager CS_audioManager;

    [SerializeField] private float endDelay = 3f;

    private int currentIndex = 0;
    private Transform[] dialogueQueue;

    public UnityEvent onContinueButtonPressed;
    public UnityEvent onEndTriggered;

    void Start() {
        dialogueQueue = new Transform[content.childCount];

        for (int i = 0; i < content.childCount; i++) {
            dialogueQueue[i] = content.GetChild(i);
            dialogueQueue[i].gameObject.SetActive(false);
        }

        dialogueTyping.onTypingComplete.AddListener(dialogueTyped);
        instantiateText();
    }

    void instantiateText() {
        if (currentIndex >= dialogueQueue.Length) {
            return;
        }

        Transform prefabToAdd = dialogueQueue[currentIndex];
        prefabToAdd.gameObject.SetActive(true);

        if (prefabToAdd.GetComponent<TextMeshProUGUI>() != null) {
            dialogueTyping.triggerTyping(prefabToAdd);
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
        scrollDown();
    }

    void dialogueTyped() {
        if (currentIndex >= dialogueQueue.Length) {
            return;
        }

        Transform currentPrefab = dialogueQueue[currentIndex];
        currentIndex++;

        if (currentIndex < dialogueQueue.Length && dialogueQueue[currentIndex].CompareTag("Choice")) {
            showChoiceButton();
        }
        else if (currentIndex >= dialogueQueue.Length) {
            StartCoroutine(endingDialogue());
        }
        else {
            showContinueButton();
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
        scrollDown();
    }

    void showChoiceButton() {
        Transform choicePrefab = dialogueQueue[currentIndex];
        choicePrefab.gameObject.SetActive(true);

        Button choiceButton = choicePrefab.GetComponent<Button>();
        if (choiceButton != null) {
            choiceButton.onClick.AddListener(() => {
                CS_audioManager.playPageTurn();
                currentIndex++;
                continueNext();
            });
        }
    }

    void showContinueButton() {
        GameObject continueButton = Instantiate(continuePrefab, content);
        Button buttonComponent = continueButton.GetComponent<Button>();
        if (buttonComponent != null) {
            buttonComponent.onClick.AddListener(() => {
                CS_audioManager.playPageTurn();
                continueNext();
            });
        }

        continueButton.SetActive(true);
    }

    void endDialogue() {
        GameObject endButton = Instantiate(bookendPrefab, content);
        Button buttonComponent = endButton.GetComponent<Button>();
        if (buttonComponent != null) {
            buttonComponent.onClick.AddListener(() => {
                CS_audioManager.playShortBeep();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            });
        }
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

    private IEnumerator endingDialogue() {
        yield return new WaitForSeconds(endDelay);
        endDialogue();
    }
}
