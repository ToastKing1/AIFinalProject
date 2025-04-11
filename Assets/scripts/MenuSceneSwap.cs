using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneSwap : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("BaseScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
