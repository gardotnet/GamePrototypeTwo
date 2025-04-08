using Ink.Runtime;

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    public TextAsset inkFile;
    public Button continueButton;
    [SerializeField] private Transform content;

    static Story story;
    Text TMP;
    static Choice choiceSelected;
    void Start()
    {
        story = new Story(inkFile.text);
        TMP = content.transform.GetChild(1).GetComponent<Text>();
        choiceSelected = null;
    }

    // Update is called once per frame
    void Update()
    {
        //if continueButton.onClick(){}
    }
}
