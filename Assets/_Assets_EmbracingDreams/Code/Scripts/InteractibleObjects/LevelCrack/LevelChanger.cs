using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : InteractibleObject
{
    // Start is called before the first frame update

    [SerializeField] private string LevelName;
    [SerializeField] private LayerMask collisionLayerMask; // Assign the mask in the inspector
    [SerializeField]
    private ScreenFlashUI LoadScreen;

    void Awake()
    {
        base.Awake();
    }

    private void OnDestroy()
    {
        base.OnDestroy();
    }


    public override void TriggerCollision(Collider collision, [CallerMemberName] string message = null)
    {
        if (((1 << collision.gameObject.layer) & collisionLayerMask) != 0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(FadeAndLoadScene());
        }
    }

    public IEnumerator FadeAndLoadScene()
    {
        LoadScreen.SetAlpha(0);
        LoadScreen.IncreaseAmount = 100f;
        LoadScreen.SetIncrease(true);
        GameManager.SetTime(0.5f);
        yield return new WaitUntil(LoadScreen.CheckStopIncrease);
        GameManager.SetTime(1);
        LoadScreen.IncreaseAmount = 200f;
        SceneManager.LoadScene(LevelName);
    }
}
