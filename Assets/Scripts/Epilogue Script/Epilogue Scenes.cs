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
            
            case 1: yield return RunDialogue("NORA", "*The telpher car we will ride finally arrives in front of us."); break;
            case 2: yield return RunDialogue("NORA", "*We got to this point a bit suddenly... It was only yesterday."); break;
            case 3: yield return RunDialogue("NORA", "*When Bella asked me."); break;
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
            case 26: yield return RunDialogue("NORA", "*The color we chose was navy blue."); break;
            case 27: yield return RunDialogue("NORA", "*Bella made Persona 3 jokes about it, as always."); break;
            case 28: yield return RunDialogue("NORA", "*The three primary colors. Persona 3, Persona 4 and Persona 5."); break;
            case 29: yield return RunDialogue("NORA", "*The telpher car we will ride finally arrived in front of us."); break;
            case 30: yield return RunDialogue("NORA", "*And we got in."); break;


            case 31:
                
                yield return RunDialogue("NORA", "Bella sits at first. But I want to look at the scenery, so I stand up.");

                yield return new WaitForSeconds(fadeDuration);

                blackScreen.SetActive(false);
                fadeIn.SetActive(true);
                fadeIn.GetComponent<Animator>().SetTrigger("Fade");
                bgmSource.Play();
                break;

            case 32: 
                charBella.SetActive(true);
                yield return RunDialogue("BELLA", "‘Shouldn’t you look the other way round?’"); break;

            case 33: yield return RunDialogue("NORA", "I look at the city landscape getting larger and larger as we ascend."); break;
            case 34: yield return RunDialogue("NORA", "*Meanwhile, Bella is watching the mountains coming at us.\r\n"); break;
            case 35: yield return RunDialogue("NORA", "‘Aren’t you supposed to watch the city afar from here?’"); break;
            case 36: yield return RunDialogue("BELLA", "‘Is that so…’"); break;
            case 37: yield return RunDialogue("NORA", "*Hearing my words, she stands up."); break;
            case 38: yield return RunDialogue("NORA", "*The telpher gets faster and faster, and sometimes it passes through some control points, which never fails to jumpscare us."); break;
            case 39: yield return RunDialogue("NORA", "*We stand against each other, but face the same direction."); break;
            case 40: yield return RunDialogue("NORA", "*Beneath the dirty windows, we try to make sense of everything."); break;
            case 41: yield return RunDialogue("NORA", "*Bella points out every spot we both know. Mostly shopping malls. The buildings behind the sea. The ferry pier, too.\r\n"); break;
            case 42: yield return RunDialogue("NORA", "‘I wonder if I can see my house up there!’"); break;
            case 43: yield return RunDialogue("NORA", "*It’s funny, I changed my house again ever since we made that promise."); break;
            case 44: yield return RunDialogue("NORA", "*And Bella also doesn’t stay at the dorms anymore. Her family house is a bit far away from the university."); break;
            case 45: yield return RunDialogue("BELLA", "‘Hah! I wonder if I can see mine!’"); break;
            case 46: yield return RunDialogue("NORA", "*I try to figure out the districts of the city, and she tries to help me."); break;
            case 47: yield return RunDialogue("NORA", "*Among all these, we sometimes see small delivery cars, or even motorcycles driving on a secret path among the mountains.\r\n"); break;
            case 48: 
                theTelpher.Stop();
                yield return RunDialogue("NORA", "Without spotting our houses or mapping out the city, we arrive at the very top."); break;
            case 49: yield return RunDialogue("NORA", "*It was a long ride, but nonetheless, way faster than I thought."); break;
            case 50: yield return RunDialogue("BELLA", "‘I imagined this ride so many times, but never like this.'"); break;
            case 51: yield return RunDialogue("BELLA", "‘I thought we would sit side by side. And everything would be real slow… And we would talk about deep things.’"); break;
            case 52: yield return RunDialogue("BELLA", "‘I wonder how did I even get that idea. It would be boring... Real life is not the place for scripted dialogues, anyway.’"); break;
            case 53: yield return RunDialogue("NORA", "*I don’t really know how to reject, or affirm her points."); break;
            case 54: yield return RunDialogue("NORA", "‘It is like that, I guess.’"); break;
            case 55: yield return RunDialogue("NORA", "*That is all I can say."); break;
            case 56: yield return RunDialogue("NORA", "*The upper part of the telpher has the same modern interiors."); break;
            case 57: yield return RunDialogue("NORA", "*Funnily enough, it doesn’t have turnstiles to transfer stations."); break;
            case 58: yield return RunDialogue("NORA", "*Thank God, they let us get out of here freely."); break;
            case 59: yield return RunDialogue("NORA", "*We descend from the stairs, and explore the lower part of the area first, before stepping out to the wider area with the whole forest lying down."); break;
            case 60: yield return RunDialogue("NORA", "*Bella suddenly runs to the glass bars that divide us from the dangerous zone."); break;
            case 61: yield return RunDialogue("NORA", "*There is a warning sign that reads, “PLEASE DON’T LEAN AGAINST THE BARS’."); break;
            case 62: yield return RunDialogue("BELLA", "‘Can you, like, take a photo of me, while I am leaning against those?’"); break;
            case 63: yield return RunDialogue("NORA", "*Liking the idea, I grin and nod."); break;
            case 64: yield return RunDialogue("NORA", "*Despite this sudden spark of troublemaking though, Bella doesn’t give her whole weight."); break;
            case 65: yield return RunDialogue("NORA", "*Her black and yellow, thick winter dress, her black cardigan, and her puffer coat all mix within the photo."); break;
            case 66: yield return RunDialogue("NORA", "*We then head away to the mounted binoculars."); break;
            case 67: yield return RunDialogue("NORA", "*They were just one stairs down, and probably we were both somehow attracted to them."); break;
            case 68: yield return RunDialogue("NORA", "*Once we get to them, Bella takes out her wallet and gives me two coins to unlock the binoculars."); break;
            case 69: yield return RunDialogue("NORA", "*I don’t reject her kindness, and put the coins in."); break;
            case 70: yield return RunDialogue("NORA", "‘Why do they expect us to carry coins in this economy?’"); break;
            case 71: yield return RunDialogue("BELLA", "‘Not that we even carry the lowest amount of banknotes.’"); break;
            case 72: yield return RunDialogue("NORA", "‘...I guess cheaper is better.’"); break;
            case 73: yield return RunDialogue("NORA", "*I try to focus on the zoomed in scenery, moving the binocles."); break;
            case 74: yield return RunDialogue("NORA", "*It is a bit difficult to make sense of it, and see it all without blurs."); break;
            case 75: yield return RunDialogue("NORA", "*But as we get the hang of it, I try to search for my home once more."); break;
            case 76: yield return RunDialogue("NORA", "*I am not from this city, after all."); break;
            case 77: yield return RunDialogue("NORA", "*There is not really somewhere I can spot out like a local, and be happy to see it, like a local."); break;
            case 78: yield return RunDialogue("NORA", "*Not that I can give any concrete directions in my home town."); break;
            case 79: yield return RunDialogue("NORA", "*As approximately thirty seconds pass away, I step away and look at Bella."); break;
            case 80: yield return RunDialogue("NORA", "‘It’s your turn now.’"); break;
            case 81: yield return RunDialogue("NORA", "*Although a bit surprised, she hurries to make the most of it."); break;
            case 82: yield return RunDialogue("NORA", "*And I look at how she looks at things."); break;
            case 83: yield return RunDialogue("NORA", "*She fixates in, I assume, a few familiar places."); break;
            case 84: yield return RunDialogue("NORA", "*Then, the sea."); break;
            case 85: yield return RunDialogue("NORA", "*Then, the sky."); break;
            case 86: yield return RunDialogue("NORA", "*We come all the way here, but for now, instead of exploring the things we technically never saw, we are just discovering new ways of looking at the things we thought we were familiar with."); break;
            case 87: yield return RunDialogue("NORA", "*Once the time is up, Bella also steps away from the binoculars."); break;
            case 88: yield return RunDialogue("BELLA", "‘You know, yesterday, around like, 01.00 AM, I published a story. Anonymously.’"); break;
            case 89: yield return RunDialogue("NORA", "‘Oh, wow?’"); break;
            case 90: yield return RunDialogue("NORA", "‘Congrats, can I read it too?’"); break;
            case 91: yield return RunDialogue("BELLA", "‘Of course... I wanted you to be the first, or maybe only person who knows about it, at least out of the people I have to look at their faces.’"); break;
            case 92: yield return RunDialogue("BELLA", "‘I’ll send it to you.’"); break;
            case 93: yield return RunDialogue("BELLA", "‘I never thought I would be able to publish it.’"); break;
            case 94: yield return RunDialogue("BELLA", "‘Also, well, we said that we’d go to the telpher two years ago, on 16.01.2023, to be exact.’"); break;
            case 95: yield return RunDialogue("NORA", "‘My God... How do you even remember that?.. Two whole years, huh.’"); break;
            case 96: yield return RunDialogue("BELLA", "‘Hahaha.’"); break;
            case 97: yield return RunDialogue("BELLA", "‘Anyways, then I said that I quit writing in February.’"); break;
            case 98: yield return RunDialogue("BELLA", "‘I thought it was over. The earthquake occurring. Internships coming up. Elections coming up. Real adulthood coming up... and me, not doing anything for that goal.’"); break;
            case 99: yield return RunDialogue("BELLA", "‘At the end, I still wrote a poem in February. On 26.02.2023, to be exact.’"); break;
            case 100: yield return RunDialogue("NORA", "*And today is 26.02.2025. Somehow.’"); break;
            case 101: yield return RunDialogue("BELLA", "‘Once I published that story, I felt like I could do anything now, you know?’"); break;
            case 102: yield return RunDialogue("NORA", "‘Like finally going here.’"); break;
            case 103: yield return RunDialogue("BELLA", "‘Yes.’"); break;
            case 104: yield return RunDialogue("BELLA", "‘I guess even some silly promise that was delayed for like, two years can be finally lived up to.’"); break;
            case 105: yield return RunDialogue("BELLA", "‘The things I thought to be impossible can be possible...'"); break;
            case 106: yield return RunDialogue("BELLA", "‘And instead of waiting for the ideal, I need to make a true effort to reach for it.’"); break;
            case 107: yield return RunDialogue("BELLA", "‘For example... I actually wrote a poem for this telpher stuff back then. It was like, even before we discussed it. It was that much of a big deal for me.’"); break;
            case 108: yield return RunDialogue("NORA", "‘For real? Can you read it?’"); break;
            case 109: yield return RunDialogue("BELLA", "‘Nope... At least not for now...’"); break;
            case 110: yield return RunDialogue("BELLA", "‘Because I forgot to bring it, hahaha!’"); break;
            case 111: yield return RunDialogue("NORA", "‘Out of all these days, you managed to forget it now?!’"); break;
            case 112: yield return RunDialogue("BELLA", "‘Not so much of an ideal day, isn’t it?’"); break;
            case 113: yield return RunDialogue("BELLA", "‘But I guess that’s fine.’"); break;

            case 114:

                charBella.SetActive(false);
                fadeOut.SetActive(true);
                fadeOut.GetComponent<Animator>().SetTrigger("Fade");
                bgmSource.Stop();
                yield return new WaitForSeconds(fadeOutDelay); 
                yield return RunDialogue("BELLA", "‘Well, I was the one who said that scripted dialogues are all boring in real life.’"); 
                break;

            case 115: yield return RunDialogue("BELLA", "‘And yet, there are many things I wish to deliver, to be honest. I want to say sorry for dragging you in with me, making you the leakage of my negativity... Even though you probably forgot all about it.’"); break;
            case 116: yield return RunDialogue("BELLA", "‘I never had the time, the opportunity to say this. Not that you don't know it. But... you mean a lot to me.’"); break;
            case 117: yield return RunDialogue("BELLA", "‘That’s why we are here together, right?’"); break;
            case 118: yield return RunDialogue("BELLA", "‘So, thank you for always being here...’"); break;
            case 119: yield return RunDialogue("BELLA", "‘And thank you for listening...’"); break;
            case 120: yield return RunDialogue("BELLA", "‘Nora.’"); break;

            // Scene ends
            
            case 121:
                mainTextObject.SetActive(false);
                textBox.SetActive(false);
                nextButton.SetActive(false);
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene("Credits"); 
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
