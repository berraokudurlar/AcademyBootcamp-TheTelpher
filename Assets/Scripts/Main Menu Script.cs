using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private AudioSource buttonClick;

    public void NewGame()
    {
        Debug.Log("NEW GAME BUTTON CLICKED");

        if (buttonClick != null)
            buttonClick.Play();

        StartCoroutine(PrologueStart());
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME BUTTON CLICKED");

        if (buttonClick != null)
            buttonClick.Play();

        
        Application.Quit();
    }

    IEnumerator PrologueStart()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2); 
    }
}
