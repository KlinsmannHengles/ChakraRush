using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public float timeSpeed;
    public GameObject player;

    [Header("TryAgain")]
    public GameObject tryAgainScreen;
    public GameObject transitionImage;
    public CanvasGroup buttonCG;
    private PostProcessVolume _gamePostProcessVolume;
    private ChromaticAberration _chromaticAberration;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.onDieEvent += EnableTryAgainScreen;

        transitionImage.GetComponent<CanvasGroup>().alpha = 1.0f;
        transitionImage.GetComponent<CanvasGroup>().DOFade(0f, 2f);

        //_gamePostProcessVolume.profile.TryGetSettings(out _chromaticAberration);
        
    }

    private void OnDisable()
    {
        PlayerHealth.onDieEvent -= EnableTryAgainScreen;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeSpeed;
    }

    /*public void ActiveChromaticAberration()
    {
        _chromaticAberration.active = true;
    }*/

    private void EnableTryAgainScreen()
    {
        //ActiveChromaticAberration();
        timeSpeed = 0.5f;
        tryAgainScreen.SetActive(true);
        tryAgainScreen.GetComponent<CanvasGroup>().DOFade(1f, 1f);
        ButtonFadeIn();
    }

    public void Restart()
    {
        timeSpeed = 1f;
        transitionImage.GetComponent<CanvasGroup>().DOFade(1f, 2f).onComplete = TrueRestart;
    }

    public void TrueRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ButtonFadeIn()
    {
        buttonCG.DOFade(1f, 0.2f).onComplete = ButtonFadeOut;
    }

    public void ButtonFadeOut()
    {
        buttonCG.DOFade(0f, 0.2f).onComplete = ButtonFadeIn;
    }
}
