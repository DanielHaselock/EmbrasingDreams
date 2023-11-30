using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

[AddComponentMenu("Wwise/WwiseEvent")]
[FeedbackHelp("Plays a Wwise event.")]
[FeedbackPath("Wwise/WwiseEvent")]
public class WwiseEvent : MMF_Feedback
{
    /// a static bool used to disable all feedbacks of this type at once
    public static bool FeedbackTypeAuthorized = true;
    /// use this override to specify the duration of your feedback (don't hesitate to look at other feedbacks for reference)
    public override float FeedbackDuration { get { return 0f; } }
    
    /// pick a color here for your feedback's inspector
#if UNITY_EDITOR
    public override Color FeedbackColor { get { return MMFeedbacksInspectorColors.DebugColor; } }
#endif


    [MMFInspectorGroup("Wwise", true, 54, true)]
    /// the Image to affect when playing the feedback
    [Tooltip("the Image to affect when playing the feedback")]
    public String _wwiseEventName;
    public float stopAfterSeconds = -1f;

    protected override void CustomInitialization(MMF_Player owner)
    {
        base.CustomInitialization(owner);
        // your init code goes here
    }

    protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1.0f)
    {
        if (!Active || !FeedbackTypeAuthorized)
        {
            return;
        }            
        // your play code goes here
        AkSoundEngine.PostEvent(_wwiseEventName, Owner.gameObject);
    }

    protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1)
    {
        if (!FeedbackTypeAuthorized)
        {
            return;
        }            
        // your stop code goes here
    }
}
