using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColourableFloorSection : MonoBehaviour
{

    private bool filledIn;
    public MelodyScriptableObject melody;

    [SerializeField]
    TextMeshProUGUI notesLastHeard;

    public bool GetFilledIn()
    {
        return filledIn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // The floor section keeps the notes in its MelodyScriptableObject, but the player does the playing of the notes!
            // (so I don't have to have an audio source on each floor section)
            other.gameObject.GetComponent<PlayerController>().PlayMelody(melody.notes);

            SetNotesLastHeardText();

        }
    }

    public void SetNotesLastHeardText()
    {
        string notesLastHeardString = "";
        foreach (Note note in melody.notes)
        {
            notesLastHeardString = notesLastHeardString.Insert(notesLastHeardString.Length, note.ToString());
        }

        notesLastHeard.SetText(notesLastHeardString);
    }

    public void FillIn()
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", melody.successfulFloorColor);
        filledIn = true;
    }
}
