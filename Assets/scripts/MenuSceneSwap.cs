using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneSwap : MonoBehaviour
{
    // play the game
    public void playGame()
    {
        SceneManager.LoadScene("BaseScene");
    }
    // quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
