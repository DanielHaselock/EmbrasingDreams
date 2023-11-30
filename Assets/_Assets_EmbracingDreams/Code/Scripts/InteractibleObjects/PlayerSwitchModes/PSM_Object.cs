using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Events;

public class PSM_Object : InteractibleObject
{
    // Start is called before the first frame update

    public UnityEvent Calm;
    public UnityEvent Hyper;

    [SerializeField] private MMF_Player CalmFeedback;
    [SerializeField] private MMF_Player HyperFeedback;

    void Awake()
    {
        base.Awake(); 
    }

    public override void Flush(int a) // 0 Hyper , 1 calm
    {
        if (a == 0)
        {
            Hyper?.Invoke();
            if (CalmFeedback != null) CalmFeedback.StopFeedbacks(CalmFeedback.transform.position);
            if (HyperFeedback != null) HyperFeedback.PlayFeedbacks(HyperFeedback.transform.position);
        }
        else if (a == 1)
        {
            Calm?.Invoke();
            if (HyperFeedback != null) HyperFeedback.StopFeedbacks(HyperFeedback.transform.position);
            if (CalmFeedback != null) CalmFeedback.PlayFeedbacks(CalmFeedback.transform.position);

        }
    }

}
