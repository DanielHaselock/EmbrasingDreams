using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TemporaryGameCompany;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XR;

public interface IRespawnable
{
    public void Respawn();
    public void CountdownRespawn(float Dt);

    public void ChangeObjectState(bool Disable);

}

public class InteractibleObject : MonoBehaviour
{
    protected void Awake()
    {
        GameManager.InteractibleObjects.Add(this);
    }
    public void OnDestroy()
    {
        GameManager.InteractibleObjects.Remove(this);
    }

    public virtual void Flush(int a){}


    void OnTriggerEnter(Collider collision) => TriggerCollision(collision);

    public virtual void TriggerCollision(Collider collision, [CallerMemberName] string message = null) { }


}
