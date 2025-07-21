using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CreditsTransfer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreditsTransfer()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(1);
    }
}
