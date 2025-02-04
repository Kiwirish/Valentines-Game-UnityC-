using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void GoToInstructions()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("InstructionsScene");
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void ShowEndScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
    }

    public void ReturnToTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }
}
