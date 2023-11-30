using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform checkPoint;
    [SerializeField] private Collider collider;
    public static Transform m_CurrentCheckPoint;

    private void OnTriggerEnter(Collider other)
    {
        collider = GetComponent<Collider>();
        
        // Check if the object entering the collider is the player
        if (other.CompareTag("Player"))
        {
            // Set the current checkpoint to this checkpoint's transform
            m_CurrentCheckPoint = checkPoint;
            Invoke(nameof(Destroy), 6f);
        }
    }

    private void Destroy()
    {
        collider.enabled = false;
    }
}
