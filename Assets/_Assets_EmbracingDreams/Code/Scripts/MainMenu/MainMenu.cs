using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private String sceneName;
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName); 
    }

    public void Quit()
    {
        Application.Quit();
    }
}
