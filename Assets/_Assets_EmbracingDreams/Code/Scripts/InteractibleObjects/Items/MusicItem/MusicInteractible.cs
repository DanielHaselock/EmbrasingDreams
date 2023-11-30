using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Events;

public class MusicInteractible : InteractibleObject, IRespawnable
{
    // Start is called before the first frame update

    [SerializeField] private float Stamina_Charge = 50;

    private float m_CurrentTime = 0;
    public float m_RespawnTime = 2;

    private bool IsDeactivated = false;
    
    [SerializeField] private MMF_Player onPickup;
    [SerializeField] private MMF_Player onRespawn;

    void Awake()
    {
        base.Awake();

        GameManager.MusicNotePickups.Add(this, false);
    }

    private void Update()
    {
        if(IsDeactivated)
        {
            CountdownRespawn(Time.deltaTime);
        }
    }

    private void OnDestroy()
    {
        base.OnDestroy();
    }


    public override void TriggerCollision(Collider collision, [CallerMemberName] string message = null)
    {
        PlayerModes player = collision.gameObject.GetComponent<PlayerModes>();
        if (player)
        {
            onPickup.PlayFeedbacks();
            player.Add_Stamina(Stamina_Charge, true);
            if(GameManager.CheckPickup(this))
            {
                player.UpdateMusicNoteCollection();
            }
        }
        ChangeObjectState(false);
    }


    //Respawn


    public void CountdownRespawn(float Dt)
    {
        m_CurrentTime += Dt;
        if(m_CurrentTime >= m_RespawnTime)
        {
            m_CurrentTime = 0;
            Respawn();
        }
    }

    public void Respawn()
    {
        onRespawn.PlayFeedbacks();
        ChangeObjectState(true);
    }


    public void ChangeObjectState(bool Disable)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = Disable;
        gameObject.GetComponent<Collider>().enabled = Disable;
        IsDeactivated = !Disable;
    }

}
