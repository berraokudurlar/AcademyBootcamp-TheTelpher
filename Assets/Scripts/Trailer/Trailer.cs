using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trailer : MonoBehaviour
{
    public GameObject textBox;
    public AudioSource NextButtonClick;


    public GameObject charName;
    public GameObject mainTextObject;
    public GameObject nextButton;

    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] int eventPos = 0;
    void Start()
    {

        mainTextObject.SetActive(false);
        textBox.SetActive(false);
        nextButton.SetActive(false);
        

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

            case 1:
                yield return RunDialogue("???", "'Hey.'"); break;
            case 2:
                yield return RunDialogue("???", "'What's the problem?'"); break;
        }

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
