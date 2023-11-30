using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterVideo : MonoBehaviour
{
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] String _scene;

    private AsyncOperation _sceneLoading;

    private void Awake()
    {
        // Stops all playing sounds
        AkSoundEngine.StopAll();
    }

    private void Start() {
        
        StartCoroutine(ReadyScene());

        _videoPlayer.loopPointReached += (_) => _sceneLoading.allowSceneActivation = true;
    }

    private IEnumerator ReadyScene() {
        yield return null;
        _sceneLoading = SceneManager.LoadSceneAsync(_scene);
        _sceneLoading.allowSceneActivation = false;
        yield break;
    }

    private void OnPause() {
        _sceneLoading.allowSceneActivation = true;
    }
}