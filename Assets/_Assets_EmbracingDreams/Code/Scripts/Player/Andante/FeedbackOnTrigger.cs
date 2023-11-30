using System;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

public class FeedbackOnTrigger : MonoBehaviour
{
    [SerializeField] private MMF_Player feedback; // Reference to the MMF_Player feedback component.
    [SerializeField] private LayerMask triggerLayers; // Define which layers can trigger the feedback.
    [SerializeField] private bool requiresStamina; // Whether stamina is required to trigger the feedback.
    [SerializeField] private PlayerModes playerModes; // Reference to the PlayerModes script for stamina checking.
    
    [SerializeField] private TextMeshProUGUI text;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider's GameObject is on one of the triggerLayers.
        if ((triggerLayers & (1 << other.gameObject.layer)) != 0)
        {
            // Check if stamina is required and player has enough stamina.
            if (requiresStamina && playerModes.Get_Stamina() <= 0)
            {
                return; // Exit early if stamina is required but not enough is available.
            }

            // Trigger the feedback effect if all conditions are met.
            if (feedback != null)
            {
                Notifier notifier = other.gameObject.GetComponent<Notifier>();

                if (notifier && (notifier.triggerLayers & (1 << gameObject.layer)) != 0)
                {
                    text.SetText(notifier.toNotify);
                
                    feedback.StopFeedbacks();
                    feedback.PlayFeedbacks();
                }
            }
        }
    }
}