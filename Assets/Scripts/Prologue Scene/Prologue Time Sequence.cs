using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueTimeSequence : MonoBehaviour
{
    public GameObject fadeIn;
    public GameObject fadeOut;
    public GameObject charBella;
    public GameObject textBox;
    public AudioSource bgmSource;

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



    void Update()
    {
        textLength = TextCreator.charCount;
    }

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


    IEnumerator EventStarter()
    {
        yield return new WaitForSeconds(preFadeDelay);

        Animator fadeAnimator = fadeIn.GetComponent<Animator>();
        if (fadeAnimator != null)
        {
            fadeAnimator.SetTrigger("Fade");
            yield return new WaitForSeconds(1.5f);
        }
        else
        {
            yield return new WaitForSeconds(1f);
            fadeIn.SetActive(false);
        }

        yield return new WaitForSeconds(postFadeDelay);
        if (bgmSource != null)
        {
            bgmSource.Play();
        }

        charName.GetComponent<TMPro.TMP_Text>().text = "NORA";

        // Set up textBox and mainTextObject before showing
        textToSpeak = "After our last final exam, Bella and I went to grab some food at the nearest shopping mall.";

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

    IEnumerator EventOne()
    {
        nextButton.SetActive(false);
        yield return new WaitForSeconds(charAppearDelay);

        charBella.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "BELLA";

        // Do NOT set isTextDonePrinting to true here!
        TextCreator.isTextDonePrinting = false;

        textToSpeak = "“I think that there are things you must do alone. When I think a movie will influence me a lot, I don’t invite anyone at all, and I see them by myself, you know. Things like that. I’ve always thought that I would go there alone… But it seems that I am incapable of doing that… When the other semester starts, and I don’t have much to do, let’s go there, together.”";

        textBox.GetComponent<TMPro.TMP_Text>().text = ""; // Clear to prevent pop-in
        TextCreator.runTextPrint = false;

        yield return new WaitForSeconds(0.1f); // Let animation start    
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;

        TextCreator.runTextPrint = true;

        // ✅ Now wait until the typewriter effect signals that it's done
        yield return new WaitUntil(() => TextCreator.isTextDonePrinting);

        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(fadeAppearDelay);

        fadeOut.SetActive(true); 
        Animator fadeAnimator = fadeOut.GetComponent<Animator>();
        fadeAnimator.SetTrigger("Fade");

        SceneManager.LoadScene(3);
    }



    public void NextButton()
    {
        if (eventPos == 1)
        {
            StartCoroutine(EventOne());
        }

    }
}