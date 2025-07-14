using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCreator : MonoBehaviour
{


    public static TMPro.TMP_Text viewText;
    public static bool runTextPrint;
    public static bool isTextDonePrinting = false;
    public static int charCount;
    [SerializeField] string transferText;
    [SerializeField] int internalCount;
    void Start()
    {


    }

    private void Update()
    {
        internalCount = charCount;
        charCount = GetComponent<TMPro.TMP_Text>().text.Length;
        if (runTextPrint == true)
        {
            runTextPrint = false;
            viewText = GetComponent<TMPro.TMP_Text>();
            transferText = viewText.text;
            viewText.text = "";
            StartCoroutine(RollText());
        }

    }
    IEnumerator RollText()
    {

        isTextDonePrinting = false;

        foreach (char c in transferText)
        {
            viewText.text += c;
            yield return new WaitForSeconds(0.03f);

        }

        isTextDonePrinting = true;

    }
}