using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CalmStaminaUI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Slider Calm_Stamina;

    private TextMeshProUGUI Stamina_Text;

    private void Start()
    {
        Stamina_Text = transform.GetComponentInChildren<TextMeshProUGUI>();
        Stamina_Text.color = new Color(Stamina_Text.color.r, Stamina_Text.color.g, Stamina_Text.color.b, 0);
    }

    public void UpdateSliderValue(float CalmStaminaValue, float MaxCalmStaminaValue, bool ShowText)
    {
        Calm_Stamina.value = CalmStaminaValue / MaxCalmStaminaValue;

        if (ShowText)
            SetText(true);
        else if(Stamina_Text.color.a == 1)
            SetText(false); 
    }

    public void SetText(bool On)
    {
        StopAllCoroutines();
        if (On)
            StartCoroutine(FadeTextToFullAlpha(0.1f, Stamina_Text));
        else
            StartCoroutine(FadeTextToZeroAlpha(0.1f, Stamina_Text));
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
    }
}
