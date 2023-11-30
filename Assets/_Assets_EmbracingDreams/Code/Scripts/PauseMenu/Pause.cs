using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    private bool IsPaused = false;
    public void PauseGame(bool paused)
    {
        if(IsPaused == paused)
            paused = !paused;

        IsPaused = paused;
        GameManager.PauseGame(paused);
        this.gameObject.SetActive(paused);
    }

    public void Quit(string name)
    {
        GameManager.PauseGame(false);
        SceneManager.LoadScene(name);
    }
}
