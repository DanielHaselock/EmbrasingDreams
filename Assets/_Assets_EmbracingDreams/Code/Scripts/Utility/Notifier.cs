using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier : MonoBehaviour
{
    [SerializeField] public String toNotify;
    [SerializeField] public LayerMask triggerLayers; // Define which layers can trigger the feedback.
}
