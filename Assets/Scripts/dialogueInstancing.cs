using UnityEngine;
using UnityEngine.UI;

public class dialogueInstancing: MonoBehaviour {
    [SerializeField] private Transform content;
    [SerializeField] private ScrollRect scrollRect;

    private int currentIndex = 0;
    private Transform[] prefabChildren;

    void Start() {
        prefabChildren = new Transform[content.childCount];

        for (int i = 0; i < content.childCount; i++) {
            prefabChildren[i] = content.GetChild(i);
            prefabChildren[i].gameObject.SetActive(false);
        }
        SetScrollPositionToBottom();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            AddNewItem();
        }
    }

    void AddNewItem() {
        Transform prefabToAdd = prefabChildren[currentIndex];
        prefabToAdd.gameObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
        SetScrollPositionToBottom();
        currentIndex = (currentIndex + 1) % prefabChildren.Length;
    }

    void SetScrollPositionToBottom() {
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }
}
