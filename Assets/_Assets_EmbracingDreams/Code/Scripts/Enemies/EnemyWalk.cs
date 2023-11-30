using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform groundDetection;
    
    [SerializeField] private LayerMask obstacles;

    private bool movingRight = true;
    private Vector2 startPosition;

    private float previousHeight;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime * (movingRight ? 1 : -1)));
        
        // Check ground hit.
        RaycastHit hit;
        bool hasHit = Physics.Raycast(groundDetection.position, Vector3.down, out hit, 1f, obstacles);
        Debug.DrawLine(groundDetection.position, groundDetection.position + Vector3.down);
        if (hit.collider == false || !IsGroundLevel(hit.point))
        {
            // If it's at the end of the platform or the height has changed, flip direction
            Flip();
        }
        
        // Check wall hit.
        hasHit = Physics.Raycast(groundDetection.position, Vector3.right * transform.localScale.x , out hit, 0.2f, obstacles);
        if (hasHit)
        {
            // If it's at the end of the platform or the height has changed, flip direction
            Flip();
        }
    }

    private bool IsGroundLevel(Vector2 groundPoint)
    {
        // Check if the ground point y-position differs from the start position by a margin, accounting for minor variations
        bool result = Mathf.Abs(groundPoint.y - previousHeight) < 0.1f;
        
        previousHeight = groundPoint.y;
        return result;
    }

    private void Flip()
    {
        movingRight = !movingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
