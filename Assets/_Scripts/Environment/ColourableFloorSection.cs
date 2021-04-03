using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColourableFloorSection : MonoBehaviour
{
    [SerializeField]
    public int platformIdentifier;

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
        filledIn = true;
        StartCoroutine(LerpToColor(melody.successfulFloorColor, 3));
    }

    // adapted from https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/#lerp_material_colour
    IEnumerator LerpToColor(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = GetComponent<MeshRenderer>().material.color;

        while (time < duration)
        {
            GetComponent<MeshRenderer>().material.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        GetComponent<MeshRenderer>().material.color = endValue;
    }

}
