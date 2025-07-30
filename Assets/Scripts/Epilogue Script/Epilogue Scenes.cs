using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EpilogueScenes : MonoBehaviour
{
    public GameObject fadeIn;
    public GameObject fadeOut;
    public GameObject charBella;
    public GameObject textBox;
    public GameObject blackScreen;
    public AudioSource bgmSource;
    public AudioSource NextButtonClick;
    public AudioSource theTelpher;


    public GameObject charName;
    public GameObject mainTextObject;
    public GameObject nextButton;


    public int currentCase;
    public float fadeDuration = 1.5f;
    public float fadeOutDelay = 3f;
    public bool bellaShouldBeVisible = false;

    public static bool isTextDonePrinting = false;

    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] int eventPos = 0;

    void Start()
    {

        blackScreen.SetActive(true);
        fadeIn.SetActive(false);
        fadeOut.SetActive(false);
        charBella.SetActive(false);
        mainTextObject.SetActive(false);
        textBox.SetActive(false);
        nextButton.SetActive(false);
        theTelpher.Play();
        bgmSource.Stop();
        NextButtonClick.Stop();

        StartCoroutine(SetupStart());
    }

    void Update()
    {
        textLength = TextCreator.charCount;

       

    }

    IEnumerator SetupStart()
    {
        mainTextObject.SetActive(true);
        textBox.SetActive(true);
        nextButton.SetActive(true);
        eventPos = 1;
        yield return StartCoroutine(RunEvent(eventPos));
    }

    public void NextButton()
    {
        NextButtonClick.Play();
        eventPos++;
        StartCoroutine(RunEvent(eventPos));
    }

    IEnumerator RunEvent(int id)
    {
        nextButton.SetActive(false);

        switch (id)
        {
            // NORA x3 (black screen, no music)
            case 1: yield return RunDialogue("NORA", "*We finally finish waiting for the one we will ride, it all happens too soon."); break;
            case 2: yield return RunDialogue("NORA", "*Not too long ago. Opposite, really. Yesterday."); break;
            case 3: yield return RunDialogue("NORA", "*Bella asked me."); break;
            case 4: yield return RunDialogue("NORA", "*It was the first time she asked by herself."); break;
            case 5: yield return RunDialogue("NORA", "*With no intention to delay this."); break;
            case 6: yield return RunDialogue("NORA", "*“Let’s go to the telphers. Tomorrow. After your classes.”"); break;
            case 7: yield return RunDialogue("NORA", "*With such unshakeable, strong certainty."); break;
            case 8: yield return RunDialogue("NORA", "*I think she is the most decisive when she is the most impulsive."); break;
            case 9: yield return RunDialogue("NORA", "*And just like that, she met me on the fifth floor of the building. She took the stairs to meet with me."); break;
            case 10: yield return RunDialogue("NORA", "*She talked so smoothly that our Japanese lecturer got weirded out."); break;
            case 11: yield return RunDialogue("NORA", "*We asked about my student card not working on the way."); break;
            case 12: yield return RunDialogue("NORA", "*She finally made me request my diploma from the student affairs department."); break;
            case 13: yield return RunDialogue("NORA", "*Just on the way as well."); break;
            case 14: yield return RunDialogue("NORA", "*It is just a Wednesday evening, but what a week, huh."); break;
            case 15: yield return RunDialogue("NORA", "*We got out of the school."); break;
            case 16: yield return RunDialogue("NORA", "*We crossed the street."); break;
            case 17: yield return RunDialogue("NORA", "*The ticket office allowed us to go inside."); break;
            case 18: yield return RunDialogue("NORA", "*So we passed the ticket barriers. They were regular turnstiles. Like the ones in the subways."); break;
            case 19: yield return RunDialogue("NORA", "*We used our student transportation cards for it."); break;
            case 20: yield return RunDialogue("NORA", "*All that greatness, and it is just another transportation vehicle."); break;
            case 21: yield return RunDialogue("NORA", "*It is somehow cheaper than we both expected."); break;
            case 22: yield return RunDialogue("NORA", "*We waited two years for this, after all. The exchange rate quadrupled since then."); break;
            case 23: yield return RunDialogue("NORA", "*But maybe because it is that fun for us, we didn’t find it expensive at all."); break;
            case 24: yield return RunDialogue("NORA", "*The interiors have a modern feeling to it."); break;
            case 25: yield return RunDialogue("NORA", "*The telphers come and go in many colors, and it is relatively empty, since we came in late."); break;
            case 26: yield return RunDialogue("NORA", "*What was the color we chose..?"); break;
            case 27:
                
                yield return RunDialogue("NORA", "*Back then, there was no way for me to know it.");

                yield return new WaitForSeconds(fadeDuration);

                blackScreen.SetActive(false);
                fadeIn.SetActive(true);
                fadeIn.GetComponent<Animator>().SetTrigger("Fade");
                bgmSource.Play();
                break;
        }

        IEnumerator RunDialogue(string speaker, string dialogue)
        {
            charName.GetComponent<TMPro.TMP_Text>().text = speaker;
            textBox.GetComponent<TMPro.TMP_Text>().text = "";
            textToSpeak = dialogue;
            currentTextLength = dialogue.Length;
            TextCreator.runTextPrint = false;

            textBox.GetComponent<TMPro.TMP_Text>().text = dialogue;
            TextCreator.runTextPrint = true;

            yield return new WaitForSeconds(0.05f);
            yield return new WaitForSeconds(1);
            yield return new WaitUntil(() => textLength == currentTextLength);
            yield return new WaitForSeconds(0.05f);

            nextButton.SetActive(true);
        }

        }
}
