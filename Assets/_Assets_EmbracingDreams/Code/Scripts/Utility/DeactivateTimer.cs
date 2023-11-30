using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateTimer : MonoBehaviour
{
    [SerializeField] private float delayBeforeDeactivating = 5f; // Time in seconds before the GameObject is deactivated

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(DeactivateAfterDelay());
    }
    
    void OnDisable()
    {
        StopCoroutine(DeactivateAfterDelay());
    }

    private IEnumerator DeactivateAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeDeactivating);

        // Deactivate the GameObject
        gameObject.SetActive(false);
    }
}
