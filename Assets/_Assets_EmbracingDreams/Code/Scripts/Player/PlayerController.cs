using MoreMountains.Feedbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform startPosition; // Assign this in the editor
    [SerializeField] private GroundedCharacterController characterController; // Assign this in the editor
    
    [SerializeField] private MMF_Player onDeath;

    public bool IsInWall = false;

    private void Awake()
    {
        // Stops all playing sounds
        AkSoundEngine.StopAll();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with an enemy
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("AlwaysEnemy")) 
        {
            // Check if there is a current checkpoint set
            if (Checkpoint.m_CurrentCheckPoint != null)
            {
                // Move the player to the last checkpoint position
                characterController.SpawnAndResetAtPosition(Checkpoint.m_CurrentCheckPoint.position);
            }
            else
            {
                // Optional: If no checkpoint is set, maybe respawn at the start or a default position
                characterController.SpawnAndResetAtPosition(startPosition.position);
            }
            PlayerModes playerMode = gameObject.GetComponent<PlayerModes>();
            if (playerMode)
            {
                playerMode.Set_Stamina(playerMode.Get_Stamina()/1.5f);
            }
            ShowHitUI();
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("SuffocateObstacle"))
        {
            IsInWall = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("SuffocateObstacle"))
        {
            IsInWall = false;
        }
    }
    private void ShowHitUI()
    {
        ScreenFlashUI Hit = GameObject.FindAnyObjectByType<ScreenFlashUI>();
        Hit.SetDecrease(true);
    }

    public void Death()
    {
        onDeath.PlayFeedbacks();
        if (Checkpoint.m_CurrentCheckPoint != null)
        {
            // Move the player to the last checkpoint position
            characterController.SpawnAndResetAtPosition(Checkpoint.m_CurrentCheckPoint.position);
        }
        else
        {
            // Optional: If no checkpoint is set, maybe respawn at the start or a default position
            characterController.SpawnAndResetAtPosition(startPosition.position);
        }
        //gameObject.GetComponent<PlayerModes>().Set_Stamina(0);
        ShowHitUI();
    }
}