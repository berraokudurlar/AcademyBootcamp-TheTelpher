using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    [SerializeField] GameObject fadeOut;
    [SerializeField] AudioSource filmRoll;

    private Animator fadeOutAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        filmRoll.Play();
        fadeOut.SetActive(false);
        StartCoroutine(CreditsTransfer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreditsTransfer()
    {
        
        yield return new WaitForSeconds(6f);

        filmRoll.Stop();

        yield return new WaitForSeconds(1f);

        fadeOut.SetActive(true);

        if (fadeOutAnimator != null)
            fadeOutAnimator.SetTrigger("Fade");

        SceneManager.LoadScene("Main Menu");
    }
}
