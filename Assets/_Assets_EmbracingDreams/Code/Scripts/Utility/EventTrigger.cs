using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent toActivate;
    [SerializeField] private LayerMask triggerLayer;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger!");
        // Check if the object is in the specified layer
        if (((1 << other.gameObject.layer) & triggerLayer) != 0)
        {
            // Invoke the event
            toActivate.Invoke();

            // Destroy this game object
            Destroy(gameObject);
        }
    }
}