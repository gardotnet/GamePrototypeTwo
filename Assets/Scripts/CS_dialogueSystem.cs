using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class CS_dialogueSystem : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueLines;
    public TextMeshProUGUI textComponent;
    public float textSpeed;

    public string[] lines;

    private int index = 0;
    
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (textComponent.text == lines[index]){
                NextLine();
            } else {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue(){
        index = 0;
        StartCoroutine (TypeLine());
    }

    IEnumerator TypeLine(){
        foreach (char letter in lines[index].ToCharArray()){
            textComponent.text += letter;
            yield return new WaitForSeconds (textSpeed);
        }
    }

    void NextLine(){
        if (index < lines.Length - 1){
            index ++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            gameObject.SetActive (false);
        }
    }
}