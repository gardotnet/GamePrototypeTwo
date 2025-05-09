using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class transitionManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private clockUI clockUI;

    private bool _fadein = false;
    private bool _fadeout = false;

    public float fadeTime;

    void Start()
    {
        canvasGroup.gameObject.SetActive(false);
        clockUI.nightEnd.AddListener(fadeOut);
    }
    
    void Update()
    {
        if (_fadein){
            if(canvasGroup.alpha < 1){
                canvasGroup.alpha += fadeTime * Time.deltaTime;
                if (canvasGroup.alpha >= 1){
                    _fadein = false;
                }
            }
        }

        if (_fadeout){
            if(canvasGroup.alpha >= 0){
                canvasGroup.alpha -= fadeTime * Time.deltaTime;
                if (canvasGroup.alpha == 0){
                    _fadeout = false;
                }
            }
        }
    }

    public void fadeIn(){
        Debug.Log("Fading in");
        canvasGroup.gameObject.SetActive(true);
        _fadein = true;
    }

    public void fadeOut(){
        Debug.Log ("Fading out");
        _fadeout = true;
    }

}

