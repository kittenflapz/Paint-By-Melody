using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Suffix S refers to 'sharp' since we can't use #
public enum Note
{
    A,
    AS,
    B,
    C,
    CS,
    D,
    DS,
    E, 
    F, 
    FS, 
    G,
    GS
}

public class Key : MonoBehaviour
{
    [SerializeField]
    Note note;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip[] noteClips;

    // Start is called before the first frame update
    void Start()
    {
        AssignNote();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AssignNote()
    {
        audioSource.clip = noteClips[(int)note];
    }
}
