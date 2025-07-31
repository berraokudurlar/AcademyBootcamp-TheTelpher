using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueTimeSequence : MonoBehaviour
{
    public GameObject fadeIn;
    public GameObject fadeOut;
    public GameObject charBella;
    public GameObject textBox;
    public GameObject blackScreen;
    public AudioSource bgmSource;
    public AudioSource NextButtonClick;
    

    public GameObject charName;
    public GameObject mainTextObject;
    public GameObject nextButton;


    public int currentCase;
    public float fadeDuration = 1.5f;
    public float fadeOutDelay = 3f;
    public bool bellaShouldBeVisible = false;

    

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
        bgmSource.Stop();
        NextButtonClick.Stop();

        StartCoroutine(SetupStart());
    }

    void Update()
    {
        textLength = TextCreator.charCount;

        
        if (currentCase >= 31 && currentCase < 42)
        {
            bellaShouldBeVisible = true;
        }
        else
        {
            bellaShouldBeVisible = false;
        }
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
                yield return RunDialogue("NORA", "*It was so, so long ago."); break;
            case 2:                 
                yield return RunDialogue("NORA", "*When we made that promise."); break;
            case 3:            
                yield return RunDialogue("NORA", "*Back then, there was no way for me to know it.");

                yield return new WaitForSeconds(fadeDuration);

                blackScreen.SetActive(false);
                fadeIn.SetActive(true);
                fadeIn.GetComponent<Animator>().SetTrigger("Fade");
                bgmSource.Play();
                break;


            // NORA x29
            case 4:
                yield return RunDialogue("NORA", "*It was noon. That time when, after our last final exam, Bella and I went to grab some food at the nearest shopping mall.");
                break;
            case 5:
                yield return RunDialogue("NORA", "*I even remember that it was our French final. Not because I have a good memory.");
                break;
            case 6:
                yield return RunDialogue("NORA", "*It’s because I hate French.");
                break;
            case 7:
                yield return RunDialogue("NORA", "*We both used to stay at the school dorms, when we met.");
                break;
            case 8:
                yield return RunDialogue("NORA", "*We became friends because there was a French cinema week within our campus. And we had nothing better to do.");
                break;
            case 9:
                yield return RunDialogue("NORA", "*This makes me realize, how big of a role the French language played in this friendship.");
                break;
            case 10:
                yield return RunDialogue("NORA", "*Well, enough about that.");
                break;
            case 11:
                yield return RunDialogue("NORA", "*This semester, I moved out to my own place, while Bella stayed because of her scholarship.");
                break;
            case 12:
                yield return RunDialogue("NORA", "*We might not live in the same building and violate the dorm rules to stay up playing games anymore, but my apartment is very close. So she sometimes shows up in front of my door to go out.");
                break;
            case 13:
                yield return RunDialogue("NORA", "*“I’m in your walls,” she texts to me.");
                break;
            case 14:
                yield return RunDialogue("NORA", "*After leaving the mall, we go back from the same path, which has the most bothersome slope imaginable, but the only thing Bella is bothered about is the occasional deep breaths she has to take to continue her speech.");
                break;
            case 15:
                yield return RunDialogue("NORA", "*I find it disturbing that she prefers slopes over stairs. How can anyone?");
                break;
            case 16:
                yield return RunDialogue("NORA", "*Speaking of the unpredictable. Bella loves to speak.");
                break;
            case 17:
                yield return RunDialogue("NORA", "*No... she doesn’t like to speak. Because she has problems with speaking. She rather just likes to express what’s on her mind.");
                break;
            case 18:
                yield return RunDialogue("NORA", "*No... she doesn’t like that either.");
                break;
            case 19:
                yield return RunDialogue("NORA", "*Whenever she has a problem with our friend group, she doesn’t express it, and avoids conflict.");
                break;
            case 20:
                yield return RunDialogue("NORA", "*I guess she has so much resentment inside her.");
                break;
            case 21:
                yield return RunDialogue("NORA", "*But she is not the type to bottle. Instead, she comes to me.");
                break;
            case 22:
                yield return RunDialogue("NORA", "*I really like to listen. Or read her long, long rants. She dreams to be a writer, so that’s kind of her specialty.");
                break;
            case 23:
                yield return RunDialogue("NORA", "*While we are climbing the scope, I fix my eyes on the scenery. Our university can be seen, and the mountains lie behind it.");
                break;
            case 24:
                yield return RunDialogue("NORA", "*When it’s a cloudless, fogless winter at noon, I can easily see the colorful telphers that are going up or down.");
                break;
            case 25:
                yield return RunDialogue("NORA", "*We are third-year students, and this is our second year spent on campus.");
                break;
            case 26:
                yield return RunDialogue("NORA", "*Yet, we haven’t ridden the telphers yet, not even once.");
                break;
            case 27:
                yield return RunDialogue("NORA", "'It is strange that we never went to where telphers are.'");
                break;
            case 28:
                yield return RunDialogue("NORA", "'...Why don’t we go there sometime?'");
                break;
            case 29:
                yield return RunDialogue("NORA", "*My offer is met with silence.");
                break;
            case 30:
                yield return RunDialogue("NORA", "*But I know she will speak soon.");
                break;
            case 31:
                yield return RunDialogue("NORA", "*She just takes pride in her spoken sentences, as much as she takes in the written ones.");
                break;
            case 32:
                yield return RunDialogue("NORA", "*She sometimes pauses amid them. It is weird, but it is charming too.");
                break;
            


            // BELLA x2
            case 33:
                charBella.SetActive(true);
                yield return RunDialogue("BELLA", "'I would like to.'"); break;
            case 34:
                yield return RunDialogue("BELLA", "'I… always wanted to go there…'"); break;

            // NORA x1
            case 35:
                charBella.SetActive(false);
                yield return RunDialogue("NORA", "Me too!"); break;

            // Alternating
            case 36: yield return RunDialogue("BELLA", "'…And see what kind of things are there, at the top. But as I procrastinated… and procrastinated… my expectations greatly increased, I started to pursue a perfect, ideal day… and none of the days I had seemed enough. And now… I find myself too scared to go and see.'"); break;
            case 37: yield return RunDialogue("NORA", "*She doesn’t stop there. But her pace cannot be called a continuation either."); break;
            case 38: yield return RunDialogue("BELLA", "'I think that there are things you must do alone. When I think a movie will influence me a lot, I don’t invite anyone at all, and I see them by myself, you know. Things like that.'"); break;
            case 39: yield return RunDialogue("BELLA", "'That’s why… I’ve always thought that I would go there alone…'"); break;
            case 40: yield return RunDialogue("BELLA", "'And  finally live my ideal day, alone.'"); break;
            case 41: yield return RunDialogue("BELLA", "'But it seems that I am incapable of doing that… That's why, when the other semester starts, and I don’t have much to do, let’s go there, together.'"); break;
            case 42: yield return RunDialogue("BELLA", "'If you want me to remember you forever, that is.'"); break;
            case 43: yield return RunDialogue("NORA", "*She finishes her sentence with a laugh, and it is just the time we arrive in front of the gates of my home."); break;
            case 44:
                charBella.SetActive(false);
                yield return RunDialogue("NORA", "*So we say goodbye to each other."); break;
            case 45: yield return RunDialogue("NORA", "*I don’t set a date."); break;
            case 46: yield return RunDialogue("NORA", "*I don’t follow up with acknowledgement."); break;
            case 47: yield return RunDialogue("NORA", "*But it is still a promise."); break;
            case 48: yield return RunDialogue("NORA", "*Normally, I would walk her to the back gates of the campus."); break;
            case 49: yield return RunDialogue("NORA", "*But for today, Bella continues the rest of the road by herself."); break;
            case 50: yield return RunDialogue("NORA", "*And I only watch her back."); break;

           
            case 51:
                fadeOut.SetActive(true);
                fadeOut.GetComponent<Animator>().SetTrigger("Fade");
                bgmSource.Stop();
                yield return new WaitForSeconds(fadeOutDelay);
                yield return RunDialogue("NORA", "*As if I must also remember it, forever."); break;

            // Scene ends
            case 52:
                mainTextObject.SetActive(false);
                textBox.SetActive(false);
                nextButton.SetActive(false);
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene("Epilogue"); break;
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
