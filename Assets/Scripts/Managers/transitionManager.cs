using UnityEngine;
using UnityEngine.UI;

public class transitionManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    private bool _fadein = false;
    private bool _fadeout = false;

    public float fadeTime;

    void Start()
    {
        canvasGroup.gameObject.SetActive(false);
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
        canvasGroup.gameObject.SetActive(true);
        _fadein = true;
    }

    public void fadeOut(){
        canvasGroup.gameObject.SetActive(false);
        _fadeout = true;
    }

}

