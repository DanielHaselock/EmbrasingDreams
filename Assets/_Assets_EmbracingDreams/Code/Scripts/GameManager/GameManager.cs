using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TemporaryGameCompany;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public static class GameManager
{
    // Start is called before the first frame update

    public static List<InteractibleObject> InteractibleObjects = new List<InteractibleObject>();

    public static Dictionary<MusicInteractible, bool> MusicNotePickups = new Dictionary<MusicInteractible, bool>();
    public static void NotifyPlayerState(PlayerModes.PlayerMode mode)
    {
        foreach(InteractibleObject obj in InteractibleObjects)
        {
            obj.Flush((int)mode);
        }
    }

    public static void PauseGame(bool paused)
    {
        if (paused)
            Time.timeScale = 0;
        else if(!paused)
            Time.timeScale = 1;
    }

    public static void SetTime(float pTime)
    {
        Time.timeScale = pTime;
    }

    public static bool CheckPickup(MusicInteractible note)
    {
        if (MusicNotePickups.ContainsKey(note))
        {
            if (MusicNotePickups[note] == false)
            {
                MusicNotePickups[note] = true;
                return true;
            }
        }
        return false;
    }
   
}
