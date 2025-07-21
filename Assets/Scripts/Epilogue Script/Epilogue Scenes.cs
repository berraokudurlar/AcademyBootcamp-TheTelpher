using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EpilogueScenes : MonoBehaviour
{
    public GameObject fadeIn;
    public GameObject textBox;
    public GameObject fadeOut;
    public GameObject charBella;

    public float preFadeDelay = 2f;     // Wait before fade starts
    public float postFadeDelay = 1f;    // Wait after fade ends before music starts
    public float charAppearDelay = 3f;
    public float fadeAppearDelay = 4f;
    public float textBoxAppearDelay = 2f;// Wait before character appears
    public static bool isTextDonePrinting = false;


    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject charName;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] int eventPos = 0;
    void Start()
    {
        fadeIn.SetActive(true);
        charBella.SetActive(false);
        mainTextObject.SetActive(false);
        textBox.SetActive(false);
        nextButton.SetActive(false);
        fadeOut.SetActive(false);
        StartCoroutine(EventStarter());
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    IEnumerator EventStarter()
    {
        yield return new WaitForSeconds(preFadeDelay);

        Animator fadeAnimator = fadeIn.GetComponent<Animator>();
        if (fadeAnimator != null)
        {
            fadeAnimator.SetTrigger("fadeOut");
            yield return new WaitForSeconds(1.5f);
        }
        else
        {
            yield return new WaitForSeconds(1f);
            fadeIn.SetActive(false);
        }

        // Set up textBox and mainTextObject before showing
        charName.GetComponent<TMPro.TMP_Text>().text = "BELLA";
        textToSpeak = "Hey. What do you like about me?";

        textBox.GetComponent<TMPro.TMP_Text>().text = ""; // Clear to prevent pop-in
        TextCreator.runTextPrint = false;

        // Set visible but ensure sliding animation handles appearance

        mainTextObject.SetActive(true); // If this triggers animation
        textBox.SetActive(true);

        yield return new WaitForSeconds(0.1f); // Let animation start

        // Now assign text and start typewriter
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;

        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 1;

    }
}
