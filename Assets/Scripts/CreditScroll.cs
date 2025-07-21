using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScroll : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CreditsBack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreditsBack()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(1);
    }
}
