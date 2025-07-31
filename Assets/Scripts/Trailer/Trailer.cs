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

                case 1: yield return RunDialogue("???", "So. I guess I have to say that this is not footage from the real game first. For legal purposes..?"); break;
                case 2: yield return RunDialogue("???", "Anyway, I am putting all this extra effort in to show how much I like, you know!"); break;
                case 3: yield return RunDialogue("???", "..."); break;
                case 4: yield return RunDialogue("???", "It’s fine, don't worry."); break;
                case 5: yield return RunDialogue("???", "I know what you think, Nora."); break;
                case 6: yield return RunDialogue("???", "“It is just a stupid telpher.”"); break;
                case 7: yield return RunDialogue("???", "“Why can’t she just go there?”"); break;
                case 8: yield return RunDialogue("???", "You’d be right. So, really, it’s fine."); break;
                case 9: yield return RunDialogue("???", "Truthfully, I am scared to do many things."); break;
                case 10: yield return RunDialogue("???", "I am scared of sitting down and coding."); break;
                case 11: yield return RunDialogue("???", "I am scared of asking people questions."); break;
                case 12: yield return RunDialogue("???", "I am scared of playing games."); break;
                case 13: yield return RunDialogue("???", "I am scared of drinking coffee."); break;
                case 14: yield return RunDialogue("???", "And I am even scared of writing."); break;
                case 15: yield return RunDialogue("???", "I guess... since everything is filled with fear... I can’t help but think that everything is meaningless sometimes."); break;
                case 16: yield return RunDialogue("???", "It is meaningless to go to the telpher."); break;
                case 17: yield return RunDialogue("???", "It is meaningless to write a story about going to the telpher."); break;
                case 18: yield return RunDialogue("???", "It is meaningless to make a game about going to the telpher."); break;
                case 19: yield return RunDialogue("???", "It is meaningless to have a main menu that changes according to the time of the day."); break;
                case 20: yield return RunDialogue("???", "And yet, here we are."); break;
                case 21: yield return RunDialogue("???", "Here you are."); break;
                case 22: yield return RunDialogue("???", "This mundane life, devoid of any significance..."); break;
                case 23: yield return RunDialogue("???", "...Might not be so bad, when I am with you Nora."); break;
                case 24: yield return RunDialogue("???", "That's why... I hope I can become the person you can say this to."); break;
                case 25:
                    yield return RunDialogue("???", "So, let’s just get into it.");
                    SceneManager.LoadScene(1); 
                    break;
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
