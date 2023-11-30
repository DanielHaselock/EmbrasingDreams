using UnityEngine;
using System.Collections;

//--------------------------------------------------------------------
//ControlledCollider is the base class of ControlledCapsuleCollider
//In theory, it can be overriden by different shape colliders, but only capsule has been implemented
//CharacterControllerBases only have this to access collider functions, modules use ControlledCapsuleCollider
//--------------------------------------------------------------------
public abstract class ControlledCollider : MonoBehaviour
{
    [Tooltip("Layermask used for all collisions in collider")]
    [SerializeField] protected LayerMask m_LayerMask;
    protected Vector2 m_Velocity;
    protected Vector2 m_PrevVelocity;
    protected bool m_CollisionsActive = true;
    public Vector2 GetPreviousVelocity()
    {
        return m_PrevVelocity;
    }

    public Vector2 GetVelocity()
    {
        return m_Velocity;
    }

    public void SetVelocity(Vector2 a_Velocity)
    {
        m_Velocity = a_Velocity;
    }

    public virtual void SetPosition(Vector3 a_Position)
    {
        transform.position = a_Position;
    }
    public virtual void SetRotation(Quaternion a_Rotation)
    {
        transform.rotation = a_Rotation;
    }

    public LayerMask GetLayerMask()
    {
        int layerID = gameObject.layer;
        LayerMask mask = 0;
        for (int i = 0; i < 32; i++) // Unity supports up to 32 user layers
        {
            if (!Physics.GetIgnoreLayerCollision(layerID, i))
            {
                mask |= 1<<i;
            }
        }

        m_LayerMask = mask;
        return m_LayerMask;
    }

    public void ToggleCollisionsActive()
    {
        m_CollisionsActive = !m_CollisionsActive;
    }

    public bool AreCollisionsActive()
    {
        return m_CollisionsActive;
    }

    public abstract void UpdateWithVelocity(Vector2 a_Velocity);

    public abstract void UpdateContextInfo();

    public abstract bool IsGrounded();

    public abstract CGroundedInfo GetGroundedInfo();

    public abstract bool IsCompletelyTouchingWall();

    public abstract bool IsPartiallyTouchingWall();

    public abstract CSideCastInfo GetSideCastInfo();

    public abstract bool IsTouchingEdge();

    public abstract CEdgeCastInfo GetEdgeCastInfo();

    public abstract void AddColPoint(Transform a_Parent, Vector3 a_Point, Vector3 a_Normal);

    public abstract void ClearColPoints();


    public virtual bool CanAlignWithNormal(Vector3 a_Normal, RotateMethod a_Method = RotateMethod.FromBottom)
    {
        return false;
    }
    public virtual void RotateToAlignWithNormal(Vector3 a_Normal, RotateMethod a_Method = RotateMethod.FromBottom)
    {
    }
}