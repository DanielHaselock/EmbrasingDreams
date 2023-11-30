using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[DefaultExecutionOrder(2)]
public class PlayerModes : MonoBehaviour
{

    //////////////////////////////////////////////


    [SerializeField] private float calm_stamina = 0;
    [SerializeField] private float max_calm_stamina = 100;
    [SerializeField] private float stamina_drain_amount = 5;
    [SerializeField] private MMF_Player staminaDrained;
    

    bool IsInWall = false;

    public int UniqueNotesCollected = 0;
    public enum PlayerMode
    {
        Hyper = 0,
        Calm = 1,
        both = 2
    }



    //////////////////////////////////////////////

    private PlayerMode m_PlayerMode;
    void Start()
    {
        m_PlayerMode = PlayerMode.Hyper;
        GameManager.NotifyPlayerState(m_PlayerMode);
    }

    private void Update()
    {
        DrainCalmStamina(Time.deltaTime);
    }


    public void OnModeTrigger(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            ChangeMode();
        }
    }

    public void ChangeMode()
    {
        if (m_PlayerMode == PlayerMode.Hyper && calm_stamina > 0)
        {
            m_PlayerMode = PlayerMode.Calm;
        }
        else if(m_PlayerMode == PlayerMode.Calm)
        {
            m_PlayerMode = PlayerMode.Hyper;

            if(gameObject.GetComponent<PlayerController>().IsInWall == true)
            {
                gameObject.GetComponent<PlayerController>().Death();
            }
        }
        else
        {
            return;
        }
        GameManager.NotifyPlayerState(m_PlayerMode);
    }


    private void DrainCalmStamina(float Dt)
    {
        if(m_PlayerMode == PlayerMode.Calm)
        {
            Add_Stamina(-Dt * stamina_drain_amount);

            if (calm_stamina <= 0)
            {
                calm_stamina = 0;
                staminaDrained.PlayFeedbacks();
                ChangeMode();
            }
        }
    }

    public void Add_Stamina(float Amount, bool ShowText = false)
    {
        calm_stamina += Amount;
        Modify_StaminaUI(Amount, m_PlayerMode == PlayerMode.Hyper ? ShowText : false);
        if (calm_stamina > max_calm_stamina)
            calm_stamina = max_calm_stamina;
    }

    public float Get_Stamina()
    {
        return calm_stamina;
    }

    public void Set_Stamina(float Amount)
    {
        calm_stamina = Amount;
        Modify_StaminaUI(Amount);
        if (calm_stamina > max_calm_stamina)
            calm_stamina = max_calm_stamina;
    }


    public void Modify_StaminaUI(float Amount, bool ShowText = false)
    {
        CalmStaminaUI staminaUI = GameObject.FindAnyObjectByType<CalmStaminaUI>();
        if (staminaUI)
            staminaUI.UpdateSliderValue(calm_stamina, max_calm_stamina, ShowText);
    }

    public void UpdateMusicNoteCollection()
    {
        UniqueNotesCollected++;
        if(GameObject.FindObjectOfType<UniqueNotesText>())
            GameObject.FindObjectOfType<UniqueNotesText>().UpdateNumberText();
    }
}
