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
    public bool spinning = false;
    public GameObject loadingcircle;

    public void LoadLevel(string _levelname)
    {
        loadingcircle.SetActive(true);
        spinning = true;
        SceneManager.LoadSceneAsync(_levelname);
    }

    private void Update()
    {
        if (spinning)
        {
            loadingcircle.transform.Rotate(0, 0, 100f * Time.deltaTime);
        }   
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Start()
    {
        StartCoroutine(MenuSequence());
        loadingcircle.SetActive(false);
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
