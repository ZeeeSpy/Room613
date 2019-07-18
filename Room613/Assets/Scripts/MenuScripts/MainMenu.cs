using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public Light menulight;
    public GameObject menuMannequin;
    public AudioSource lightfizz;
    public AudioSource chasesound;
    public AudioSource lightfizzon;
    public GameObject loadingcircle;
    public GameObject UIButtons;
    public GameObject abouttext;
    public GameObject backbutton;

    public void LoadLevel(string _levelname)
    {
        StartCoroutine(LoadAsynchronously(_levelname));
       
        SceneManager.LoadSceneAsync(_levelname);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void About()
    {
        UIButtons.SetActive(false);
        abouttext.SetActive(true);
        backbutton.SetActive(true);
    }

    public void back()
    {
        UIButtons.SetActive(true);
        abouttext.SetActive(false);
        backbutton.SetActive(false);
    }

    public void Start()
    {
        StartCoroutine(MenuSequence());
        loadingcircle.SetActive(false);
        abouttext.SetActive(false);
        backbutton.SetActive(false);
    }


    IEnumerator LoadAsynchronously(string _levelname)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_levelname);
        loadingcircle.SetActive(true);
        while (!operation.isDone)
        {
            loadingcircle.transform.Rotate(0, 0, -100f * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator MenuSequence()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            lightfizz.Play();
            yield return new WaitForSeconds(1.2f);
            menulight.intensity = 0;
            menuMannequin.SetActive(false);
            yield return new WaitForSeconds(3.0f);
            lightfizzon.Play();
            menulight.intensity = 1;
            yield return new WaitForSeconds(5.0f);
            lightfizz.Play();
            yield return new WaitForSeconds(1.2f);
            menulight.intensity = 0;
            menuMannequin.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            lightfizzon.Play();
            menulight.intensity = 1;

        }
    }
}
