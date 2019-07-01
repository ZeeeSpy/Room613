using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        loadingcircle.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
