using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string scenetoload;

    public void changelevel(GameObject player)
    {
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(scenetoload);
    }
}
