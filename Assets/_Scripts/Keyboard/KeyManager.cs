using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public AudioClip[] noteClips;

    public List<Note> notesJustPlayed;
    public List<Note> theCorrectTune = new List<Note>{ Note.C, Note.CS, Note.D };
    public List<ColourableFloorSection> floorSections;


    private void Start()
    {

    }

    private void Update()
    {
        if (CheckMatch(notesJustPlayed, theCorrectTune))
        {
            print("win");
        }
    }

    public void WinCheck()
    {
        foreach (ColourableFloorSection floorSection in floorSections)
        {
           if (CheckMatch(notesJustPlayed, floorSection.melody.notes))
            {
                floorSection.FillIn();
            }
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
}
