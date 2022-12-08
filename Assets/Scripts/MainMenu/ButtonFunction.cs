using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    public void StartGame(string sceneToLoading)
    {
        SceneManager.LoadScene(sceneToLoading);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void teste()
    {
        print("apertei o botão");
    }

}
