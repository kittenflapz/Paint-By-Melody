using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public AudioClip[] noteClips;

    public List<Note> notesJustPlayed;
    public List<ColourableFloorSection> floorSections;

    public MovingPlatform movingPlatform;

    SaveManager saveManager;

    private void Awake()
    {
        saveManager = FindObjectOfType<SaveManager>();
        
    }

    private void Start()
    {
        saveManager.LoadPlatformsColoured(floorSections);
    }
    public void WinCheck()
    {

        bool hasWon = true;
        foreach (ColourableFloorSection floorSection in floorSections)
        {
           if (CheckMatch(notesJustPlayed, floorSection.melody.notes))
            {
                floorSection.FillIn();
            }
            if (!floorSection.GetFilledIn())
            {
                hasWon = false;
            }
        }

        if (hasWon)
        {
            movingPlatform.StartMoving();
        }
    }

  
    public void ClearNotesJustPlayedList()
    {
        notesJustPlayed.Clear();
    }


    public bool CheckMatch(List<Note> l1, List<Note> l2)
    {
        if (l1.Count != l2.Count)
            return false;
        for (int i = 0; i < l1.Count; i++)
        {
            if (l1[i] != l2[i])
                return false;
        }
        return true;
    }

    private void OnDestroy()
    {
        saveManager.SavePlatformsColoured(floorSections);
    }
}
