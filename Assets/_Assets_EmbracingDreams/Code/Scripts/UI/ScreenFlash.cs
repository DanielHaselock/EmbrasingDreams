using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFlashUI : MonoBehaviour
{

    [SerializeField] public float DecreaseAmount = 50;
    [SerializeField] public float IncreaseAmount = 50;
    [SerializeField]
    private Image Image;
    private bool IsDecreasing = false;
    private bool IsIncreasing = false;
    private float CurrAlpha = 255;

    // Update is called once per frame
    void Update()
    {
        if (IsDecreasing)
            DecreaseAlpha();

        if (IsIncreasing)
            IncreaseAlpha();

    }

    public void SetDecrease(bool Decrease)
    {
        IsDecreasing = Decrease;

        if(Decrease)
            CurrAlpha = 255;
    }
    public void SetAlpha(float Alpha)
    {
        CurrAlpha = Alpha;
    }

    public void SetIncrease(bool Increase)
    {
        IsIncreasing = Increase;
    }
    private void DecreaseAlpha()
    {
        CurrAlpha -= Time.deltaTime * DecreaseAmount * 1 / Time.timeScale;
        Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, CurrAlpha / 255);


        if (CurrAlpha <= 0)
        {
            SetDecrease(false);   
        }
    }

    private void IncreaseAlpha()
    {
        CurrAlpha += Time.deltaTime * IncreaseAmount * 1/Time.timeScale;
        Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, CurrAlpha / 255);


        if (CurrAlpha >= 255)
        {
            SetIncrease(false);
        }
    }

    public bool CheckStopIncrease()
    {
        return !IsIncreasing;
    }
}
