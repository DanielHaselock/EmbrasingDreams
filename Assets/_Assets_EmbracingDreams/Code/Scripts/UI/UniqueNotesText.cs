using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UniqueNotesText : MonoBehaviour
{
    [SerializeField] public float DecreaseAmount = 50;

    private TextMeshProUGUI Text;
    private Image Image;

    static public int numb;
    int maxnumb = 0;
    
    private bool IsDecreasing = false;
    private bool IsIncreasing = false;
    private float CurrAlpha = 255;
    
    void Start()
    {
        Text = transform.GetComponent<TextMeshProUGUI>();
        Image = transform.GetComponentInChildren<Image>();
        
        Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, 0f);
        Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, 0f);
    }

    private void Update()
    {
        if(GameManager.MusicNotePickups.Count != maxnumb)
        {
            UpdateMaxNumberText(GameManager.MusicNotePickups.Count);
        }
        
        if (IsDecreasing)
            DecreaseAlpha();
    }
    public void UpdateNumberText()
    {
        numb++;
        UpdateText();
    }

    public void UpdateMaxNumberText(int Maxnumber)
    {
        maxnumb = Maxnumber;
        UpdateText();
    }

    public void UpdateText()
    {
        Text.SetText(numb.ToString() + "/" + maxnumb.ToString());
        if (numb > 0) MakeVisible();
    }
    
    private void DecreaseAlpha()
    {
        CurrAlpha -= Time.deltaTime * DecreaseAmount * 1 / Time.timeScale;
        Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, CurrAlpha / 255);
        Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, CurrAlpha / 255);


        if (CurrAlpha <= 0)
        {
            IsDecreasing = false;   
        }
    }

    private void MakeVisible()
    {
        CurrAlpha = 255f;
        Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, CurrAlpha / 255);
        Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, CurrAlpha / 255);

        IsDecreasing = true;
    }
}
