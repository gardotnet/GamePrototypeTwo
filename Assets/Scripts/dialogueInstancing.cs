using UnityEngine;
using UnityEngine.UI;

public class dialogueInstancing : MonoBehaviour {
    [SerializeField] private Transform content;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private dialogueTyping dialogueTyping;

    private int currentIndex = 0;
    private Transform[] dialogueQueue;

    void Start() {
        dialogueQueue = new Transform[content.childCount];

        for (int i = 0; i < content.childCount; i++) {
            dialogueQueue[i] = content.GetChild(i);
            dialogueQueue[i].gameObject.SetActive(false);
        }
        scrollDown();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            instantiateText();
        }
    }

    void instantiateText() {
        Transform prefabToAdd = dialogueQueue[currentIndex];
        prefabToAdd.gameObject.SetActive(true);
        dialogueTyping.triggerTyping(prefabToAdd);

        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());

        scrollDown();
        currentIndex = (currentIndex + 1) % dialogueQueue.Length;
    }

    void scrollDown() {
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }
}
