using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScroll : MonoBehaviour
{
    [SerializeField] GameObject FadeOut;

    private Animator fadeAnimator;

    void Start()
    {
        FadeOut.SetActive(false);
        fadeAnimator = FadeOut.GetComponent<Animator>();
        StartCoroutine(CreditsBack());
    }

    IEnumerator CreditsBack()
    {
        yield return new WaitForSeconds(10);

        FadeOut.SetActive(true);
        fadeAnimator.SetTrigger("Fade");

        yield return new WaitForSeconds(2); 
        SceneManager.LoadScene(1); 
    }
}
