using UnityEngine;
using System.Collections;
using MoreMountains.Feedbacks;

//--------------------------------------------------------------------
//Spawns particles when the character is moving across the floor
//--------------------------------------------------------------------
public class OnRunParticleSpawner : MonoBehaviour {
    [SerializeField] ControlledCapsuleCollider m_Collider = null;
    [SerializeField] float m_LowThreshold = 0.0f;
    [SerializeField] float m_HighThreshold = 0.0f;
    [SerializeField] ParticleSystem m_ParticleSystem = null;
    [SerializeField] int m_LowEmissionCount = 0;
    [SerializeField] int m_HighEmissionCount = 0;
    
    [SerializeField] float secondDelay = 0;
    [SerializeField] float soundDelay = 1.25f;
    [SerializeField] private MMF_Player onStep;

    private float accumTime = 0;
    private float accumTime2 = 0;
	void Update ()
    {
        accumTime += Time.deltaTime;
        accumTime2 += Time.deltaTime;
        if (accumTime > secondDelay)
        {
            accumTime = 0;
            if (m_Collider.IsGrounded())
            {
                CGroundedInfo groundedInfo = m_Collider.GetGroundedInfo();
                Vector2 currentVel = m_Collider.GetVelocity();
                float dot = Vector3.Dot(currentVel, CState.GetDirectionAlongNormal(currentVel, groundedInfo.GetNormal()));

                if (dot >= m_LowThreshold)
                {
                    int emission = m_LowEmissionCount;
                    if (dot >= m_HighThreshold)
                    {
                        emission = m_HighEmissionCount;
                    }
                    m_ParticleSystem.transform.position = groundedInfo.GetPoint();
                    m_ParticleSystem.transform.LookAt(groundedInfo.GetPoint() + new Vector3(groundedInfo.GetNormal().x, groundedInfo.GetNormal().y, 0.0f), Vector3.back);
                    m_ParticleSystem.Emit(emission);
                }
            }
        }

        if (accumTime2 > soundDelay)
        {
            accumTime2 = 0;
            if (m_Collider.IsGrounded())
            {
                CGroundedInfo groundedInfo = m_Collider.GetGroundedInfo();
                Vector2 currentVel = m_Collider.GetVelocity();
                float dot = Vector3.Dot(currentVel, CState.GetDirectionAlongNormal(currentVel, groundedInfo.GetNormal()));

                if (dot >= m_LowThreshold)
                {
                    onStep.PlayFeedbacks();
                }
            }
        }
    }
}
