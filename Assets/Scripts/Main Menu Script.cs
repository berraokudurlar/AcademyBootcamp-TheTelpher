using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource buttonClick;
    [SerializeField] private AudioSource mainMenuMusic;
    [SerializeField] private AudioSource mainMenuSFX;

    [Header("Faders")]
    [SerializeField] private GameObject fadeIn;
    [SerializeField] private GameObject fadeOut;
    [SerializeField] private GameObject blackScreen;

    [Header("Backgrounds")]
    [SerializeField] private RawImage backgroundImage;
    [SerializeField] private Texture morningTexture;
    [SerializeField] private Texture dayTexture;
    [SerializeField] private Texture eveningTexture;
    [SerializeField] private Texture nightTexture;

    private Animator fadeInAnimator;
    private Animator fadeOutAnimator;

    void Start()
    {
        blackScreen.SetActive(true);
        fadeIn.SetActive(false);
        fadeOut.SetActive(false);

        fadeInAnimator = fadeIn.GetComponent<Animator>();
        fadeOutAnimator = fadeOut.GetComponent<Animator>();

        SetBackgroundBasedOnTime();

        StartCoroutine(MainMenu());
    }

    void SetBackgroundBasedOnTime()
    {
        int hour = DateTime.Now.Hour;
        Debug.Log("Current hour: " + hour);

        if (hour >= 6 && hour < 12)
        {
            backgroundImage.texture = morningTexture;
        }
        else if (hour >= 12 && hour < 17)
        {
            backgroundImage.texture = dayTexture;
        }
        else if (hour >= 17 && hour < 20)
        {
            backgroundImage.texture = eveningTexture;
        }
        else
        {
            backgroundImage.texture = nightTexture;
        }
    }

    public void NewGame()
    {
        Debug.Log("NEW GAME BUTTON CLICKED");
        PlayClick();
        StartCoroutine(PrologueStart());
    }

    public void LoadGame()
    {
        Debug.Log("LOAD GAME BUTTON CLICKED");
        PlayClick();
        // Add load game logic here
    }

    public void Config()
    {
        Debug.Log("CONFIG BUTTON CLICKED");
        PlayClick();
        // Add config logic here
    }

    public void Journal()
    {
        Debug.Log("JOURNAL BUTTON CLICKED");
        PlayClick();
        // Add journal logic here
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME BUTTON CLICKED");
        PlayClick();
        Application.Quit();
    }

    private void PlayClick()
    {
        if (buttonClick != null)
            buttonClick.Play();
    }

    IEnumerator MainMenu()
    {
        mainMenuSFX.Play();
        yield return new WaitForSeconds(3f);

        blackScreen.SetActive(false);
        fadeIn.SetActive(true);

        if (fadeInAnimator != null)
            fadeInAnimator.SetTrigger("Fade");

        yield return new WaitForSeconds(2f);
        mainMenuMusic.Play();
    }

    IEnumerator PrologueStart()
    {
        fadeOut.SetActive(true);

        if (fadeOutAnimator != null)
            fadeOutAnimator.SetTrigger("Fade");

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
