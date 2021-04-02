using UnityEngine;

// Each "melody" scriptable object stores an array of notes (a melody, one might say!)
// and a color. A section of floor keeps a MelodySO, and when its melody is played on the big keyboard,
// it will turn into the color it is supposed to be 

[CreateAssetMenu(fileName = "NewMelody", menuName = "ScriptableObjects/MelodyScriptableObject", order = 1)]
public class MelodyScriptableObject : ScriptableObject
{
    // list
    public Note[] notes;
    public Color successfulFloorColor;
}