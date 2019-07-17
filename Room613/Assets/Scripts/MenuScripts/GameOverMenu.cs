using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public bool spinning = false;
    public GameObject loadingcircle;
    public Text hinttextbox;

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
        hinttextbox.text = hints();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private string hints()
    {
        string [] hints = new string [10];
        hints[0] = "Hint: Mannequins can only kill when you're not looking at them";
        hints[1] = "Hint: If you hear static that means you're in trouble!";
        hints[2] = "Hint: Collect 5 coins and place them in the coin box to escape";
        hints[3] = "Hint: Not all mannequins can move";
        hints[4] = "Hint: If you find youself running forever, turn back and try again";
        hints[5] = "Hint: There are only three Mannequins that can kill you";
        hints[6] = "Hint: Mannequins can't move if you look at them";
        hints[7] = "Hint: The map will show you all rooms you've been in/haven't been in";

        return hints[Random.Range(0, 7)];
    }

}
